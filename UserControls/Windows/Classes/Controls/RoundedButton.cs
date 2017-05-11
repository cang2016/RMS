using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace RMS.UserControls
{
	public class RoundedButton: Button
	{
		int roundness = 15, borderTransp = 255;
		float borderWidth = 1f, hotBorderWidth = 3f;
		Color borderColor, mouseOverBorderColor, mouseDownBorderColor;

		private bool mouseDown = false, mouseOver = false,
			showMdownBorder = true, showMoverBorder = true;

		public RoundedButton()
		{
			base.FlatStyle = FlatStyle.Flat;
			base.FlatAppearance.BorderSize = 0;

			borderColor = Color.FromKnownColor(KnownColor.ControlDark);
			mouseOverBorderColor = Color.FromArgb(borderTransp, Color.Orange);
			mouseDownBorderColor = Color.FromArgb(borderTransp, Color.Green);

			UpdateBorderColor();

			SetRegion();
		}

		#region Properties

		[Category("Effects"), DefaultValue(15), Description("Roundness of the corners of the button.")]
		public int Roundness
		{
			get { return roundness; }
			set
			{
				Common.CheckForMinus(value);
				roundness = value;
				SetRegion();
			}
		}

		[Category("Effects"), Description("Color of the button border.")]
		public Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; Refresh(); }
		}

		[Category("Effects"), DefaultValue(1f), Description("Width of the button border.")]
		public float BorderWidth
		{
			get { return borderWidth; }
			set
			{
				Common.CheckForMinus(value);
				borderWidth = value;
				Refresh();
			}
		}

		[Category("Effects"), DefaultValue(3f), Description("Width of the MouseOver and MouseDown border.")]
		public float HotBorderWidth
		{
			get { return hotBorderWidth; }
			set
			{
				Common.CheckForMinus(value);
				hotBorderWidth = value;
				Refresh();
			}
		}

		[Category("Effects"), DefaultValue(255), Description("Transparency of the MouseOver and MouseDown border.")]
		public int HotBorderColorAlpha
		{
			get { return borderTransp; }
			set
			{
				Common.CheckFor255(value);
				borderTransp = value; UpdateBorderColor();
			}
		}

		[Category("Effects"), DefaultValue(true), Description("Display the border when the mouse is over the button.")]
		public bool ShowMouseOverBorder
		{
			get { return showMoverBorder; }
			set { showMoverBorder = value; }
		}

		[Category("Effects"), DefaultValue(true), Description("Display the border when the mouse is pressed.")]
		public bool ShowMouseDownBorder
		{
			get { return showMdownBorder; }
			set { showMdownBorder = value; }
		}

		[Category("Effects"), Description("Color of the MouseOver border.")]
		public Color MouseOverBorderColor
		{
			get { return mouseOverBorderColor; }
			set { mouseOverBorderColor = value; UpdateBorderColor(); }
		}

		[Category("Effects"), Description("Color of the MouseDown border.")]
		public Color MouseDownBorderColor
		{
			get { return mouseDownBorderColor; }
			set { mouseDownBorderColor = value; UpdateBorderColor(); }
		}

		#endregion

		#region Private Methods

		private void SetRegion()
		{
			this.Region = new Region(CreateRoundedRect(0.0f));
			this.Refresh();
		}

		#region Paint Border

		private void PaintBorder(Graphics g)
		{
			if (showMdownBorder && mouseDown) PaintHotBorder(mouseDownBorderColor, g);
			else if (showMoverBorder && !mouseDown && mouseOver) PaintHotBorder(mouseOverBorderColor, g);
			else if (borderWidth > 0) g.DrawPath(new Pen(borderColor, borderWidth), CreateRoundedRect(.5f));
		}

		private void PaintHotBorder(Color color, Graphics g)
		{
			g.DrawPath(new Pen(color, hotBorderWidth), CreateRoundedRect(0.5f));
		}

		private void UpdateBorderColor()
		{
			mouseOverBorderColor = Color.FromArgb(borderTransp, mouseOverBorderColor);
			mouseDownBorderColor = Color.FromArgb(borderTransp, mouseDownBorderColor);

			Refresh();
		}

		private GraphicsPath CreateRoundedRect(float offset)
		{ return Common.CreateRoundedRectangle(roundness, this.ClientRectangle, offset);
		}

		#endregion

		#endregion

		#region Overrides

		[Browsable(false), DefaultValue(FlatStyle.Flat)]
		public new FlatStyle FlatStyle
		{
			get { return FlatStyle.Flat; }
			set
			{
				throw new ArgumentException("Flat Style cannot be set.");
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			
			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			PaintBorder(pevent.Graphics);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			mouseOver = true;
			Refresh();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			mouseOver = false;
			Refresh();
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			mouseDown = true;
			Refresh();
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			mouseDown = false;
			Refresh();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SetRegion();
		}

		#endregion
	}
}
