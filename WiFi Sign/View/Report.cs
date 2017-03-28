using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using WiFi_Sign.Class;

namespace WiFi_Sign.View
{
    public partial class Report : Form
    {

        public TimeSpan WorkStart = DateTime.Parse(DataBase.QueryOnce(Config.DbFile, "SELECT value FROM Settings WHERE key='WorkStart'", 0)).TimeOfDay;
        public TimeSpan WorkEnd = DateTime.Parse(DataBase.QueryOnce(Config.DbFile, "SELECT value FROM Settings WHERE key='WorkEnd'", 0)).TimeOfDay;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection Db = new SQLiteConnection("Data Source=" + Config.AdDbFile + ";Version=3;");
                string Today = dateTimePicker1.Value.ToLongDateString().Replace("/", "");

                Db.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM RD_{Today}", Db);
                SQLiteDataReader Reader = command.ExecuteReader();

                SignList.Items.Clear(); // 清空列表
                while (Reader.Read())
                {
                    ListViewItem SignCol = new ListViewItem();

                    TimeSpan ToWork = DateTime.Parse(Reader.GetString(2)).TimeOfDay; // 计算迟到
                    string col4 = "";
                    if (ToWork > WorkStart)
                    {
                        col4 = "迟到";
                        SignCol.ForeColor = Color.Red;
                    }

                    DateTime OffWork = new DateTime(); // 计算早退
                    string col5 = "";
                    if (DateTime.TryParse(Reader.GetString(3), out OffWork))
                    {
                        TimeSpan OffWorkT = OffWork.TimeOfDay;
                        col5 = OffWorkT < WorkEnd ? "早退" : "";
                        SignCol.ForeColor = Color.Red;
                    }
                    
                    SignCol.Text = Reader.GetString(0);
                    SignCol.SubItems.Add(Reader.GetString(1));
                    SignCol.SubItems.Add(Reader.GetString(2));
                    SignCol.SubItems.Add(Reader.GetString(3));
                    SignCol.SubItems.Add(col4);
                    SignCol.SubItems.Add(col5);
                    
                    SignList.Items.Add(SignCol);
                }

                Db.Close();
            }
            catch
            {
                MessageBox.Show("该日无签到记录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            int i = 1;
            int i2 = 1;

            // 初始化表头
            foreach (ColumnHeader col in SignList.Columns)
            {
                ws.Cells[i2, i++] = col.Text;
            }

            i2 = 2; // 跳过表头来到第二行
            foreach (ListViewItem lvi in SignList.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                i2++;
            }

            //make all columns autofit
            //ws.Cells.Select();
            ws.Cells.EntireColumn.AutoFit();
            ws.Name = dateTimePicker1.Value.ToLongDateString() + "签到记录";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem item = SignList.FindItemWithText(textBox1.Text);
            if (item == null)
            {
                MessageBox.Show("无匹配记录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                item.Selected = true;
                item.Focused = true;
                SignList.Select();
                SignList.TopItem = item;
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }
    }
}
