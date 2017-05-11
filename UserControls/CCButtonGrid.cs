namespace RMS.UserControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CCButtonGrid : UserControl
    {
        static RoundedButton[] _btnCollection = null;

        //Panel[] panelCollection = null;
        public CCButtonGrid()
        {
            InitializeComponent();
        }

        private int _mCount = 1;

        /// <summary>
        /// 按钮数量
        /// </summary>
        public int Count
        {
            get
            {
                return _mCount;
            }
            set
            {
                _mCount = value;
            }
        }

        private int m_rows;
        /// <summary>
        /// 行数
        /// </summary>
        public int Rows
        {
            get
            {
                return m_rows;
            }
            set
            {
                m_rows = value;
            }
        }

        private int m_cols;
        /// <summary>
        /// 列数
        /// </summary>
        public int Cols
        {
            get
            {
                return m_cols;
            }
            set
            {
                m_cols = value;
            }
        }

        private int m_rowMargin;
        /// <summary>
        /// 行距
        /// </summary>
        public int RowMargin
        {
            get
            {
                return m_rowMargin;
            }
            set
            {
                m_rowMargin = value;
            }
        }

        private int m_colMargin;
        /// <summary>
        /// 列距
        /// </summary>
        public int ColMargin
        {
            get
            {
                return m_colMargin;
            }
            set
            {
                m_colMargin = value;
            }
        }

        public void SetBtnHeight(int height)
        {
            foreach(Control ctl in this.Controls)
            {
                if(ctl is RoundedButton)
                {
                    (ctl as RoundedButton).Height = height;
                }
            }
        }

        public void SetBtnWeight(int width)
        {
            foreach(Control ctl in this.Controls)
            {
                if(ctl is RoundedButton)
                {
                    (ctl as RoundedButton).Width = width;
                }
            }
        }

        /// <summary>
        /// /设置字体大小
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetBtnFontSize(float fontSize)
        {
            Font font = new Font("宋体", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.roundedButton1.Font = Font;
        }

        /// <summary>
        /// 设置字体名称
        /// </summary>
        /// <param name="name"></param>
        public void SetBtnFontName(string name)
        {
            Font font = new Font(name, 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.roundedButton1.Font = Font;
        }

        /// <summary>
        /// 设置按钮文本
        /// </summary>
        /// <param name="index"></param>
        /// <param name="caption"></param>
        public void SetBtnText(int index, string caption)
        {
            //btnCollection[index] = this.RoundedButton1;
            //btnCollection[index].Text = caption;
            _btnCollection[index].Text = caption;

        }

        public void SetBtnId(int index, int id)
        {
            _btnCollection[index].Tag = id;
        }

        /// <summary>
        /// 设置按钮是否可见
        /// </summary>
        /// <param name="index"></param>
        /// <param name="visual"></param>
        public void SetBtnVisual(int index, bool visual)
        {
            //btnCollection[index] = this.RoundedButton1;
            _btnCollection[index].Visible = visual;
        }

        /// <summary>
        /// 设置按钮的背景色
        /// </summary>
        /// <param name="index"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public void SetBtnColr(int index, int red, int green, int blue)
        {
            //btnCollection[index] = this.RoundedButton1;
            _btnCollection[index].BackColor = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// 设置按钮的背景色
        /// </summary>
        /// <param name="index"></param>
        /// <param name="color"></param>
        public void SetBtnColr(int index, Color color)
        {
            //btnCollection[index] = this.RoundedButton1;
            _btnCollection[index].BackColor = color;
        }

        /// <summary>
        /// 设置按钮的背景色
        /// </summary>
        /// <param name="index"></param>
        /// <param name="color"></param>
        public void SetBtnImage(int index, String imagePath)
        {
            //btnCollection[index] = this.RoundedButton1;
            _btnCollection[index].BackgroundImage = Image.FromFile(imagePath);
        }

        public void RefreshBtn()
        {
            Count = Cols * Rows;
            _btnCollection = new RoundedButton[Count];
            //panelCollection = new Panel[Count];
            //int currTop = 10;
            //int currLeft = 20;
            for(int i = 0; i < Rows; i++)
            {
                int currTop = this.roundedButton1.Top + i * (this.roundedButton1.Height + RowMargin);
                for(int j = 0; j < Cols; j++)
                {

                    //panelCollection[i * Cols + j] = new Panel();
                    _btnCollection[i * Cols + j] = new RoundedButton();

                    //panelCollection[i * Cols + j].Controls.Add(btnCollection[i * Cols + j]);

                    //panelCollection[i * Cols + j].Left = this.panel1.Left + j * (this.panel1.Width + ColMargin);
                    //panelCollection[i * Cols + j].Top = currTop;
                    _btnCollection[i * Cols + j].Left = this.roundedButton1.Left + j * (this.roundedButton1.Width + ColMargin);

                    _btnCollection[i * Cols + j].Top = currTop;

                    _btnCollection[i * Cols + j].Size = this.roundedButton1.Size;
                    //panelCollection[i * Cols + j].Size = this.panel1.Size;
                    _btnCollection[i * Cols + j].Name = "CC" + (i * Cols + j).ToString();
                    //panelCollection[i * Cols + j].Name = "pp" + (i * Cols + j).ToString();
                    _btnCollection[i * Cols + j].BackColor = System.Drawing.Color.Azure;
                    _btnCollection[i * Cols + j].BorderColor = System.Drawing.Color.BlueViolet;
                    //panelCollection[i * Cols + j].BackColor = panel1.BackColor;
                    //panelCollection[i * Cols + j].BorderStyle = panel1.BorderStyle;
                    _btnCollection[i * Cols + j].TextAlign = this.roundedButton1.TextAlign;
                    _btnCollection[i * Cols + j].ImageAlign = this.roundedButton1.ImageAlign;
                    _btnCollection[i * Cols + j].BackgroundImageLayout = this.roundedButton1.BackgroundImageLayout;
                    _btnCollection[i * Cols + j].Roundness = this.roundedButton1.Roundness;
                    _btnCollection[i * Cols + j].BorderWidth = this.roundedButton1.BorderWidth;

                    _btnCollection[i * Cols + j].Click += BtnClickEvent;
                    //panelCollection[i * Cols + j].Click += BtnClickEvent;


                    _btnCollection[i * Cols + j].MouseHover += roundedButton1_MouseHover;
                    _btnCollection[i * Cols + j].MouseLeave += roundedButton1_MouseLeave;
                    _btnCollection[i * Cols + j].DoubleClick += BtnDoubleClickEvent;


                    _btnCollection[i * Cols + j].Font = this.roundedButton1.Font;
                    //panelCollection[i * Cols + j].Controls.Add(btnCollection[i * Cols + j]);
                    //panelCollection[i * Cols + j].Controls.Add(lblCollection[i * Cols + j]);
                    //btnCollection[i * Cols + j].Refresh();
                    //this.Controls.Add(panelCollection[i * Cols + j]);
                    this.Controls.Add(_btnCollection[i * Cols + j]);
                    //this.Controls.Add(lblCollection[i * Cols + j]);
                }
            }
        }

        #region 定义按钮点击事件

        public class MyClickEventArgs : EventArgs
        {
            public int ClickId { get; set; }

            public MyClickEventArgs(int clickId)
            {
                ClickId = clickId;
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_MouseHover(object sender, EventArgs e)
        {
            RoundedButton rb = sender as RoundedButton;
            timer1.Enabled = true;
            if(rb != null)
            {
                contextMenuStrip1.BackColor = rb.BackColor;

                //if(rb.Location.Y - Cursor.Position.Y < contextMenuStrip1.Height)
                //{
                //    contextMenuStrip1.Hide();
                //    contextMenuStrip1.Visible = false;
                //}

                contextMenuStrip1.Opacity = 1;
                if(contextMenuStrip1 == null)
                {
                    contextMenuStrip1 = new ContextMenuStrip();
                }
                this.contextMenuStrip1.Visible = true;
                this.contextMenuStrip1.Items.Add(Convert.ToString(rb.Tag));
                contextMenuStrip1.BackColor = Color.White;
                contextMenuStrip1.Show(sender as Control, 17, 0);
            }
        }

        private void roundedButton1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            RoundedButton rb = sender as RoundedButton;
            if(this.contextMenuStrip1.Items != null && this.contextMenuStrip1.Items.Count > 0)
            {
                contextMenuStrip1.Opacity = 0;
                this.contextMenuStrip1.Items.Clear();
                this.contextMenuStrip1.Visible = false;
                //this.contextMenuStrip1.Dispose();
                //this.contextMenuStrip1.Items.Add(rb.Tag.ToString());
                //contextMenuStrip1.Show(sender as Control, 10, 10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contextMenuStrip1.Opacity -= 0.2;
            if(Math.Abs(contextMenuStrip1.Opacity) <= 0)
            {
                contextMenuStrip1.Visible = false;
            }
        }

        public event EventHandler BtnClickEvent;
        public event EventHandler BtnDoubleClickEvent;

        #endregion


    }
}
