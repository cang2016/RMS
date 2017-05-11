using System;
using System.Drawing;
using System.Windows.Forms;

namespace RMS.UserControls
{
    public partial class PopupNotifierListForm : Form
    {
        private bool isMouseOn = false;
        private bool isTimeOut = false;
        private Rectangle rect;

        public delegate void PopupNotifierCloseHandler();
        public event PopupNotifierCloseHandler PopupClose;

        public PopupNotifierListForm()
        {
            InitializeComponent();
            
            this.Opacity = 0;
            ResetValue(PopupNotifier.ContentText, PopupNotifier.Size, PopupNotifier.ShowDelay);
        }

        private void ShadowShowTimer_Tick(object sender, EventArgs e)
        {
            shadowTimer.Enabled = false;
            this.Opacity += 0.02;
            if (this.Opacity >= 0.9)
            {
                this.Opacity = 0.9;
                shadowTimer.Tick -= new EventHandler(ShadowShowTimer_Tick);
            }
            else shadowTimer.Enabled = true;
        }

        private void ShadowCloseTimer_Tick(object sender, EventArgs e)
        {
            shadowTimer.Enabled = false;
            this.Opacity -= 0.02;
            if (this.Opacity == 0)
            {
                shadowTimer.Tick -= new EventHandler(ShadowCloseTimer_Tick);
                PopupClose();
            }
            else shadowTimer.Enabled = true;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            mainTimer.Enabled = false;
            mainTimer.Tick -= new EventHandler(MainTimer_Tick);
            isTimeOut = true;
            if (!isMouseOn) FormClose();
        }

        private void FormClose()
        {
            shadowTimer.Enabled = true;
            shadowTimer.Tick += new EventHandler(ShadowCloseTimer_Tick);
        }

        public void ResetValue(string message, Size size, int delay)
        {
            this.Size = size;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Size.Width - 1,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.Size.Height - 1);
            labNotice.Width = 340;
            labNotice.Height = PopupNotifier.Size.Height - 40;
            labNotice.Location = new Point(15, 15);
            panelClose.Location = new Point(this.Size.Width - 25, 6);
            rect = new Rectangle(this.Left + panel1.Left, this.Top + panel1.Top, panel1.Width, panel1.Height);
            labNotice.Text = message;

            mainTimer.Interval = delay + 2500;
            mainTimer.Enabled = true;
            mainTimer.Tick += new EventHandler(this.MainTimer_Tick);
            isTimeOut = false;

            shadowTimer.Enabled = true;
            shadowTimer.Tick += new EventHandler(ShadowShowTimer_Tick);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            isMouseOn = true;
            shadowTimer.Enabled = false;
            shadowTimer.Tick -= new EventHandler(ShadowShowTimer_Tick);
            shadowTimer.Tick -= new EventHandler(ShadowCloseTimer_Tick);
            this.Opacity = 1;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!rect.Contains(Control.MousePosition))
            {
                isMouseOn = false;
                if (isTimeOut) FormClose();
                else
                {
                    this.Opacity = 0.9;
                }
            }
        }

        private void panelClose_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White, 2);
            g.DrawLine(p, 0, 0, 12, 12);
            g.DrawLine(p, 0, 12, 12, 0);
            p.Dispose();
            g.Dispose();
        }

        private void panelClose_Click(object sender, EventArgs e)
        {
            shadowTimer.Enabled = false;
            shadowTimer.Tick -= new EventHandler(ShadowShowTimer_Tick);
            shadowTimer.Tick -= new EventHandler(ShadowCloseTimer_Tick);
            mainTimer.Enabled = false;
            mainTimer.Tick -= new EventHandler(MainTimer_Tick);
            PopupClose();
        }

        private void labNotice_MouseLeave(object sender, EventArgs e)
        {
            if (!rect.Contains(Control.MousePosition))
            {
                isMouseOn = false;
                if (isTimeOut) FormClose();
                else
                {
                    this.Opacity = 0.9;
                }
            }
        }
    }
}
