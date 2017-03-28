namespace WiFi_Sign
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.AdapterList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStartCap = new System.Windows.Forms.Button();
            this.SignList = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMacAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSignTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOfflineTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeviceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加成员AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑成员EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销登记toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeviceOnlineOfflineNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeviceOnlineCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成员MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加成员AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideNonameDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.清空列表CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyWhenLogon = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaySoundOnNotify = new System.Windows.Forms.ToolStripMenuItem();
            this.成员管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.上下班时间TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看统计报表VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.保存报表SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.DeviceContextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdapterList
            // 
            this.AdapterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdapterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AdapterList.FormattingEnabled = true;
            this.AdapterList.Location = new System.Drawing.Point(97, 31);
            this.AdapterList.Name = "AdapterList";
            this.AdapterList.Size = new System.Drawing.Size(471, 21);
            this.AdapterList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "无线网卡列表";
            // 
            // BtnStartCap
            // 
            this.BtnStartCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartCap.Location = new System.Drawing.Point(577, 30);
            this.BtnStartCap.Name = "BtnStartCap";
            this.BtnStartCap.Size = new System.Drawing.Size(75, 23);
            this.BtnStartCap.TabIndex = 3;
            this.BtnStartCap.Text = "开始";
            this.BtnStartCap.UseVisualStyleBackColor = true;
            this.BtnStartCap.Click += new System.EventHandler(this.BtnStartCap_Click);
            // 
            // SignList
            // 
            this.SignList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SignList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colMacAddr,
            this.colSignTime,
            this.colOfflineTime,
            this.colLastTime});
            this.SignList.ContextMenuStrip = this.DeviceContextMenu;
            this.SignList.FullRowSelect = true;
            this.SignList.GridLines = true;
            this.SignList.Location = new System.Drawing.Point(12, 61);
            this.SignList.MultiSelect = false;
            this.SignList.Name = "SignList";
            this.SignList.Size = new System.Drawing.Size(640, 508);
            this.SignList.TabIndex = 4;
            this.SignList.UseCompatibleStateImageBehavior = false;
            this.SignList.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "姓名";
            this.colName.Width = 100;
            // 
            // colMacAddr
            // 
            this.colMacAddr.Text = "设备物理地址";
            this.colMacAddr.Width = 150;
            // 
            // colSignTime
            // 
            this.colSignTime.Text = "签到时间";
            this.colSignTime.Width = 120;
            // 
            // colOfflineTime
            // 
            this.colOfflineTime.Text = "离线时间";
            this.colOfflineTime.Width = 120;
            // 
            // colLastTime
            // 
            this.colLastTime.Text = "最后可见";
            this.colLastTime.Width = 120;
            // 
            // DeviceContextMenu
            // 
            this.DeviceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加成员AToolStripMenuItem1,
            this.编辑成员EToolStripMenuItem,
            this.注销登记toolStripMenuItem});
            this.DeviceContextMenu.Name = "DeviceContextMenu";
            this.DeviceContextMenu.Size = new System.Drawing.Size(143, 70);
            // 
            // 添加成员AToolStripMenuItem1
            // 
            this.添加成员AToolStripMenuItem1.Name = "添加成员AToolStripMenuItem1";
            this.添加成员AToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.添加成员AToolStripMenuItem1.Text = "添加成员(&A)";
            this.添加成员AToolStripMenuItem1.Click += new System.EventHandler(this.添加成员AToolStripMenuItem1_Click);
            // 
            // 编辑成员EToolStripMenuItem
            // 
            this.编辑成员EToolStripMenuItem.Name = "编辑成员EToolStripMenuItem";
            this.编辑成员EToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.编辑成员EToolStripMenuItem.Text = "编辑成员(&E)";
            this.编辑成员EToolStripMenuItem.Click += new System.EventHandler(this.编辑成员EToolStripMenuItem_Click);
            // 
            // 注销登记toolStripMenuItem
            // 
            this.注销登记toolStripMenuItem.Name = "注销登记toolStripMenuItem";
            this.注销登记toolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.注销登记toolStripMenuItem.Text = "注销登记(&U)";
            this.注销登记toolStripMenuItem.Click += new System.EventHandler(this.注销登记toolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.DeviceOnlineOfflineNum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(664, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel1.Text = "在线/总计";
            // 
            // DeviceOnlineOfflineNum
            // 
            this.DeviceOnlineOfflineNum.Name = "DeviceOnlineOfflineNum";
            this.DeviceOnlineOfflineNum.Size = new System.Drawing.Size(24, 17);
            this.DeviceOnlineOfflineNum.Text = "0/0";
            // 
            // DeviceOnlineCheckTimer
            // 
            this.DeviceOnlineCheckTimer.Interval = 1000;
            this.DeviceOnlineCheckTimer.Tick += new System.EventHandler(this.DeviceOnlineCheckTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.成员MToolStripMenuItem,
            this.查看VToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存报表SToolStripMenuItem,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 成员MToolStripMenuItem
            // 
            this.成员MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加成员AToolStripMenuItem,
            this.成员管理MToolStripMenuItem});
            this.成员MToolStripMenuItem.Name = "成员MToolStripMenuItem";
            this.成员MToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.成员MToolStripMenuItem.Text = "成员(&M)";
            // 
            // 添加成员AToolStripMenuItem
            // 
            this.添加成员AToolStripMenuItem.Name = "添加成员AToolStripMenuItem";
            this.添加成员AToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.添加成员AToolStripMenuItem.Text = "添加成员(&A) ...";
            this.添加成员AToolStripMenuItem.Click += new System.EventHandler(this.添加成员AToolStripMenuItem_Click);
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看统计报表VToolStripMenuItem,
            this.toolStripMenuItem1,
            this.HideNonameDevice,
            this.toolStripMenuItem3,
            this.清空列表CToolStripMenuItem});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.查看VToolStripMenuItem.Text = "列表(&L)";
            // 
            // HideNonameDevice
            // 
            this.HideNonameDevice.Checked = true;
            this.HideNonameDevice.CheckOnClick = true;
            this.HideNonameDevice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HideNonameDevice.Name = "HideNonameDevice";
            this.HideNonameDevice.Size = new System.Drawing.Size(182, 22);
            this.HideNonameDevice.Text = "隐藏未登记设备(&H)";
            this.HideNonameDevice.Click += new System.EventHandler(this.HideNonameDevice_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // 清空列表CToolStripMenuItem
            // 
            this.清空列表CToolStripMenuItem.Name = "清空列表CToolStripMenuItem";
            this.清空列表CToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.清空列表CToolStripMenuItem.Text = "清空列表(&C) ...";
            this.清空列表CToolStripMenuItem.Click += new System.EventHandler(this.清空列表CToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A) ...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // 查看地址ToolStripMenuItem
            // 
            this.查看地址ToolStripMenuItem.Name = "查看地址ToolStripMenuItem";
            this.查看地址ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "萌签";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyWhenLogon,
            this.PlaySoundOnNotify,
            this.toolStripMenuItem2,
            this.上下班时间TToolStripMenuItem});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            // 
            // NotifyWhenLogon
            // 
            this.NotifyWhenLogon.Checked = true;
            this.NotifyWhenLogon.CheckOnClick = true;
            this.NotifyWhenLogon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NotifyWhenLogon.Name = "NotifyWhenLogon";
            this.NotifyWhenLogon.Size = new System.Drawing.Size(179, 22);
            this.NotifyWhenLogon.Text = "签到弹窗提示(&N)";
            this.NotifyWhenLogon.Click += new System.EventHandler(this.NotifyWhenLogon_Click);
            // 
            // PlaySoundOnNotify
            // 
            this.PlaySoundOnNotify.Checked = true;
            this.PlaySoundOnNotify.CheckOnClick = true;
            this.PlaySoundOnNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlaySoundOnNotify.Name = "PlaySoundOnNotify";
            this.PlaySoundOnNotify.Size = new System.Drawing.Size(179, 22);
            this.PlaySoundOnNotify.Text = "弹窗时播放声音(&S)";
            this.PlaySoundOnNotify.Click += new System.EventHandler(this.PlaySoundOnNotify_Click);
            // 
            // 成员管理MToolStripMenuItem
            // 
            this.成员管理MToolStripMenuItem.Name = "成员管理MToolStripMenuItem";
            this.成员管理MToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.成员管理MToolStripMenuItem.Text = "成员管理(&M) ...";
            this.成员管理MToolStripMenuItem.Click += new System.EventHandler(this.成员管理MToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 6);
            // 
            // 上下班时间TToolStripMenuItem
            // 
            this.上下班时间TToolStripMenuItem.Name = "上下班时间TToolStripMenuItem";
            this.上下班时间TToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.上下班时间TToolStripMenuItem.Text = "上下班时间(&T) ...";
            this.上下班时间TToolStripMenuItem.Click += new System.EventHandler(this.上下班时间TToolStripMenuItem_Click);
            // 
            // 查看统计报表VToolStripMenuItem
            // 
            this.查看统计报表VToolStripMenuItem.Name = "查看统计报表VToolStripMenuItem";
            this.查看统计报表VToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.查看统计报表VToolStripMenuItem.Text = "查看统计报表(&V) ...";
            this.查看统计报表VToolStripMenuItem.Click += new System.EventHandler(this.查看统计报表VToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(179, 6);
            // 
            // 保存报表SToolStripMenuItem
            // 
            this.保存报表SToolStripMenuItem.Name = "保存报表SToolStripMenuItem";
            this.保存报表SToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存报表SToolStripMenuItem.Text = "保存报表(&S)";
            this.保存报表SToolStripMenuItem.Click += new System.EventHandler(this.保存报表SToolStripMenuItem_Click);
            // 
            // SaveTimer
            // 
            this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 601);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SignList);
            this.Controls.Add(this.BtnStartCap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdapterList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(655, 360);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "萌签管理系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DeviceContextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox AdapterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStartCap;
        private System.Windows.Forms.ListView SignList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colMacAddr;
        private System.Windows.Forms.ColumnHeader colSignTime;
        private System.Windows.Forms.ColumnHeader colOfflineTime;
        private System.Windows.Forms.ColumnHeader colLastTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer DeviceOnlineCheckTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DeviceOnlineOfflineNum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成员MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加成员AToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip DeviceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 查看地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加成员AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideNonameDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空列表CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑成员EToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 注销登记toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotifyWhenLogon;
        private System.Windows.Forms.ToolStripMenuItem PlaySoundOnNotify;
        private System.Windows.Forms.ToolStripMenuItem 成员管理MToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 上下班时间TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看统计报表VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 保存报表SToolStripMenuItem;
        private System.Windows.Forms.Timer SaveTimer;
    }
}

