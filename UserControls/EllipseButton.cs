using System;
using System.Drawing;
using System.Windows.Forms;

namespace RMS.UserControls
{
    public partial class EllipseButton : UserControl
    {
        public EllipseButton()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            base.UpdateStyles();
        }

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private Color intBorderColor = Color.Blue;

        /// <summary>
        /// 按钮边框色
        /// </summary>
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(typeof(Color), "Blue")]
        public Color BorderColor
        {
            get
            {
                return intBorderColor;
            }
            set
            {
                intBorderColor = value;
            }
        }

        private Color intButtonBackColor = Color.White;

        /// <summary>
        /// 按钮背景色
        /// </summary>
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(typeof(Color), "Green")]
        public Color ButtonBackColor
        {
            get
            {
                return intButtonBackColor;
            }
            set
            {
                intButtonBackColor = value;
                this.Invalidate();
            }
        }

        private Color intHoverBorderColor = Color.Red;

        /// <summary>
        /// 鼠标悬停在按钮上方时的边框色
        /// </summary>
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(typeof(Color), "Red")]
        public Color HoverBorderColor
        {
            get
            {
                return intHoverBorderColor;
            }
            set
            {
                intHoverBorderColor = value;
            }
        }

        private Color intHoverBackColor = Color.SkyBlue;

        /// <summary>
        /// 鼠标悬停在按钮上方时的背景色
        /// </summary>
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(typeof(Color), "Red")]
        public Color HoverBackColor
        {
            get
            {
                return intHoverBackColor;
            }
            set
            {
                intHoverBackColor = value;
            }
        }

        private string strCaption = null;

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        public string Caption
        {
            get
            {
                return strCaption;
            }
            set
            {
                strCaption = value;
            }
        }

        private string _text;

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        public string MyCaption
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// 鼠标悬停标志
        /// </summary>
        private bool bolMouseHoverFlag = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                // path.AddEllipse(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                path.AddRectangle(new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));

                if (bolMouseHoverFlag)
                {
                    using (SolidBrush b = new SolidBrush(this.HoverBackColor))
                    {
                        e.Graphics.FillPath(b, path);
                    }
                    using (Pen p = new Pen(this.HoverBorderColor))
                    {
                        e.Graphics.DrawPath(p, path);
                    }
                }
                else
                {
                    using (SolidBrush b = new SolidBrush(this.ButtonBackColor))
                    {
                        e.Graphics.FillPath(b, path);
                    }
                    using (Pen p = new Pen(this.BorderColor))
                    {
                        e.Graphics.DrawPath(p, path);
                    }
                }
            }

            //end using

            if (this.MyCaption != null)
            {
                string endStr = null;
                if (this.MyCaption.IndexOf(@"\r\n") > -1)
                {
                    string[] splits = this.MyCaption.Split(new string[] { "\\r\\n" }, StringSplitOptions.RemoveEmptyEntries);

                    this.MyCaption = "";
                    for (int i = 0; i < splits.Length; i++)
                    {
                        if (i == splits.Length - 1)
                        {
                            //this.MyCaption += splits[i];
                            endStr = splits[i];
                        }
                        if (i < splits.Length - 1)
                        {
                            this.MyCaption += splits[i] + System.Environment.NewLine;
                        }
                    }
                }

                using (StringFormat f = new StringFormat())
                {
                    f.Alignment = StringAlignment.Center;
                    f.LineAlignment = StringAlignment.Far;
                    f.FormatFlags = StringFormatFlags.NoWrap;



                    using (SolidBrush b = new SolidBrush(Color.FromArgb(255, 0, 0)))
                    {
                        e.Graphics.DrawString(
                            endStr,
                            this.Font,
                            b,
                            new RectangleF(
                                0,
                                0,
                                this.ClientSize.Width,
                                this.ClientSize.Height
                                ),
                                f
                            );
                    }
                }

                using (StringFormat f = new StringFormat())
                {
                    f.Alignment = StringAlignment.Center;
                    f.LineAlignment = StringAlignment.Center;
                    f.FormatFlags = StringFormatFlags.NoWrap;

                    using (SolidBrush b = new SolidBrush(this.ForeColor))
                    {
                        e.Graphics.DrawString(
                            this.MyCaption,
                            this.Font,
                            b,
                            new RectangleF(
                                0,
                                0,
                                this.ClientSize.Width,
                                this.ClientSize.Height
                                ),
                                f
                            );
                    }
                }
            }
        }

        private bool CheckMouseHover(int x, int y)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(
                     0,
                     0,
                     this.ClientSize.Width - 1,
                     this.ClientSize.Height - 1
                    );

                bool flag = path.IsVisible(x, y);
                if (flag != bolMouseHoverFlag)
                {
                    bolMouseHoverFlag = flag;

                    this.Invalidate();
                }

                return flag; ;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.CheckMouseHover(e.X, e.Y);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.CheckMouseHover(-1, -1);
        }

        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //    Point p = System.Windows.Forms.Control.MousePosition;
        //    p = base.PointToClient(p);

        //    if (CheckMouseHover(p.X, p.Y))
        //    {
        //        base.OnClick(e);
        //    }
        //}

    }
}
