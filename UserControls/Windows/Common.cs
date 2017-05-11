using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RMS.UserControls
{
	static class Common
	{
		public static Color BrightenColor(Color color, int amount)
		{
			Color col = color;

			if (amount > 0)
			{
				int lim = 255 - amount;

				col = Color.FromArgb(
					(color.R <= lim) ? color.R + amount : 255, (color.G <= lim) ? color.G + amount : 255,
					(color.B <= lim) ? color.B + amount : 255);
			}
			else if (amount < 0)
			{
				int lim = amount * -1;

				col = Color.FromArgb(
					(color.R >= lim) ? color.R + amount : 0, (color.G >= lim) ? color.G + amount : 0,
					(color.B >= lim) ? color.B + amount : 0);
			}

			return col;
		}

		public static Image ColorizeImage(Image img, Color color, int amount)
		{
			if (amount <= 0 || color == Color.Empty || img ==null) return img;

			Graphics g = Graphics.FromImage(img);
			SolidBrush brush = new SolidBrush(Color.FromArgb(amount, color));

			g.FillRectangle(brush, 0, 0, img.Width, img.Height);

			return img;
		}

		public static GraphicsPath CreateRoundedRectangle(float roundness, RectangleF rect, float offset)
		{
			GraphicsPath gp = new GraphicsPath();

			if (roundness == 0)
			{
				gp.AddRectangle(new RectangleF(
					rect.X + offset, rect.Y + offset,
					rect.Width - offset * 2, rect.Height - offset * 2));
			}
			else
			{
				gp.AddArc(rect.X + offset, rect.Y + offset, roundness - offset, roundness - offset, 180, 90);
				gp.AddArc(rect.X + rect.Width - roundness - offset*.6f, rect.Y + offset, roundness - offset, roundness - offset, 270, 90);
				gp.AddArc(rect.X + rect.Width - roundness - offset*.6f, rect.Y + rect.Height - roundness - offset*1, roundness - offset, roundness - offset, 0, 90);
				gp.AddArc(rect.X + offset, rect.Y + rect.Height - roundness - offset*1, roundness, roundness - offset, 90, 90);

				gp.CloseFigure();
			}
			return gp;
		}

		public static GraphicsPath CreateRoundedRectangle(int roundness, RectangleF rect)
		{
			return CreateRoundedRectangle(roundness, rect, 0);
		}

		public static void CheckFor255(float i)
		{
			if (i > 255 || i < 0)
				throw new ArgumentOutOfRangeException("", "Value must be between 0 and 255.");
		}

		public static void CheckForMinus(float i)
		{
			if (i<0) throw new ArgumentOutOfRangeException("", "Value cannot be a minus value.");
		}
	}
}
