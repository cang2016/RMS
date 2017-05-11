using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace RMS.UserControls
{
	public class ColorizedButton: RoundedButton
	{
		int colorizeAmount = 100;
		Color defColor, mOverColor, mDownColor;
		Image oriImage;

		public ColorizedButton()
		{
			mOverColor = Color.White;
			mDownColor = Color.Empty;
		}

		#region Public Properties

		[Category("Effects-Colorize"), DefaultValue(100), Description("The amount of colorization.")]
		public int ColorizeAmount
		{
			get { return colorizeAmount; }
			set
			{
				Common.CheckFor255(value);
				colorizeAmount = value;
				UpdateBackgroundImage(defColor);
			}
		}

		[Category("Effects-Colorize"), Description("The color which the background image should be colorized to.")]
		public Color DefaultColor
		{
			get { return defColor; }
			set { defColor = value; UpdateBackgroundImage(defColor); }
		}

		[Category("Effects-Colorize"), Description("The color which the background image should be colorized to, when the mouse is over the button.")]
		public Color MouseOverColor
		{
			get { return mOverColor; }
			set { mOverColor = value; }
		}

		[Category("Effects-Colorize"),Description("The color which the background image should be colorized to, when the mouse is pressed.")]
		public Color MouseDownColor
		{
			get { return mDownColor; }
			set { mDownColor = value; }
		}

		#endregion

		#region Private Methods

		private void UpdateBackgroundImage(Color colorizeColor)
		{
			if (oriImage == null) return;

			base.BackgroundImage = (Image)oriImage.Clone();

			if (!colorizeColor.IsEmpty)
				Common.ColorizeImage(base.BackgroundImage, colorizeColor, colorizeAmount);

			Refresh();
		}

		#endregion

		#region Overrides

		public new Image BackgroundImage
		{
			get
			{
				return oriImage;
			}
			set
			{
				oriImage = value;
				UpdateBackgroundImage(defColor);
			}
		}

		/*protected override void OnBackgroundImageChanged(EventArgs e)
		{
			base.OnBackgroundImageChanged(e);
			oriImage = (Image)base.BackgroundImage.Clone();
		}*/

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			UpdateBackgroundImage(mOverColor);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			UpdateBackgroundImage(defColor);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			UpdateBackgroundImage(mDownColor);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			UpdateBackgroundImage(mOverColor);
		}

		#endregion
	}
}
