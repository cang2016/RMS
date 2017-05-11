namespace RMS.UserControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DishCard : UserControl
    {
        private int _dishid = 0;
        private string _dishName = "";
        private Color _dishNameBGColor = Color.Red;
        private Color _dishPriceBGColor = Color.Beige;
        private int _dispID = 0;
        private string _dispType = "";
        private int _isgq = 0;
        private int _issetmeal = 0;
        private int _moid = 0;
        private bool _pEnabled = true;
        private string _price = "";
        private string _spec = "";
        private Container components = null;
        public MyLabel lblDishName;
        public MyLabel lblPrice;
        private MyPanel pnlDishName;
        private MyPanel pnlPrice;

        public DishCard()
        {
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            base.UpdateStyles();
            this.InitializeComponent();
        }

        private void DishCard_Load(object sender, EventArgs e)
        {
        }

        private void DishCard_Resize(object sender, EventArgs e)
        {
            this.pnlDishName.Left = 0;
            this.pnlDishName.Top = 0;
            this.pnlDishName.Height = (base.Height + 1) - this.pnlPrice.Height;
            this.pnlDishName.Width = base.Width;
        }

        private void dishNameChanged()
        {
            this.lblDishName.Text = this._dishName;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void enabledChange()
        {
            if (!this._pEnabled)
            {
                this.lblDishName.ForeColor = Color.Gray;
                this.lblPrice.ForeColor = Color.Gray;
            }
            else
            {
                this.lblDishName.ForeColor = Color.Beige;
                this.lblPrice.ForeColor = Color.Beige;
            }
        }

        public void init()
        {
            this.DishId = 0;
            this.MOID = 0;
            this.DishName = "";
            this.Price = "";
            this.dispType = "";
            this.dispID = 0;
            this.DishNameBGColor = Color.FromArgb(0,92, 50, 50);
            this.DishPriceBGColor = Color.FromArgb(93, 108, 179);

            this.issetmeal = 0;
        }

        private void InitializeComponent()
        {
            this.pnlPrice = new MyPanel();
            this.lblPrice = new MyLabel();
            this.pnlDishName = new MyPanel();
            this.lblDishName = new MyLabel();
            this.pnlPrice.SuspendLayout();
            this.pnlDishName.SuspendLayout();
            base.SuspendLayout();
            this.pnlPrice.BackColor = Color.IndianRed;
            this.pnlPrice.BorderStyle = BorderStyle.FixedSingle;
            this.pnlPrice.Controls.Add(this.lblPrice);
            this.pnlPrice.Dock = DockStyle.Bottom;
            this.pnlPrice.Location = new Point(0, 0x178);
            this.pnlPrice.Name = "pnlPrice";
            this.pnlPrice.Size = new Size(480, 0x10);
            this.pnlPrice.TabIndex = 0;
            this.pnlPrice.Tag = "";
            this.lblPrice.Dock = DockStyle.Fill;
            this.lblPrice.Location = new Point(0, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(0x1de, 14);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Tag = "-9999";
            this.lblPrice.Text = "label1";
            this.lblPrice.TextAlign = ContentAlignment.BottomCenter;
            this.pnlDishName.BackColor = Color.FloralWhite;
            this.pnlDishName.BorderStyle = BorderStyle.FixedSingle;
            this.pnlDishName.Controls.Add(this.lblDishName);
            this.pnlDishName.Location = new Point(0, 0);
            this.pnlDishName.Name = "pnlDishName";
            this.pnlDishName.Size = new Size(0x1a0, 0x120);
            this.pnlDishName.TabIndex = 1;
            this.pnlDishName.Tag = "";
            this.lblDishName.BackColor = Color.Transparent;
            this.lblDishName.Dock = DockStyle.Fill;
            this.lblDishName.Location = new Point(0, 0);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new Size(0x19e, 0x11e);
            this.lblDishName.TabIndex = 0;
            this.lblDishName.Tag = "-9999";
            this.lblDishName.Text = "dsfadsfasdfsa";
            this.lblDishName.TextAlign = ContentAlignment.MiddleCenter;
            this.BackColor = SystemColors.Control;
            base.Controls.Add(this.pnlDishName);
            base.Controls.Add(this.pnlPrice);
            base.Name = "DishCard";
            base.Size = new Size(480, 0x188);
            base.Resize += new EventHandler(this.DishCard_Resize);
            base.Load += new EventHandler(this.DishCard_Load);
            this.pnlPrice.ResumeLayout(false);
            this.pnlDishName.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        // Add by xucj @2012-05-13
        private string m_Class;

        public string Class
        {
            get { return m_Class; }
            set { m_Class = value; }
        }

        private string m_Code;

        public string Code
        {
            get { return m_Code; }
            set { m_Code = value; }
        }

        private string m_MoName;

        public string MoName
        {
            get { return m_MoName; }
            set { m_MoName = value; }
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

        // End

        private void priceChanged()
        {
            if (!this._spec.Equals(""))
            {
                this.lblPrice.Text = this._price + "[" + this._spec + "]";
            }
            else
            {
                this.lblPrice.Text = this._price;
            }
        }

        public int DishId
        {
            get
            {
                return this._dishid;
            }
            set
            {
                this._dishid = value;
            }
        }

        public string DishName
        {
            get
            {
                return this._dishName;
            }
            set
            {
                this._dishName = value;
                this.dishNameChanged();
            }
        }

        public Color DishNameBGColor
        {
            get
            {
                return this._dishNameBGColor;
            }
            set
            {
                this._dishNameBGColor = value;
                this.pnlDishName.BackColor = this._dishNameBGColor;
            }
        }

        public Color DishPriceBGColor
        {
            get
            {
                return this._dishPriceBGColor;
            }
            set
            {
                this._dishPriceBGColor = value;
                this.pnlPrice.BackColor = this._dishPriceBGColor;
            }
        }

        public int dispID
        {
            get
            {
                return this._dispID;
            }
            set
            {
                this._dispID = value;
            }
        }

        public string dispType
        {
            get
            {
                return this._dispType;
            }
            set
            {
                this._dispType = value;
            }
        }

        public int isgq
        {
            get
            {
                return this._isgq;
            }
            set
            {
                this._isgq = value;
                this.PEnabled = this._isgq == 0;
            }
        }

        public int issetmeal
        {
            get
            {
                return this._issetmeal;
            }
            set
            {
                this._issetmeal = value;
            }
        }

        public int MOID
        {
            get
            {
                return this._moid;
            }
            set
            {
                this._moid = value;
            }
        }

        public bool PEnabled
        {
            get
            {
                return this._pEnabled;
            }
            set
            {
                this._pEnabled = value;
                this.enabledChange();
            }
        }

        public string Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
                this.priceChanged();
            }
        }

        public string Spec
        {
            get
            {
                return this._spec;
            }
            set
            {
                this._spec = value;
                this.priceChanged();
            }
        }

        public class MyLabel : Label
        {
            public MyLabel()
            {
                base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
                base.UpdateStyles();
            }
        }

        public class MyPanel : Panel
        {
            public MyPanel()
            {
                base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
                base.UpdateStyles();
            }
        }

        private bool bolMouseHoverFlag = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

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
                    using (SolidBrush b = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(b, path);
                    }
                }
            }
        }
    }
}

