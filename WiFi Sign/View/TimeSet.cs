using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiFi_Sign.Class;

namespace WiFi_Sign.View
{
    public partial class TimeSet : Form
    {
        public TimeSet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try // 尝试保存设置
            {
                if (DataBase.Excute(Config.DbFile, $"UPDATE Settings SET value='{WorkStart.Value.ToLongTimeString()}' WHERE key='WorkStart'") != 1)
                    DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('WorkStart', '{WorkStart.Value.ToLongTimeString()}')");

                if (DataBase.Excute(Config.DbFile, $"UPDATE Settings SET value='{WorkEnd.Value.ToLongTimeString()}' WHERE key='WorkEnd'") != 1)
                    DataBase.Excute(Config.DbFile, $"INSERT INTO Settings VALUES ('WorkEnd', '{WorkEnd.Value.ToLongTimeString()}')");

                MessageBox.Show("设置已保存", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimeSet_Load(object sender, EventArgs e)
        {
            string WorkStartTime, WorkEndTime = string.Empty;

            try
            {
                if ((WorkStartTime = DataBase.QueryOnce(Config.DbFile, $"SELECT value FROM Settings WHERE key='WorkStart'", 0)) != string.Empty)
                    WorkStart.Value = DateTime.Parse(WorkStartTime);

                if ((WorkEndTime = DataBase.QueryOnce(Config.DbFile, $"SELECT value FROM Settings WHERE key='WorkEnd'", 0)) != string.Empty)
                    WorkEnd.Value = DateTime.Parse(WorkEndTime);
            }
            catch
            { }
        }
    }
}
