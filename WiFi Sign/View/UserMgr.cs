using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiFi_Sign.Class;

namespace WiFi_Sign.View
{
    public partial class UserMgr : Form
    {
        public UserMgr()
        {
            InitializeComponent();
        }

        private void UserMgr_Load(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection Db = new SQLiteConnection("Data Source=" + Config.DbFile + ";Version=3;");

                Db.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM Users", Db);
                SQLiteDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Reader.GetString(0);
                    item.SubItems.Add(Reader.GetString(1));

                    UserList.Items.Add(item);
                }

                Db.Close();
            }
            catch
            { }
        }

        private void 编辑成员EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View.EditUser(UserList.FocusedItem.SubItems[0].Text, UserList.FocusedItem.SubItems[1].Text).Show();
        }

        private void 注销登记toolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show($"你确定注销 {UserList.FocusedItem.SubItems[0].Text} 吗？", "严重警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                int Status = DataBase.Excute(Config.DbFile, $"DELETE FROM Users WHERE macaddr='{UserList.FocusedItem.SubItems[1].Text}'");

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
    }
}
