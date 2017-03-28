namespace WiFi_Sign.View
{
    partial class UserMgr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeviceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑成员EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销登记toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.UserList.ContextMenuStrip = this.DeviceContextMenu;
            this.UserList.FullRowSelect = true;
            this.UserList.GridLines = true;
            this.UserList.Location = new System.Drawing.Point(-3, -1);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(276, 500);
            this.UserList.TabIndex = 0;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "姓名";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "设备物理地址";
            this.columnHeader2.Width = 150;
            // 
            // DeviceContextMenu
            // 
            this.DeviceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑成员EToolStripMenuItem,
            this.注销登记toolStripMenuItem});
            this.DeviceContextMenu.Name = "DeviceContextMenu";
            this.DeviceContextMenu.Size = new System.Drawing.Size(143, 48);
            // 
            // 编辑成员EToolStripMenuItem
            // 
            this.编辑成员EToolStripMenuItem.Name = "编辑成员EToolStripMenuItem";
            this.编辑成员EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑成员EToolStripMenuItem.Text = "编辑成员(&E)";
            this.编辑成员EToolStripMenuItem.Click += new System.EventHandler(this.编辑成员EToolStripMenuItem_Click);
            // 
            // 注销登记toolStripMenuItem
            // 
            this.注销登记toolStripMenuItem.Name = "注销登记toolStripMenuItem";
            this.注销登记toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.注销登记toolStripMenuItem.Text = "注销登记(&U)";
            this.注销登记toolStripMenuItem.Click += new System.EventHandler(this.注销登记toolStripMenuItem_Click);
            // 
            // UserMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 497);
            this.Controls.Add(this.UserList);
            this.Name = "UserMgr";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserMgr_Load);
            this.DeviceContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView UserList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip DeviceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 编辑成员EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销登记toolStripMenuItem;
    }
}