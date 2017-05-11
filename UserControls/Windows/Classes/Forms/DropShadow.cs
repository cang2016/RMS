using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace RMS.UserControls
{
	/// <summary>
	/// A window that resembles a drop shadow. This window can be attached to another window
	/// by the Attach() method, to mimic a drop shadow on the parent window.
	/// Original version from Kasun Chandranath.
	/// Modified by Ravin Perera.
	/// </summary>
	public class DropShadow : Form
	{
		Bitmap contentImage;
		Bitmap completeImage;
		GraphicsPath outerPath;

		Form parentWindow;
		ShadowInfo shadowInfo = new ShadowInfo();
        public DropShadow()
        {

        }
		public DropShadow(Form parent)
		{
			this.parentWindow = parent;

			ShowInTaskbar = false;
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);		// WmPaint calls OnPaint and OnPaintBackground
			SetStyle(ControlStyles.DoubleBuffer, true);
		}

		#region Public Properties

		public ShadowInfo ShadowInfo
		{
			get { return shadowInfo; }
			set { shadowInfo = value; }
		}

		#endregion

		#region Public Methods

		public new void Show()
		{
			base.Show();

			this.Location = parentWindow.Location;

			parentWindow.Move += new EventHandler(parentWindow_Move);
			parentWindow.Resize += new EventHandler(parentWindow_Resize);
			parentWindow.Activated += new EventHandler(parentWindow_Activated);

			SetFormLocation();
			parentWindow.Activate();
		}

		public void RefreshShadow()
		{
			Rectangle shadowRect = GetShadowRect();
			DrawWindow(shadowRect.Left, shadowRect.Top, shadowRect.Width, shadowRect.Height);
		}

		#endregion

		#region Parent window event handlers

		void parentWindow_Move(object sender, EventArgs e)
		{
			SetFormLocation();
		}

		void parentWindow_Resize(object sender, EventArgs e)
		{
			SetFormLocation();
		}

		void parentWindow_Activated(object sender, EventArgs e)
		{
			SetFormLocation();
		}

		#endregion

		#region Private methods

		private Rectangle GetShadowRect()
		{
			int left = parentWindow.Left - shadowInfo.ShadowSize + shadowInfo.ShadowDistance;
			int top = parentWindow.Top - shadowInfo.ShadowSize + shadowInfo.ShadowDistance;
			int width = parentWindow.Width + shadowInfo.ShadowSize * 1;
			int height = parentWindow.Height + shadowInfo.ShadowSize * 1;

			return new Rectangle(left, top, width, height);
		}

		private void SetFormLocation()
		{
			Rectangle rect = GetShadowRect();

			Win32.SetWindowPos(
					this.Handle, parentWindow.Handle,
					rect.Left, rect.Top,
					 rect.Width, rect.Height, Win32.SWP_NOACTIVATE);

			DrawWindow(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		private void DrawWindow(int x, int y, int width, int height)
		{
			byte opacity = 255;

			DrawContentImage(width, height, shadowInfo.ShadowSize * 2, shadowInfo.ShadowRoundness);
			DrawCompleteImage();

			Bitmap bitmap = DrawCompleteImage();

			IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
			IntPtr memDc = Win32.CreateCompatibleDC(screenDc);

			IntPtr hBitmap = IntPtr.Zero;
			IntPtr oldBitmap = IntPtr.Zero;

			try
			{
				hBitmap = bitmap.GetHbitmap(Color.FromArgb(6));  // grab a GDI handle from this GDI+ bitmap
				oldBitmap = Win32.SelectObject(memDc, hBitmap);

				Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
				Win32.Point pointSource = new Win32.Point(0, 0);
				Win32.Point topPos = new Win32.Point(x, y);
				Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
				blend.BlendOp = Win32.AC_SRC_OVER;
				blend.BlendFlags = 0;
				blend.SourceConstantAlpha = opacity;
				blend.AlphaFormat = Win32.AC_SRC_ALPHA;

				Win32.UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
			}
			finally
			{
				Win32.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero)
				{
					Win32.SelectObject(memDc, oldBitmap);
					Win32.DeleteObject(hBitmap);
				}
				Win32.DeleteDC(memDc);
			}
		}

		private void DrawContentImage(int width, int height, int thickness, int roundness)
		{
			float widthf = (float)width;
			float heightf = (float)height;
			float thicknessf = (float)thickness;

			Bitmap img = new Bitmap(width, height);
			Graphics grfx = Graphics.FromImage(img);
			outerPath = Common.CreateRoundedRectangle(roundness, new RectangleF(0f, 0f, widthf, heightf));
			PathGradientBrush backStyle = new PathGradientBrush(outerPath);

			backStyle.CenterPoint = new PointF(widthf / 2f, heightf / 2f);
			backStyle.CenterColor = Color.FromArgb(shadowInfo.ShadowBeginOpacity, shadowInfo.ShadowBeginColor);

			backStyle.SurroundColors =
				new Color[] { Color.FromArgb(shadowInfo.ShadowEndOpacity, shadowInfo.ShadowEndColor) };

			backStyle.FocusScales = new PointF(1f - thicknessf / widthf, 1f - thicknessf / heightf);
			
			grfx.FillPath(backStyle, outerPath);

			grfx.Dispose();

			contentImage = new Bitmap(img);

			img.Dispose();
			grfx.Dispose();

		}

		private Bitmap DrawCompleteImage()
		{
			Bitmap img = new Bitmap(contentImage);
			Graphics grfx = Graphics.FromImage(img);

			completeImage = img;
			grfx.Dispose();

			return img;
		}

		#endregion

		#region Protected overrided mathods

		protected override void OnClosing(CancelEventArgs e)
		{
			//This window can't be closed manually. It will automatically be
			//disposed when the parent window is closed.
			e.Cancel = true;
		}

		protected override void Dispose(bool disposing)
		{
			parentWindow.Move -= new EventHandler(parentWindow_Move);
			parentWindow.Resize -= new EventHandler(parentWindow_Resize);
			parentWindow.Activated -= new EventHandler(parentWindow_Activated);

			this.parentWindow = null;

			base.Dispose(disposing);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
				cp.ExStyle |= 0x20;	// Set WS_EX_TRANSPARENT flag. This will ignore input events
				return cp;
			}
		}

		#endregion
	}

	/// <summary>
	/// This class holds information needed for a shadow object.
	/// </summary>
	public class ShadowInfo
	{
		int shadowDistance = 10;
		int shadowSize = 20;
		int shadowRoundness = 40;

		int shadowBeginOpacity = 200;
		Color shadowBeginColor = Color.Black;
		int shadowEndOpacity = 0;
		Color shadowEndColor = Color.Black;

		public ShadowInfo()
		{
		}

		public ShadowInfo(int distance, int size, int roundness,
					Color beginColor, int beginOpacity, Color endColor, int endOpacity)
		{
			shadowDistance = distance;
			shadowSize = size;
			shadowRoundness = roundness;

			shadowBeginColor = beginColor;
			shadowBeginOpacity = beginOpacity;
			shadowEndColor = endColor;
			shadowEndOpacity = endOpacity;
		}

		#region Public Properties

		public int ShadowDistance
		{
			get { return shadowDistance; }
			set { shadowDistance = value; }
		}

		public int ShadowSize
		{
			get { return shadowSize; }
			set { shadowSize = value; }
		}

		public int ShadowRoundness
		{
			get { return shadowRoundness; }
			set { shadowRoundness = value; }
		}

		public int ShadowBeginOpacity
		{
			get { return shadowBeginOpacity; }
			set { shadowBeginOpacity = value; }
		}

		public int ShadowEndOpacity
		{
			get { return shadowEndOpacity; }
			set { shadowEndOpacity = value; }
		}

		public Color ShadowBeginColor
		{
			get { return shadowBeginColor; }
			set { shadowBeginColor = value; }
		}

		public Color ShadowEndColor
		{
			get { return shadowEndColor; }
			set { shadowEndColor = value; }
		}

		#endregion
	}
}
