using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RMS.UserControls
{
    public partial class PopupNotifierForm : Form
    {
        private bool bMouseOnClose = false;
        private bool bMouseOnLink = false;
        private bool bMouseOnOptions = false;
        private int iHeightOfTitle;

        public event EventHandler LinkClick;
        public event EventHandler CloseClick;

        public PopupNotifierForm()
        {
            InitializeComponent();
        }

        public PopupNotifierForm(PopupNotifierOld PopupNotifierOld)
            : this()
        {
            PopupNotifierOld = PopupNotifierOld;
        }


        #region Properties

        public PopupNotifierOld PopupNotifierOld { get; set; }

        #endregion

        #region Functions & Private properties
        private int AddValueMax255(int Input, int Add)
        {
            if (Input + Add < 256)
            {
                return Input + Add;
            }
            else
            {
                return 255;
            }
        }

        private int DedValueMin0(int Input, int Ded)
        {
            if (Input - Ded > 0)
            {
                return Input - Ded;
            }
            else
            {
                return 0;
            }
        }

        private Color GetDarkerColor(Color Color)
        {
            Color clNew = default(Color);
            clNew = System.Drawing.Color.FromArgb(255, DedValueMin0(Convert.ToInt32(Color.R), PopupNotifierOld.GradientPower), DedValueMin0(Convert.ToInt32(Color.G), PopupNotifierOld.GradientPower), DedValueMin0(Convert.ToInt32(Color.B), PopupNotifierOld.GradientPower));
            return clNew;
        }

        private Color GetLighterColor(Color Color)
        {
            Color clNew = default(Color);
            clNew = System.Drawing.Color.FromArgb(255, AddValueMax255(Convert.ToInt32(Color.R), PopupNotifierOld.GradientPower), AddValueMax255(Convert.ToInt32(Color.G), PopupNotifierOld.GradientPower), AddValueMax255(Convert.ToInt32(Color.B), PopupNotifierOld.GradientPower));
            return clNew;
        }

        private Color GetLighterTransparentColor(Color Color)
        {
            Color clNew = default(Color);
            clNew = System.Drawing.Color.FromArgb(0, AddValueMax255(Convert.ToInt32(Color.R), PopupNotifierOld.GradientPower), AddValueMax255(Convert.ToInt32(Color.G), PopupNotifierOld.GradientPower), AddValueMax255(Convert.ToInt32(Color.B), PopupNotifierOld.GradientPower));
            return clNew;
        }

        private RectangleF RectText
        {
            get
            {
                if ((PopupNotifierOld.Image != null))
                {
                    return new RectangleF(PopupNotifierOld.ImagePosition.X + PopupNotifierOld.ImageSize.Width + PopupNotifierOld.TextPadding.Left, PopupNotifierOld.TextPadding.Top + PopupNotifierOld.TextPadding.Top + iHeightOfTitle + PopupNotifierOld.HeaderHeight, this.Width - PopupNotifierOld.ImageSize.Width - PopupNotifierOld.ImagePosition.X - 16 - 5 - PopupNotifierOld.TextPadding.Left - PopupNotifierOld.TextPadding.Right, this.Height - PopupNotifierOld.HeaderHeight - PopupNotifierOld.TextPadding.Top - PopupNotifierOld.TextPadding.Top - PopupNotifierOld.TextPadding.Bottom - iHeightOfTitle - 1);
                }
                else
                {
                    return new RectangleF(PopupNotifierOld.TextPadding.Left, PopupNotifierOld.TextPadding.Top + PopupNotifierOld.TextPadding.Top + iHeightOfTitle + PopupNotifierOld.HeaderHeight, this.Width - 16 - 5 - PopupNotifierOld.TextPadding.Left - PopupNotifierOld.TextPadding.Right, this.Height - PopupNotifierOld.HeaderHeight - PopupNotifierOld.TextPadding.Top - PopupNotifierOld.TextPadding.Top - PopupNotifierOld.TextPadding.Bottom - iHeightOfTitle - 1);
                }
            }
        }

        private Rectangle RectClose
        {
            get { return new Rectangle(this.Width - 5 - 16, 12, 16, 16); }
        }

        private Rectangle RectOptions
        {
            get { return new Rectangle(this.Width - 5 - 16, 12 + 16 + 5, 16, 16); }
        }

        #endregion

        #region Events

        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (PopupNotifierOld.CloseButton)
            {
                if (RectClose.Contains(e.X, e.Y))
                {
                    bMouseOnClose = true;
                }
                else
                {
                    bMouseOnClose = false;
                }
            }
            if (PopupNotifierOld.OptionsButton)
            {
                if (RectOptions.Contains(e.X, e.Y))
                {
                    bMouseOnOptions = true;
                }
                else
                {
                    bMouseOnOptions = false;
                }
            }
            if (RectText.Contains(e.X, e.Y))
            {
                bMouseOnLink = true;
            }
            else
            {
                bMouseOnLink = false;
            }
            Invalidate();
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (RectClose.Contains(e.X, e.Y))
            {
                OnCloseClick();
            }
            if (RectText.Contains(e.X, e.Y))
            {
                OnLinkClick();
            }
            if (RectOptions.Contains(e.X, e.Y))
            {
                if ((PopupNotifierOld.OptionsMenu != null))
                {
                    PopupNotifierOld.OptionsMenu.Show(this, new Point(RectOptions.Right - PopupNotifierOld.OptionsMenu.Width, RectOptions.Bottom));
                    PopupNotifierOld.bShouldRemainVisible = true;
                }
            }
        }

        private void OnLinkClick()
        {
            if (LinkClick != null)
            {
                LinkClick(this, EventArgs.Empty);
            }
        }

        private void OnCloseClick()
        {
            if (CloseClick != null)
            {
                CloseClick(this, EventArgs.Empty);
            }

            this.Close();
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle rcBody = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle rcHeader = new Rectangle(0, 0, this.Width, PopupNotifierOld.HeaderHeight);
            Rectangle rcForm = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush brBody = new LinearGradientBrush(rcBody, PopupNotifierOld.BodyColor, GetLighterColor(PopupNotifierOld.BodyColor), LinearGradientMode.Vertical);

            LinearGradientBrush brHeader = new LinearGradientBrush(rcHeader, PopupNotifierOld.HeaderColor, GetDarkerColor(PopupNotifierOld.HeaderColor), LinearGradientMode.Vertical);
            var _with1 = e.Graphics;
            _with1.FillRectangle(brBody, rcBody);
            _with1.FillRectangle(brHeader, rcHeader);
            _with1.DrawRectangle(new Pen(PopupNotifierOld.BorderColor), rcForm);
            if (PopupNotifierOld.ShowGrip)
                _with1.DrawImage(Properties.Resources.grip, Convert.ToInt32((this.Width - Properties.Resources.grip.Width) / 2), Convert.ToInt32((PopupNotifierOld.HeaderHeight - 3) / 2));
            if (PopupNotifierOld.CloseButton)
            {
                if (bMouseOnClose)
                {
                    _with1.FillRectangle(new SolidBrush(PopupNotifierOld.ButtonHoverColor), RectClose);
                    _with1.DrawRectangle(new Pen(PopupNotifierOld.ButtonBorderColor), RectClose);
                }
                _with1.DrawLine(new Pen(PopupNotifierOld.ContentColor, 2), RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
                _with1.DrawLine(new Pen(PopupNotifierOld.ContentColor, 2), RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
            }
            if (PopupNotifierOld.OptionsButton)
            {
                if (bMouseOnOptions)
                {
                    _with1.FillRectangle(new SolidBrush(PopupNotifierOld.ButtonHoverColor), RectOptions);
                    _with1.DrawRectangle(new Pen(PopupNotifierOld.ButtonBorderColor), RectOptions);
                }
                _with1.FillPolygon(new SolidBrush(ForeColor), new Point[] {
				new Point(RectOptions.Left + 4, RectOptions.Top + 6),
				new Point(RectOptions.Left + 12, RectOptions.Top + 6),
				new Point(RectOptions.Left + 8, RectOptions.Top + 4 + 6)
			});
            }
            if ((PopupNotifierOld.Image != null))
            {
                _with1.DrawImage(PopupNotifierOld.Image, PopupNotifierOld.ImagePosition.X, PopupNotifierOld.ImagePosition.Y, PopupNotifierOld.ImageSize.Width, PopupNotifierOld.ImageSize.Height);
            }
            iHeightOfTitle = (int)_with1.MeasureString("A", PopupNotifierOld.TitleFont).Height;
            int iTitleOrigin = 0;
            if ((PopupNotifierOld.Image != null))
            {
                iTitleOrigin = PopupNotifierOld.ImagePosition.X + PopupNotifierOld.ImageSize.Width + PopupNotifierOld.TextPadding.Left;
            }
            else
            {
                iTitleOrigin = PopupNotifierOld.TextPadding.Left;
            }
            if (bMouseOnLink)
            {
                this.Cursor = Cursors.Hand;
                _with1.DrawString(PopupNotifierOld.ContentText, PopupNotifierOld.ContentFont, new SolidBrush(PopupNotifierOld.LinkHoverColor), RectText);
            }
            else
            {
                this.Cursor = Cursors.Default;
                _with1.DrawString(PopupNotifierOld.ContentText, PopupNotifierOld.ContentFont, new SolidBrush(PopupNotifierOld.ContentColor), RectText);
            }
            _with1.DrawString(PopupNotifierOld.TitleText, PopupNotifierOld.TitleFont, new SolidBrush(PopupNotifierOld.TitleColor), iTitleOrigin, PopupNotifierOld.TextPadding.Top + PopupNotifierOld.HeaderHeight);

        }
        #endregion

    }


}


