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
    public partial class EditUser : Form
    {
        public EditUser(string name, string macaddr)
        {
            InitializeComponent();
            UserName.Text = name;
            MacAddress.Text = macaddr;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int Status = DataBase.Excute(Config.DbFile, $"UPDATE Users SET name='{UserName.Text}' WHERE macaddr='{MacAddress.Text}'");

            if (Status == 1) // 如果是 1 表示添加成功，其他添加失败
            {
                MessageBox.Show($"信息更新成功\r\n\r\n姓名: {UserName.Text}\r\n设备: {MacAddress.Text}", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("信息更新失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
