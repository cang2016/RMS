using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace RMS.UserControls
{
	/// <summary>
	/// A Form that has rounded corners.
	/// </summary>
	public class RoundedForm : ShadowedForm
	{
		int roundness = 10, titleBarHeight = 30, buttonHeight = 18;
		float borderWidth = 1;
		Color titleBarColor;

		Point mouseOffset;
		bool isMouseDown = false;

		Label lblTitle;
		Panel pnlTitleBar, pnlButtons;
		ShadedButton cmdClose, cmdMaximize, cmdMinimize;
		PictureBox picIcon;
		Image maxImage1, maxImage2, minImage, closeImage;
        Color buttonIconColor, borderColor;
		
		public RoundedForm()
		{
			CreateButtonIcons();
			InitializeControls();

			borderColor = Color.FromKnownColor(KnownColor.ControlDark);
			SetRegion(this, roundness);
		}

		#region Private Methods

		private void CreateButtonIcons()
		{
			buttonIconColor = Color.Black;
			Pen buttonPen = new Pen(buttonIconColor, 1.75f);

			maxImage1 = new Bitmap(10, 10);
			Graphics g = Graphics.FromImage(maxImage1);
			g.DrawRectangle(buttonPen, 1, 1, maxImage1.Width - 2, maxImage1.Height - 2);

			maxImage2 = new Bitmap(12, 12);
			g = Graphics.FromImage(maxImage2);
			g.DrawRectangle(buttonPen, 1, 1, 6, 6);
			g.DrawRectangle(buttonPen, 5, 5, 6, 6);

			buttonPen.Width = 2f;

			minImage = new Bitmap(7, 10);
			g = Graphics.FromImage(minImage);
			g.DrawLine(buttonPen, 0, 8, minImage.Width, 8);

			closeImage = new Bitmap(8, 8);
			g = Graphics.FromImage(closeImage);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawLine(buttonPen, 0, 0, closeImage.Width-1, closeImage.Height-1);
			g.DrawLine(buttonPen, closeImage.Width-1, 0, 0, closeImage.Height-1);
		}

		private void InitializeControls()
		{
			lblTitle = new Label();
			pnlTitleBar = new Panel();
			pnlButtons = new Panel();
			cmdClose = new ShadedButton();
			cmdMaximize = new ShadedButton();
			cmdMinimize = new ShadedButton();
			picIcon = new PictureBox();

			picIcon.Image = Icon.ToBitmap();
			StartPosition = FormStartPosition.CenterScreen;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			TitleBarForeColor = Color.White;
			TitleBarColor = Color.RoyalBlue;
			BackgroundImageLayout = ImageLayout.Stretch;

			#region Buttons

			cmdMinimize.Image = minImage;
			cmdMinimize.BackColor = Color.LightGreen;
			cmdMinimize.BorderWidth = 0;
			cmdMinimize.LightAmount = 90;
			cmdMinimize.ShowMouseDownBorder = false;
			cmdMinimize.ShowMouseOverBorder = false;
			cmdMinimize.Size = new Size(20, buttonHeight);
			cmdMinimize.Left = 0;
			cmdMinimize.Roundness = 0;
			cmdMinimize.TabStop = false;

			cmdMaximize.Image = maxImage1;
			cmdMaximize.BackColor = Color.Orange;
			cmdMaximize.BorderWidth = 0;
			cmdMaximize.ShowMouseDownBorder = false;
			cmdMaximize.ShowMouseOverBorder = false;
			cmdMaximize.Size = new Size(20, buttonHeight);
			cmdMaximize.Left = cmdMinimize.Left + cmdMinimize.Width;
			cmdMaximize.Roundness = 0;
			cmdMaximize.TabStop = false;

			cmdClose.Image = closeImage;
			cmdClose.BackColor = Color.Crimson;
			cmdClose.BorderWidth = 0;
			cmdClose.ShowMouseDownBorder = false;
			cmdClose.ShowMouseOverBorder = false;
			cmdClose.Font = new Font(cmdClose.Font, FontStyle.Bold);
			cmdClose.ForeColor = Color.Black;
			cmdClose.Size = new Size(20, buttonHeight);
			cmdClose.Left = cmdMaximize.Left + cmdMaximize.Width;
			cmdClose.Roundness = 0;
			cmdClose.TabStop = false;

			#region Button Panel

			pnlButtons.Height = buttonHeight;
			pnlButtons.Width = cmdMinimize.Width + cmdMaximize.Width + cmdClose.Width;
			pnlButtons.Top = 6;
			SetRegion(pnlButtons, 10);
			pnlButtons.Controls.Add(cmdClose);
			pnlButtons.Controls.Add(cmdMaximize);
			pnlButtons.Controls.Add(cmdMinimize);

			#endregion

			#endregion

			#region Title Bar

			picIcon.Location = new Point(10, 5);
			picIcon.BackColor = Color.Transparent;
			picIcon.Size = new Size(20, 20);
			picIcon.SizeMode = PictureBoxSizeMode.Zoom;
			picIcon.Image = Icon.ToBitmap();

			lblTitle.Font = new Font("Trebuchet MS", 10, FontStyle.Bold);
			lblTitle.TextAlign = ContentAlignment.MiddleCenter;
			lblTitle.BackColor = Color.Transparent;
			lblTitle.Dock = DockStyle.Fill;

			pnlTitleBar.Height = titleBarHeight;
			pnlTitleBar.BackgroundImageLayout = ImageLayout.Stretch;
			pnlTitleBar.Dock = DockStyle.Top;
			pnlTitleBar.Controls.Add(pnlButtons);
			pnlTitleBar.Controls.Add(picIcon);
			pnlTitleBar.Controls.Add(lblTitle);
			pnlTitleBar.Paint += new PaintEventHandler(pnlTitleBar_Paint);

			#endregion

			#region Event Handlers

			cmdClose.Click += new EventHandler(cmdClose_Click);
			cmdClose.GotFocus += new EventHandler(cmdClose_GotFocus);
			cmdMinimize.Click += new EventHandler(cmdMinimize_Click);
			cmdMinimize.GotFocus += new EventHandler(cmdMinimize_GotFocus);
			cmdMaximize.Click += new EventHandler(cmdMaximize_Click);
			cmdMaximize.GotFocus += new EventHandler(cmdMaximize_GotFocus);

			lblTitle.DoubleClick += new EventHandler(lblTitle_DoubleClick);
			lblTitle.MouseDown += new MouseEventHandler(lbl_MouseDown);
			lblTitle.MouseMove += new MouseEventHandler(lbl_MouseMove);
			lblTitle.MouseUp += new MouseEventHandler(lbl_MouseUp);

			#endregion

			Controls.Add(pnlTitleBar);
		}

		private void SetRegion(Control ctrl, int roundness)
		{
			ctrl.Region = new Region(Common.CreateRoundedRectangle(roundness, ctrl.ClientRectangle));
		}

		private void DrawBorder(Graphics g, int roundness, RectangleF rect)
		{
			if (borderWidth > 0)
				g.DrawPath(new Pen(borderColor, borderWidth), Common.CreateRoundedRectangle(roundness, rect, .4f));
		}

		void pnlTitleBar_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			if (this.WindowState != FormWindowState.Maximized)
			{
				DrawBorder(e.Graphics, roundness, this.ClientRectangle);
				cmdMaximize.Image = maxImage1;
			}
			else
				cmdMaximize.Image = maxImage2;
		}

		#endregion

		#region Public Properties

		[Category("Effects"), DefaultValue(10), Description("Roundness of the corners of the form.")]
		public int Roundness
		{
			get { return roundness; }
			set
			{
				if (value < 0 && value > 100)
					throw new ArgumentOutOfRangeException("Roundness", "Value must be within 0 and 100.");

				roundness = value;
				SetRegion(this, roundness);
			}
		}

		[Category("Effects"), Description("Color of the form border.")]
		public Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; Refresh(); }
		}

		[Category("Effects"), DefaultValue(1), Description("Width of the form border.")]
		public float BorderWidth
		{
			get { return borderWidth; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("BorderWidth", "Value must be a positive value.");

				borderWidth = value;
				Refresh();
			}
		}

		[Category("Effects"), Description("Back color of the title bar of the form.")]
		public Color TitleBarColor
		{
			get { return titleBarColor; }
			set
			{
				titleBarColor = value;
				pnlTitleBar.BackColor=value;
			}
		}

		[Category("Effects"), Description("Text color of the title bar of the form.")]
		public Color TitleBarForeColor
		{
			get { return lblTitle.ForeColor; }
			set { lblTitle.ForeColor = value; }
		}

		[Category("Effects"), Description("Background image of the title bar of the form.")]
		public Image TitleBarImage
		{
			get { return pnlTitleBar.BackgroundImage; }
			set { pnlTitleBar.BackgroundImage = value; }
		}

		[Category("Effects"), Description("Background image layout of the title bar of the form.")]
		public ImageLayout TitleBarImageLayout
		{
			get { return pnlTitleBar.BackgroundImageLayout; }
			set { pnlTitleBar.BackgroundImageLayout = value; }
		}

		#endregion

		#region OVERRIDES

		[Browsable(false)]
		public new System.Windows.Forms.FormBorderStyle FormBorderStyle
		{
			get { return System.Windows.Forms.FormBorderStyle.None; }
			set { }
		}

		public override string Text
		{
			get {return base.Text;}
			set
			{
				base.Text = value;
				lblTitle.Text = value + "       ";
			}
		}

		public override Color ForeColor
		{
			get {return base.ForeColor;}
			set
			{
				base.ForeColor = value;
				lblTitle.ForeColor = value;
			}
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			pnlTitleBar.BackColor = titleBarColor;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			pnlButtons.Left = Width - pnlButtons.Width - 4;

			if (this.WindowState != FormWindowState.Maximized)
				SetRegion(this, roundness);
			else
				SetRegion(this, 0);
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			if (this.WindowState != FormWindowState.Maximized)
				DrawBorder(e.Graphics, roundness, this.ClientRectangle);
		}
		
		#endregion

		#region Mouse Move Events

		void lbl_MouseDown(object sender, MouseEventArgs e)
		{
			int xOffset;
			int yOffset;

			if (e.Button == MouseButtons.Left)
			{
				xOffset = -e.X;
				yOffset = -e.Y;
				mouseOffset = new Point(xOffset, yOffset);
				isMouseDown = true;
			}
		}

		void lbl_MouseMove(object sender, MouseEventArgs e)
		{
			if (isMouseDown)
			{
				Point mousePos = Control.MousePosition;
				mousePos.Offset(mouseOffset.X, mouseOffset.Y);
				this.Location = mousePos;
			}
		}

		void lbl_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				isMouseDown = false;
		}

		#endregion

		#region Button Events

		void lblTitle_DoubleClick(object sender, EventArgs e)
		{
			cmdMaximize_Click(sender, e);
		}

		void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		void cmdClose_GotFocus(object sender, EventArgs e)
		{
			this.Select(true, false);
		}

		void cmdMaximize_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				//this.SetRegion(this, roundness);
			}
			else
			{
				this.WindowState = FormWindowState.Maximized;
				//this.SetRegion(this, 0);
			}
		}

		void cmdMaximize_GotFocus(object sender, EventArgs e)
		{
			this.Select(true, false);
		}

		void cmdMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		void cmdMinimize_GotFocus(object sender, EventArgs e)
		{
			this.Select(true, false);
		}

		#endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundedForm
            // 
            this.ClientSize = new System.Drawing.Size(887, 606);
            this.MaximizeBox = false;
            this.Name = "RoundedForm";
            this.ResumeLayout(false);

        }
	}
}
