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
    public partial class AddUser : Form
    {
        public AddUser(string macaddr)
        {
            InitializeComponent();
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
            int Status = DataBase.Excute(Config.DbFile, $"INSERT INTO Users VALUES ('{UserName.Text}', '{MacAddress.Text}')");

            if (Status == 1) // 如果是 1 表示添加成功，其他添加失败
            {
                MessageBox.Show($"添加成功\r\n\r\n姓名: {UserName.Text}\r\n设备: {MacAddress.Text}", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
