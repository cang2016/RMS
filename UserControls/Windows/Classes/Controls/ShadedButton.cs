using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace RMS.UserControls
{
	public class ShadedButton: RoundedButton
	{
		int light = 150, brightenAmount = 100;
		Color mOverColor, mDownColor;

		public ShadedButton()
		{
			mOverColor = Color.Empty;
			mDownColor = Color.Empty;

			ApplyGradientToImage();
		}

		#region Properties

		[Category("Effects-Shading"), DefaultValue(150), Description("The light amount of the gradient.")]
		public int LightAmount
		{
			get { return light; }
			set { Common.CheckFor255(value);
				light = value; ApplyGradientToImage(); }
		}

		[Category("Effects-Shading"), Description("The back color of the button when the mouse is over the control.")]
		public Color MouseOverBackColor
		{
			get { return mOverColor; }
			set { mOverColor = value; ApplyGradientToImage(); }
		}

		[Category("Effects-Shading"), Description("The back color of the button when the mouse is over the control.")]
		public Color MouseDownBackColor
		{
			get { return mDownColor; }
			set { mDownColor = value; ApplyGradientToImage(); }
		}

		[Category("Effects-Shading"), DefaultValue(100), Description("The brighten amount of the gradient when the mouse is over the button.")]
		public int HotBrightenAmount
		{
			get { return brightenAmount; }
			set { Common.CheckFor255(value);
				brightenAmount = value; ApplyGradientToImage();
		}
		}

		#endregion

		private void ApplyGradientToImage(bool invertDirection, Color color, int bright)
		{
			Image img = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(img);

			Color downColor, upColor;
			if (color.IsEmpty) color = this.BackColor;

			if (invertDirection)
			{
				upColor = Common.BrightenColor(color, -20);
				downColor = Common.BrightenColor(upColor, light);
			}
			else
			{
				downColor = color;
				upColor = Common.BrightenColor(downColor, light);
			}

			LinearGradientBrush brush;
			brush = new LinearGradientBrush(this.ClientRectangle, upColor, downColor, LinearGradientMode.Vertical);

			g.FillRectangle(brush, 0, 0, Width, Height);
			Common.ColorizeImage(img, Color.White, bright);

			base.BackgroundImage = img;
		}

		private void ApplyGradientToImage()
		{ ApplyGradientToImage(false, this.BackColor, 0); }


		#region Overrides

        //[Browsable(true)]
        //public  Image BackgroundImage
        //{
        //    get;
        //    set;
        //}

        //[Browsable(true)]
        //public  ImageLayout BackgroundImageLayout
        //{
        //    get;
        //    set;
        //}

		[Browsable(false)]
		public new FlatButtonAppearance FlatAppearance
		{
			get
			{
				FlatButtonAppearance app = base.FlatAppearance;
				app.BorderSize = 0;
				app.BorderColor = Color.Empty;
				app.MouseDownBackColor = Color.Empty;
				app.MouseOverBackColor = Color.Empty;
				return app;
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			ApplyGradientToImage(false, mOverColor, brightenAmount);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			ApplyGradientToImage();
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			ApplyGradientToImage(true, mDownColor, brightenAmount);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			ApplyGradientToImage(false, mOverColor, brightenAmount);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ApplyGradientToImage();
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			ApplyGradientToImage();
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			ApplyGradientToImage();
		}

		#endregion
	}
}
