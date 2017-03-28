namespace WiFi_Sign.View
{
    partial class TimeSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WorkStart = new System.Windows.Forms.DateTimePicker();
            this.WorkEnd = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "上班时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "下班时间";
            // 
            // WorkStart
            // 
            this.WorkStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.WorkStart.Location = new System.Drawing.Point(83, 22);
            this.WorkStart.Name = "WorkStart";
            this.WorkStart.ShowUpDown = true;
            this.WorkStart.Size = new System.Drawing.Size(95, 20);
            this.WorkStart.TabIndex = 2;
            this.WorkStart.Value = new System.DateTime(2017, 3, 28, 8, 30, 0, 0);
            // 
            // WorkEnd
            // 
            this.WorkEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.WorkEnd.Location = new System.Drawing.Point(83, 55);
            this.WorkEnd.Name = "WorkEnd";
            this.WorkEnd.ShowUpDown = true;
            this.WorkEnd.Size = new System.Drawing.Size(95, 20);
            this.WorkEnd.TabIndex = 3;
            this.WorkEnd.Value = new System.DateTime(2017, 3, 28, 18, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(103, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TimeSet
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(209, 132);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WorkEnd);
            this.Controls.Add(this.WorkStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeSet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上下班时间设置";
            this.Load += new System.EventHandler(this.TimeSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker WorkStart;
        private System.Windows.Forms.DateTimePicker WorkEnd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}