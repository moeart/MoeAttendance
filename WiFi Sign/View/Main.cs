using System;
using System.ComponentModel;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.AirPcap;
using WiFi_Sign.BaseClass;
using WiFi_Sign.Class;
using System.IO;
using System.Data.SQLite;

namespace WiFi_Sign
{
    public partial class Main : Form
    {
        public AirPcapDeviceList devices; // 全局设备列表变量
        public bool StartedCap = false; // 是否已经开始抓包
        public SQLiteConnection UserDb = new SQLiteConnection(); // 用户信息数据库

        public Main()
        {
            InitializeComponent();
        }


        private void ListAllAdapter()
        {
            try
            {
                devices = AirPcapDeviceList.Instance; // 读取系统可用 AirPcap 设备列表

                for (var i = 0; i < devices.Count; i++)
                {
                    ComboboxItem AdpItem = new ComboboxItem();

                    AdpItem.Text = devices[i].Description;
                    AdpItem.Value = i;

                    AdapterList.Items.Add(AdpItem);
                }

                if (devices.Count == 0)
                {
                    AdapterList.Items.Add("没有找到任何支持 AirPcap™ 的设备");
                }

                AdapterList.SelectedIndex = 0;
            }
            catch
            {
                AdapterList.Items.Add("寻找兼容 AirPcap™ 技术的无线网卡发生错误");
            }
        }


        // 保存报表
        private void SaveReportForm(bool manual)
        {
            try
            {
                string Today = DateTime.Now.ToLongDateString().Replace("/", "");
                DataBase.Excute(Config.AdDbFile, $"CREATE TABLE IF NOT EXISTS RD_{Today} (name VARCHAR(20), macaddr VARCHAR(12), online VARCHAR(20), offline VARCHAR(20), last VARCHAR(20))");

                foreach (ListViewItem item in SignList.Items)
                {
                    string Name = item.Text;
                    string MacAddr = item.SubItems[1].Text;
                    string Online = item.SubItems[2].Text;
                    string Offline = item.SubItems[3].Text;
                    string Last = item.SubItems[4].Text;
                    DateTime OnlineDate = DateTime.Parse(Online).Date;

                    if (Name != Config.NoName && OnlineDate == DateTime.Today)
                    {
                        if (DataBase.Excute(Config.AdDbFile, $"UPDATE RD_{Today} SET name='{Name}', online='{Online}', offline='{Offline}', last='{Last}' WHERE macaddr='{MacAddr}'") != 1)
                            DataBase.Excute(Config.AdDbFile, $"INSERT INTO RD_{Today} VALUES ('{Name}', '{MacAddr}', '{Online}', '{Offline}', '{Last}')");
                    }
                }

                if (manual)
                    MessageBox.Show("今日数据已保存到数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                if (manual)
                    MessageBox.Show("保存数据失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        // 接收到新的数据包时处理
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            MacAddress MacProc = new MacAddress();
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            string macaddr = MacProc.GetWlanSa(e); // 获取设备的 MAC 地址，如果是 AP 则返回 Null

            if (macaddr != null && SignList.InvokeRequired)
            {
                SignList.Invoke(new MethodInvoker(delegate
                {
                    ListViewItem item = SignList.FindItemWithText(macaddr);
                    string now = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                    // 从 SQL 查询保存的名字
                    string name = DataBase.QueryOnce(Config.DbFile, $"SELECT name FROM Users WHERE macaddr='{macaddr}'", 0);
                    if (name == string.Empty)
                    {
                        if (HideNonameDevice.Checked == true) return; // 如果隐藏未登记设备勾选则直接跳过
                        name = Config.NoName;
                    }

                    if (item == null) // 设备是否曾经存在，否创建
                    {
                        ListViewItem SignCol = new ListViewItem();
                        SignCol.Text = name;
                        SignCol.SubItems.Add(macaddr);
                        SignCol.SubItems.Add(now);
                        SignCol.SubItems.Add("当前在线");
                        SignCol.SubItems.Add(now);

                        SignList.Items.Add(SignCol);
                        if (NotifyWhenLogon.Checked)
                            new View.NotifyBox($"{name} 签到", $"{macaddr}", 3000, PlaySoundOnNotify.Checked).Show(); // 首次签到发送通知
                        
                    }
                    else // 是，更新最后出现时间
                    {
                        if (item.SubItems[3].Text != "当前在线")
                        {
                            item.SubItems[3].Text = "当前在线";
                            if (NotifyWhenLogon.Checked)
                                new View.NotifyBox($"{name} 回来了", $"{macaddr}", 3000, PlaySoundOnNotify.Checked).Show(); // 只有之前离线再恢复才提醒
                        }
                        item.Text = name;
                        item.SubItems[4].Text = now;
                    }
                    
                }));
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ListAllAdapter(); // 列出所有可用的无线网卡

            // 初始化数据库
            if (!File.Exists(Config.DbFile))
            {
                DataBase.Create(Config.DbFile);
                DataBase.Excute(Config.DbFile, "CREATE TABLE Users (name VARCHAR(20), macaddr VARCHAR(12))");
                DataBase.Excute(Config.DbFile, "CREATE TABLE Settings (key VARCHAR(20), value VARCHAR(20))");

                DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('WorkStart', '8:30:00')");
                DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('WorkEnd', '18:00:00')");
            }
            if (!File.Exists(Config.AdDbFile))
            {
                DataBase.Create(Config.AdDbFile);
            }

            // 从数据库读取设置
            if (DataBase.QueryOnce(Config.DbFile, $"SELECT value FROM Settings WHERE key='HideNoName'", 0) == "False") HideNonameDevice.Checked = false;
            if (DataBase.QueryOnce(Config.DbFile, $"SELECT value FROM Settings WHERE key='AllowNotify'", 0) == "False") NotifyWhenLogon.Checked = false;
            if (DataBase.QueryOnce(Config.DbFile, $"SELECT value FROM Settings WHERE key='AllowSound'", 0) == "False") PlaySoundOnNotify.Checked = false;

        }


        private void BtnStartCap_Click(object sender, EventArgs e)
        {
            try
            {
                ComboboxItem SelectedItem = (ComboboxItem)AdapterList.SelectedItem;
                var device = devices[(int)SelectedItem.Value];

                if (!StartedCap)
                {
                    device.Open();
                    device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                    device.StartCapture();

                    AdapterList.Enabled = false;
                    BtnStartCap.Text = "停止";
                    StartedCap = true;
                    DeviceOnlineCheckTimer.Enabled = true; //启动设备在线统计计时器
                    SaveTimer.Interval = Config.SaveTime * 60 * 1000; // 设置报表自动保存时间
                    SaveTimer.Enabled = true;
                }
                else
                {
                    device.StopCapture();

                    AdapterList.Enabled = true;
                    BtnStartCap.Text = "开始";
                    StartedCap = false;
                    DeviceOnlineCheckTimer.Enabled = false;
                    SaveTimer.Enabled = false;
                    SaveReportForm(false); //保存报表
                }
            }
            catch
            {
                MessageBox.Show("与 AirPcap™ 设备通信时出现通信中断故障，请检查 AirPcap™ 设备物理链路。", "通信中断", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }


        private void DeviceOnlineCheckTimer_Tick(object sender, EventArgs e)
        {
            int total = 0;
            int offline = 0;

            // 找出离线设备并标出离线时间
            foreach (ListViewItem item in SignList.Items)
            {
                DateTime LastTime = DateTime.Parse(item.SubItems[4].Text);

                if ((DateTime.Now - LastTime).TotalMinutes > Config.OffTime) // 五分钟不见人，那就认定为脱离监控范围
                {
                    item.SubItems[3].Text = item.SubItems[4].Text;
                    offline++;
                }

                total++;
            }

            // 计算总量
            DeviceOnlineOfflineNum.Text = (total - offline).ToString() + "/" + total.ToString();
        }


        // 重写关闭按钮
        protected override void OnClosing(CancelEventArgs e)
        {
            if (StartedCap)
            {
                MessageBox.Show("请先停止当前任务并保存数据再退出", "任务执行中", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }

        // 重写最小化
        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE)
                {
                    this.Visible = false;
                    return;
                }
            }
            base.WndProc(ref m);
        }


        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加成员AToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SignList.FocusedItem.SubItems[0].Text == Config.NoName)
            {
                new View.AddUser(SignList.FocusedItem.SubItems[1].Text).Show();
            }
            else
            {
                MessageBox.Show("设备已登记无需重复登记", "已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 添加成员AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.AddUser(string.Empty).Show();
        }

        private void 清空列表CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("这将会清空所有未保存的记录，真的要继续吗？", "严重警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                SignList.Items.Clear();
            }
        }

        private void 编辑成员EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SignList.FocusedItem.SubItems[0].Text != Config.NoName)
            {
                new View.EditUser(SignList.FocusedItem.SubItems[0].Text, SignList.FocusedItem.SubItems[1].Text).Show();
            }
            else
            {
                MessageBox.Show("设备未登记请先登记", "未登记", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 注销登记toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SignList.FocusedItem.SubItems[0].Text != Config.NoName)
            {
                DialogResult ret = MessageBox.Show($"你确定注销 {SignList.FocusedItem.SubItems[0].Text} 吗？", "严重警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    int Status = DataBase.Excute(Config.DbFile, $"DELETE FROM Users WHERE macaddr='{SignList.FocusedItem.SubItems[1].Text}'");

                    if (Status == 1) // 如果是 1 表示添加成功，其他添加失败
                    {
                        MessageBox.Show("注销成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("注销失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("设备未登记无法注销", "未登记", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HideNonameDevice_Click(object sender, EventArgs e)
        {
            // 如果勾选了去掉未登记记录，那就遍历列表然后把未登记的全部删除
            if (HideNonameDevice.Checked == true)
            {
                foreach (ListViewItem item in SignList.Items)
                {
                    if (item.Text == Config.NoName)
                        item.Remove();
                }    
            }

            try // 尝试保存设置
            {
                if (DataBase.Excute(Config.DbFile, $"UPDATE Settings SET value='{HideNonameDevice.Checked.ToString()}' WHERE key='HideNoName'") != 1)
                    DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('HideNoName', '{HideNonameDevice.Checked.ToString()}')");
            }
            catch { }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.About().Show();
        }

        private void NotifyWhenLogon_Click(object sender, EventArgs e)
        {
            try // 尝试保存设置
            {
                if (DataBase.Excute(Config.DbFile, $"UPDATE Settings SET value='{NotifyWhenLogon.Checked.ToString()}' WHERE key='AllowNotify'") != 1)
                    DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('AllowNotify', '{NotifyWhenLogon.Checked.ToString()}')");
            }
            catch { }
        }

        private void PlaySoundOnNotify_Click(object sender, EventArgs e)
        {
            try // 尝试保存设置
            {
                if (DataBase.Excute(Config.DbFile, $"UPDATE Settings SET value='{PlaySoundOnNotify.Checked.ToString()}' WHERE key='AllowSound'") != 1)
                    DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('AllowSound', '{PlaySoundOnNotify.Checked.ToString()}')");
            }
            catch { }
        }

        private void 成员管理MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.UserMgr().Show();
        }

        private void 上下班时间TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.TimeSet().Show();
        }

        private void 查看统计报表VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.Report().Show();
        }

        private void 保存报表SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveReportForm(true);
        }

        // 报表保存计时器
        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            SaveReportForm(false);
        }
    }
}
