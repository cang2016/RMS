using System;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace RMS.UserControls
{
    public class AnimatedForm :Form
    {
        Thread scaleThread;
        delegate void SetFormSizeCallback(int width, int height);
        delegate void CloseFormCallback();

        int oriWidth, oriHeight, interval, speed;
        bool animating = false, closeEventAnimated = false;

        public AnimatedForm()
        {
            interval = 15;
            speed = 80;
        }

        #region Public Properties

        [Category("Animation"), DefaultValue(60), Description("Gets or sets how fast the form should be animated.")]
        public int AnimationSpeed
        {
            get
            {
                return speed;
            }
            set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("AnimationSpeed", "Value must be between 0 and 100.");
                speed = value;
            }
        }

        #endregion

        #region Private Methods

        private void SetFormSize(int width, int height)
        {
            if(this.InvokeRequired)
            {
                SetFormSizeCallback setSize = new SetFormSizeCallback(SetFormSize);
                this.Invoke(setSize, new object[] { width, height });
            }
            else
            {
                Width = width;
                Height = height;
            }
        }

        private void CloseForm()
        {
            if(this.InvokeRequired)
            {
                CloseFormCallback closeForm = new CloseFormCallback(CloseForm);
                this.Invoke(closeForm);
            }
            else
            {
                Close();
            }
        }

        private int GetSinValue(int prop, int i, double incr, bool AccelPlus)
        {
            if(!AccelPlus)
                return (int)((double)prop * Math.Sin((double)i * incr * Math.PI / 2d));
            else
                return (int)((double)prop * (1d - Math.Sin((double)i * incr * Math.PI / 2d)));
        }

        #region Animation

        private void AnimateOpen()
        {
            Animate(true);
        }

        private void AnimateClose()
        {
            Animate(false);
            closeEventAnimated = true;
            CloseForm();
        }

        private void Animate(bool opening)
        {
            if(animating)
                return;
            else
                animating = true;

            int steps = 110 - speed;
            double incr = 1d / (double)steps;

            if(opening)
            {
                for(int i = 0; i < steps; i++)
                {
                    int width = GetSinValue(oriWidth, i, incr, false);
                    int height = 30 + width;
                    SetFormSize(width, height);

                    Thread.Sleep(interval);
                }
            }
            else
            {
                oriWidth = Width;
                oriHeight = Height;

                for(int i = 0; i < steps; i++)
                {
                    int width = GetSinValue(oriWidth, i, incr, true);
                    int height = width;
                    SetFormSize(width, height);

                    Thread.Sleep(interval);
                }
            }

            animating = false;
        }

        #endregion

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            oriWidth = Width;
            oriHeight = Height;

            if(speed != 0)
            {
                Width = 10;
                Height = 30;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            if(!DesignMode && speed != 0)
            {
                scaleThread = new Thread(new ThreadStart(AnimateOpen));
                scaleThread.Start();
            }

            base.OnShown(e);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(!DesignMode && this.WindowState != FormWindowState.Maximized && speed != 0 && !closeEventAnimated)
            {
                scaleThread = new Thread(new ThreadStart(AnimateClose));
                scaleThread.Start();
                e.Cancel = true;
            }
        }

        #endregion
    }
}
