namespace WiFi_Sign.View
{
    partial class Drivers
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TarlogicInstSt = new System.Windows.Forms.Label();
            this.WinpcapInstSt = new System.Windows.Forms.Label();
            this.AirpcapInstSt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnInst = new System.Windows.Forms.Button();
            this.BtnUninstall = new System.Windows.Forms.Button();
            this.noticeLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "简介";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "如果您在使用萌签的时候，无法检测到您的无线网卡，且您确认您的\r\n无线网卡兼容 Monitor 模式，则请使用本工具修复驱动。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TarlogicInstSt);
            this.groupBox2.Controls.Add(this.WinpcapInstSt);
            this.groupBox2.Controls.Add(this.AirpcapInstSt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "驱动安装情况";
            // 
            // TarlogicInstSt
            // 
            this.TarlogicInstSt.AutoSize = true;
            this.TarlogicInstSt.Location = new System.Drawing.Point(196, 70);
            this.TarlogicInstSt.Name = "TarlogicInstSt";
            this.TarlogicInstSt.Size = new System.Drawing.Size(43, 13);
            this.TarlogicInstSt.TabIndex = 5;
            this.TarlogicInstSt.Text = "未安装";
            // 
            // WinpcapInstSt
            // 
            this.WinpcapInstSt.AutoSize = true;
            this.WinpcapInstSt.Location = new System.Drawing.Point(196, 48);
            this.WinpcapInstSt.Name = "WinpcapInstSt";
            this.WinpcapInstSt.Size = new System.Drawing.Size(43, 13);
            this.WinpcapInstSt.TabIndex = 4;
            this.WinpcapInstSt.Text = "未安装";
            // 
            // AirpcapInstSt
            // 
            this.AirpcapInstSt.AutoSize = true;
            this.AirpcapInstSt.Location = new System.Drawing.Point(196, 26);
            this.AirpcapInstSt.Name = "AirpcapInstSt";
            this.AirpcapInstSt.Size = new System.Drawing.Size(43, 13);
            this.AirpcapInstSt.TabIndex = 3;
            this.AirpcapInstSt.Text = "未安装";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(31, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tarlogic NDIS 驱动";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "WinPcap 组件";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "AirPcap™ 组件";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnInst
            // 
            this.BtnInst.Location = new System.Drawing.Point(230, 191);
            this.BtnInst.Name = "BtnInst";
            this.BtnInst.Size = new System.Drawing.Size(75, 23);
            this.BtnInst.TabIndex = 2;
            this.BtnInst.Text = "安装";
            this.BtnInst.UseVisualStyleBackColor = true;
            this.BtnInst.Click += new System.EventHandler(this.BtnInst_Click);
            // 
            // BtnUninstall
            // 
            this.BtnUninstall.Location = new System.Drawing.Point(311, 191);
            this.BtnUninstall.Name = "BtnUninstall";
            this.BtnUninstall.Size = new System.Drawing.Size(75, 23);
            this.BtnUninstall.TabIndex = 3;
            this.BtnUninstall.Text = "卸载";
            this.BtnUninstall.UseVisualStyleBackColor = true;
            this.BtnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            // 
            // noticeLbl
            // 
            this.noticeLbl.AutoSize = true;
            this.noticeLbl.Location = new System.Drawing.Point(19, 196);
            this.noticeLbl.Name = "noticeLbl";
            this.noticeLbl.Size = new System.Drawing.Size(35, 13);
            this.noticeLbl.TabIndex = 4;
            this.noticeLbl.Text = "label5";
            // 
            // Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 226);
            this.Controls.Add(this.noticeLbl);
            this.Controls.Add(this.BtnUninstall);
            this.Controls.Add(this.BtnInst);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Drivers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "驱动安装助手";
            this.Load += new System.EventHandler(this.Drivers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label TarlogicInstSt;
        private System.Windows.Forms.Label WinpcapInstSt;
        private System.Windows.Forms.Label AirpcapInstSt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnInst;
        private System.Windows.Forms.Button BtnUninstall;
        private System.Windows.Forms.Label noticeLbl;
    }
}