using System;
using System.Media;
using System.Windows.Forms;

namespace WiFi_Sign.View
{
    public partial class NotifyBox : Form
    {
        private bool PlaySoundNotify = false;
        public NotifyBox(string t1, string t2, int delay, bool playSound)
        {
            InitializeComponent();
            this.label1.Text = t1;
            this.label2.Text = t2;
            PlaySoundNotify = playSound;
            closeTimer.Interval = delay;
            closeTimer.Enabled = true;
        }

        Timer timer_Up = new Timer();
        Timer timer_Down = new Timer();

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void NotifyBox_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom;
            timer_Up.Interval = 10;
            timer_Up.Tick += timer_Up_Tick;
            timer_Up.Enabled = true;

            if (PlaySoundNotify)
                SystemSounds.Exclamation.Play();
        }

        private void timer_Up_Tick(object sender, EventArgs e)
        {
            if (this.Bottom <= Screen.PrimaryScreen.WorkingArea.Bottom)
            {
                this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
                timer_Up.Enabled = false;
                return;
            }
            this.Top -= 10;
        }

        private void timer_Down_Tick(object sender, EventArgs e)
        {
            if (this.Top >= Screen.PrimaryScreen.Bounds.Bottom)
            {
                timer_Down.Enabled = false;
                this.Close();
                return;
            }
            this.Top += 10;
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            timer_Down.Interval = 10;
            timer_Down.Tick += timer_Down_Tick;
            timer_Down.Enabled = true;
        }
    }
}
