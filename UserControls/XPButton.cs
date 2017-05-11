﻿namespace RMS.UserControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class XPButton : System.Windows.Forms.Button
    {
        public enum ControlState
        {
            /// <summary>The XP control is in the normal state.</summary>
            Normal,
            /// <summary>The XP control is in the hover state.</summary>
            Hover,
            /// <summary>The XP control is in the pressed state.</summary>
            Pressed,
            /// <summary>The XP control object is in the default state.</summary>
            Default,
            /// <summary>The XP control object is in the disabled state.</summary>
            Disabled
        }

        public XPButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);

            // TODO: Add any initialization after the InitComponent call

        }
        #region Instance fields
        private ControlState enmState = ControlState.Normal;
        private bool bCanClick = false;
        private Point locPoint;
        #endregion

        #region Static members
        // Fields
        private static readonly Size sizeBorderPixelIndent;
        private static readonly Color clrOuterShadow1;
        private static readonly Color clrOuterShadow2;
        private static readonly Color clrBackground1;
        private static readonly Color clrBackground2;
        private static readonly Color clrBorder;
        private static readonly Color clrInnerShadowBottom1;
        private static readonly Color clrInnerShadowBottom2;
        private static readonly Color clrInnerShadowBottom3;
        private static readonly Color clrInnerShadowRight1a;
        private static readonly Color clrInnerShadowRight1b;
        private static readonly Color clrInnerShadowRight2a;
        private static readonly Color clrInnerShadowRight2b;
        private static readonly Color clrInnerShadowBottomPressed1;
        private static readonly Color clrInnerShadowBottomPressed2;
        private static readonly Color clrInnerShadowTopPressed1;
        private static readonly Color clrInnerShadowTopPressed2;
        private static readonly Color clrInnerShadowLeftPressed1;
        private static readonly Color clrInnerShadowLeftPressed2;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes all static fields of the XpButton class.
        /// </summary>
        static XPButton()
        {
            // 1 pixel indent in the roundness of the border (from XP Visual Design Guidelines)
            // To make pixel indentation larger, change by a factor of 4,
            // i. e., 2 pixels indent = Size(8, 8);
            sizeBorderPixelIndent = new Size(4, 4);

            // Normal colors
            clrOuterShadow1 = Color.FromArgb(64, 164, 164, 164);
            clrOuterShadow2 = Color.FromArgb(64, Color.White);
            clrBackground1 = Color.FromArgb(250, 250, 248);
            clrBackground2 = Color.FromArgb(240, 240, 234);
            clrBorder = Color.FromArgb(0, 60, 116);
            clrInnerShadowBottom1 = Color.FromArgb(236, 235, 230);
            clrInnerShadowBottom2 = Color.FromArgb(226, 223, 214);
            clrInnerShadowBottom3 = Color.FromArgb(214, 208, 197);
            clrInnerShadowRight1a = Color.FromArgb(128, 236, 234, 230);
            clrInnerShadowRight1b = Color.FromArgb(128, 224, 220, 212);
            clrInnerShadowRight2a = Color.FromArgb(128, 234, 228, 218);
            clrInnerShadowRight2b = Color.FromArgb(128, 212, 208, 196);

            // Pressed colors
            clrInnerShadowBottomPressed1 = Color.FromArgb(234, 233, 227);
            clrInnerShadowBottomPressed2 = Color.FromArgb(242, 241, 238);
            clrInnerShadowTopPressed1 = Color.FromArgb(209, 204, 193);
            clrInnerShadowTopPressed2 = Color.FromArgb(220, 216, 207);
            clrInnerShadowLeftPressed1 = Color.FromArgb(216, 213, 203);
            clrInnerShadowLeftPressed2 = Color.FromArgb(222, 220, 211);
        }

        /// <summary>
        /// Initializes a new instance of the XpButton class.
        /// </summary>

        #endregion

        #region Properties
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { base.FlatStyle = FlatStyle.Standard; }
        }

        private emunType.XPStyle m_btnStyle = emunType.XPStyle.Default;
        private emunType.BtnShape m_btnShape = emunType.BtnShape.Rectangle;
        public emunType.BtnShape BtnShape
        {
            get { return m_btnShape; }
            set
            {
                m_btnShape = value;
                base.Invalidate();
            }
        }
        [DefaultValue("Blue"),
        System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)]
        public emunType.XPStyle BtnStyle
        {
            get { return m_btnStyle; }
            set
            {
                m_btnStyle = value;
                this.Invalidate();
            }
        }
        public Point AdjustImageLocation
        {
            get { return locPoint; }
            set
            {
                locPoint = value;
                this.Invalidate();
            }
        }
        /// <value>Gets the clipping rectangle of the XpButton object's border.</value>
        private Rectangle BorderRectangle
        {
            get
            {
                Rectangle rc = this.ClientRectangle;
                return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
            }
        }

        #endregion

        #region override
        // Overridden Event Handlers
        protected override void OnClick(EventArgs ea)
        {
            this.Capture = false;
            bCanClick = false;

            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                enmState = ControlState.Hover;
            else
                enmState = ControlState.Normal;

            this.Invalidate();

            base.OnClick(ea);
        }

        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);

            enmState = ControlState.Hover;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);

            if (mea.Button == MouseButtons.Left)
            {
                bCanClick = true;
                enmState = ControlState.Pressed;
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            if (ClientRectangle.Contains(mea.X, mea.Y))
            {
                if (enmState == ControlState.Hover && this.Capture && !bCanClick)
                {
                    bCanClick = true;
                    enmState = ControlState.Pressed;
                    this.Invalidate();
                }
            }
            else
            {
                if (enmState == ControlState.Pressed)
                {
                    bCanClick = false;
                    enmState = ControlState.Hover;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs ea)
        {
            base.OnMouseLeave(ea);

            enmState = ControlState.Normal;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            this.OnPaintBackground(pea);

            switch (enmState)
            {
                case ControlState.Normal:
                    if (this.Enabled)
                    {
                        if (this.Focused || this.IsDefault)
                        {
                            switch (m_btnShape)
                            {
                                case emunType.BtnShape.Rectangle:
                                    OnDrawDefault(pea.Graphics);
                                    break;
                                case emunType.BtnShape.Ellipse:
                                    OnDrawDefaultEllipse(pea.Graphics);
                                    break;
                            }
                        }
                        else
                        {
                            switch (m_btnShape)
                            {
                                case emunType.BtnShape.Rectangle:
                                    OnDrawNormal(pea.Graphics);
                                    break;
                                case emunType.BtnShape.Ellipse:
                                    OnDrawNormalEllipse(pea.Graphics);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        OnDrawDisabled(pea.Graphics);
                    }

                    break;

                case ControlState.Hover:
                    switch (m_btnShape)
                    {
                        case emunType.BtnShape.Rectangle:
                            OnDrawHover(pea.Graphics);
                            break;
                        case emunType.BtnShape.Ellipse:
                            OnDrawHoverEllipse(pea.Graphics);
                            break;
                    }
                    break;

                case ControlState.Pressed:
                    switch (m_btnShape)
                    {
                        case emunType.BtnShape.Rectangle:
                            OnDrawPressed(pea.Graphics);
                            break;
                        case emunType.BtnShape.Ellipse:
                            OnDrawPressedEllipse(pea.Graphics);
                            break;
                    }
                    break;
            }

            // enmState will never be == ControlState.Default
            // When (IsDefault == true), enmState will be == ControlState.Normal
            // So when (IsDefault == true), pass ControlState.Default instead of enmState
            OnDrawTextAndImage(pea.Graphics);

            // Not really needed!
            /*if (this.Focused)
            {
                Rectangle rcFocus = this.ClientRectangle;
                rcFocus.Inflate(-3, -3);
                System.Windows.Forms.ControlPaint.DrawFocusRectangle(pea.Graphics, rcFocus,
                    this.ForeColor, Color.Transparent);
            }*/
        }

        protected override void OnEnabledChanged(EventArgs ea)
        {
            base.OnEnabledChanged(ea);
            enmState = ControlState.Normal;
            this.Invalidate();
        }


        /// <summary>
        /// Draws the normal state of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawNormal(Graphics g)
        {
            DrawNormalButton(g);
            // no need to call base class implementation
        }
        private void OnDrawHoverEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseHoverBorder(g);
            DrawEllipseBorder(g);
        }
        /// <summary>
        /// Draws the hover state of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawHover(Graphics g)
        {
            DrawNormalButton(g);

            //
            // Need to draw only the "thick border" for hover buttons
            //

            Rectangle rcBorder = this.BorderRectangle;

            // Top
            Pen penTop1 = new Pen(Color.FromArgb(255, 240, 207));
            Pen penTop2 = new Pen(Color.FromArgb(253, 216, 137));

            g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1,
                rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2,
                rcBorder.Right - 1, rcBorder.Top + 2);

            penTop1.Dispose();
            penTop2.Dispose();

            // Bottom
            Pen penBottom1 = new Pen(Color.FromArgb(248, 178, 48));
            Pen penBottom2 = new Pen(Color.FromArgb(229, 151, 0));

            g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2,
                rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1,
                rcBorder.Right - 2, rcBorder.Bottom - 1);

            penBottom1.Dispose();
            penBottom2.Dispose();

            // Left and Right
            Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3,
                2, rcBorder.Height - 5);
            Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3,
                2, rcBorder.Height - 5);

            LinearGradientBrush brushSide = new LinearGradientBrush(
                rcLeft, Color.FromArgb(254, 221, 149), Color.FromArgb(249, 180, 53),
                LinearGradientMode.Vertical);

            g.FillRectangle(brushSide, rcLeft);
            g.FillRectangle(brushSide, rcRight);

            brushSide.Dispose();
        }

        private void OnDrawPressedEllipse(Graphics g)
        {
            DrawPressedEllipse(g);
            DrawEllipseBorder(g);
        }
        private void DrawPressedEllipse(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            Rectangle rcBackground = new Rectangle(
                rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(226, 225, 218));
            // Draw an ellipse to the screen using the LinearGradientBrush.
            g.FillEllipse(brushBackground, rcBackground);
            // Create a triangular shaped brush with the peak at the center
            // of the drawing area.
        }
        /// <summary>
        /// Draws the pressed state of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawPressed(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            //			
            // Outer shadow
            //
            DrawOuterShadow(g);

            //
            // Background
            //
            Rectangle rcBackground = new Rectangle(
                rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(226, 225, 218));
            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();

            //
            // Border
            //
            DrawBorder(g);

            //
            // Inner shadow above the bottom border (2 solid lines)
            //
            Pen penInnerShadowBottomPressed1 = new Pen(clrInnerShadowBottomPressed1);
            Pen penInnerShadowBottomPressed2 = new Pen(clrInnerShadowBottomPressed2);

            g.DrawLine(penInnerShadowBottomPressed1, rcBorder.Left + 1, rcBorder.Bottom - 2,
                rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penInnerShadowBottomPressed2, rcBorder.Left + 2, rcBorder.Bottom - 1,
                rcBorder.Right - 2, rcBorder.Bottom - 1);

            penInnerShadowBottomPressed1.Dispose();
            penInnerShadowBottomPressed2.Dispose();

            //
            // Inner shadow below the top border (2 solid lines)
            //
            Pen penInnerShadowTopPressed1 = new Pen(clrInnerShadowTopPressed1);
            Pen penInnerShadowTopPressed2 = new Pen(clrInnerShadowTopPressed2);

            g.DrawLine(penInnerShadowTopPressed1, rcBorder.Left + 2, rcBorder.Top + 1,
                rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penInnerShadowTopPressed2, rcBorder.Left + 1, rcBorder.Top + 2,
                rcBorder.Right - 1, rcBorder.Top + 2);

            penInnerShadowTopPressed1.Dispose();
            penInnerShadowTopPressed2.Dispose();

            //
            // Inner shadow right the left border (2 solid lines)
            //
            Pen penInnerShadowLeftPressed1 = new Pen(clrInnerShadowLeftPressed1);
            Pen penInnerShadowLeftPressed2 = new Pen(clrInnerShadowLeftPressed2);

            g.DrawLine(penInnerShadowLeftPressed1, rcBorder.Left + 1, rcBorder.Top + 3,
                rcBorder.Left + 1, rcBorder.Bottom - 3);
            g.DrawLine(penInnerShadowLeftPressed2, rcBorder.Left + 2, rcBorder.Top + 3,
                rcBorder.Left + 2, rcBorder.Bottom - 3);

            penInnerShadowLeftPressed1.Dispose();
            penInnerShadowLeftPressed2.Dispose();
        }

        /// <summary>
        /// Draws the default state of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawNormalEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseBorder(g);
        }
        private void OnDrawDefaultEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseDefaultBorder(g);
            DrawEllipseBorder(g);
        }
        private void OnDrawDefault(Graphics g)
        {
            DrawNormalButton(g);

            //
            // Need to draw only the "thick border" for default buttons
            //

            Rectangle rcBorder = this.BorderRectangle;

            // Top
            Pen penTop1 = new Pen(Color.FromArgb(206, 231, 255));
            Pen penTop2 = new Pen(Color.FromArgb(188, 212, 246));

            g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1,
                rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2,
                rcBorder.Right - 1, rcBorder.Top + 2);

            penTop1.Dispose();
            penTop2.Dispose();

            // Bottom
            Pen penBottom1 = new Pen(Color.FromArgb(137, 173, 228));
            Pen penBottom2 = new Pen(Color.FromArgb(105, 130, 238));

            g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2,
                rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1,
                rcBorder.Right - 2, rcBorder.Bottom - 1);

            penBottom1.Dispose();
            penBottom2.Dispose();

            // Left and Right
            Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3,
                2, rcBorder.Height - 5);
            Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3,
                2, rcBorder.Height - 5);

            LinearGradientBrush brushSide = new LinearGradientBrush(
                rcLeft, Color.FromArgb(186, 211, 245), Color.FromArgb(137, 173, 228),
                LinearGradientMode.Vertical);

            g.FillRectangle(brushSide, rcLeft);
            g.FillRectangle(brushSide, rcRight);

            brushSide.Dispose();
        }

        /// <summary>
        /// Draws the disabled state of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawDisabled(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            //
            // Background
            //
            Rectangle rcBackground = new Rectangle(
                rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(245, 244, 234));

            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();

            //
            // Border
            //
            Pen penBorder = new Pen(Color.FromArgb(201, 199, 186));
            MyControlPaint.DrawRoundedRectangle(g, penBorder, rcBorder,
                sizeBorderPixelIndent);
            penBorder.Dispose();
        }

        /// <summary>
        /// Draws the text of the XpButton.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void OnDrawTextAndImage(Graphics g)
        {
            SolidBrush brushText;

            if (Enabled)
                brushText = new SolidBrush(ForeColor);
            else
                brushText = new SolidBrush(MyControlPaint.DisabledForeColor);

            StringFormat sf = MyControlPaint.GetStringFormat(this.TextAlign);
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

            if (this.Image != null)
            {
                Rectangle rc = new Rectangle();
                Point ImagePoint = new Point(6, 4);
                switch (this.ImageAlign)
                {
                    case ContentAlignment.MiddleRight:
                        {
                            rc.Width = this.ClientRectangle.Width - this.Image.Width - 8;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = 0;
                            rc.Y = 0;
                            ImagePoint.X = rc.Width;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                        {
                            ImagePoint.Y = 2;
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            rc.Width = this.ClientRectangle.Width;
                            rc.Height = this.ClientRectangle.Height - this.Image.Height - 4;
                            rc.X = this.ClientRectangle.X;
                            rc.Y = this.Image.Height;
                            break;
                        }
                    case ContentAlignment.MiddleCenter:
                        { // no text in this alignment
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            ImagePoint.Y = (this.ClientRectangle.Height - this.Image.Height) / 2;
                            rc.Width = 0;
                            rc.Height = 0;
                            rc.X = this.ClientRectangle.Width;
                            rc.Y = this.ClientRectangle.Height;
                            break;
                        }
                    default:
                        {
                            ImagePoint.X = 6;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            rc.Width = this.ClientRectangle.Width - this.Image.Width;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = this.Image.Width;
                            rc.Y = 0;
                            break;
                        }
                }
                ImagePoint.X += locPoint.X;
                ImagePoint.Y += locPoint.Y;
                if (this.Enabled)
                    g.DrawImage(this.Image, ImagePoint);
                else
                    System.Windows.Forms.ControlPaint.DrawImageDisabled(g, this.Image, locPoint.X, locPoint.Y, this.BackColor);
                if (ContentAlignment.MiddleCenter != this.ImageAlign)
                    g.DrawString(
                        this.Text,
                        this.Font,
                        brushText,
                        rc,
                        sf);
            }
            else
                g.DrawString(
                    this.Text,
                    this.Font,
                    brushText,
                    this.ClientRectangle,
                    sf);

            brushText.Dispose();
            sf.Dispose();
        }


        private void DrawNormalEllipse(Graphics g)
        {
            Rectangle rcBackground = this.BorderRectangle;
            LinearGradientBrush brushBackground = null;
            switch (m_btnStyle)
            {
                case emunType.XPStyle.Default:
                    brushBackground = new LinearGradientBrush(rcBackground, clrBackground1, clrBackground2,
                        LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.Blue:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(248, 252, 253), Color.FromArgb(172, 171, 201), LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.OliveGreen:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(250, 250, 240), Color.FromArgb(235, 220, 190), LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.Silver:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(253, 253, 253), Color.FromArgb(205, 205, 205),
                        LinearGradientMode.Vertical);
                    break;
            }
            float[] relativeIntensities = { 0.0f, 0.008f, 1.0f };
            float[] relativePositions = { 0.0f, 0.22f, 1.0f };

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            brushBackground.Blend = blend;
            // Create a triangular shaped brush with the peak at the center
            // of the drawing area.
            //			brushBackground.SetBlendTriangularShape(.5f, 1.0f);
            // Use the triangular brush to draw a second ellipse.
            //			rcBackground.Y = 150;
            g.FillEllipse(brushBackground, rcBackground);
        }
        /// <summary>
        /// Draws the ordinary look of the XpButton object.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the XpButton.</param>
        private void DrawNormalButton(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            //			
            // Outer shadow
            //
            DrawOuterShadow(g);

            //
            // Background
            //
            Rectangle rcBackground = new Rectangle(
                rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            LinearGradientBrush brushBackground = null;
            switch (m_btnStyle)
            {
                case emunType.XPStyle.Default:
                    brushBackground = new LinearGradientBrush(rcBackground, clrBackground1, clrBackground2,
                        LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.Blue:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(248, 252, 253), Color.FromArgb(172, 171, 201), LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.OliveGreen:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(250, 250, 240), Color.FromArgb(235, 220, 190), LinearGradientMode.Vertical);
                    break;
                case emunType.XPStyle.Silver:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(253, 253, 253), Color.FromArgb(205, 205, 205),
                        LinearGradientMode.Vertical);
                    break;
            }

            float[] relativeIntensities = { 0.0f, 0.08f, 1.0f };
            float[] relativePositions = { 0.0f, 0.32f, 1.0f };

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            brushBackground.Blend = blend;

            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();
            //
            // Border
            //
            DrawBorder(g);

            if (emunType.XPStyle.Default == m_btnStyle)
            {
                //
                // Inner shadow above the bottom border (3 solid lines)
                //
                Pen penInnerShadowBottom1 = new Pen(clrInnerShadowBottom1);
                Pen penInnerShadowBottom2 = new Pen(clrInnerShadowBottom2);
                Pen penInnerShadowBottom3 = new Pen(clrInnerShadowBottom3);

                g.DrawLine(penInnerShadowBottom1, rcBorder.Left + 1, rcBorder.Bottom - 3,
                    rcBorder.Right - 1, rcBorder.Bottom - 3);
                g.DrawLine(penInnerShadowBottom2, rcBorder.Left + 1, rcBorder.Bottom - 2,
                    rcBorder.Right - 1, rcBorder.Bottom - 2);
                g.DrawLine(penInnerShadowBottom3, rcBorder.Left + 2, rcBorder.Bottom - 1,
                    rcBorder.Right - 2, rcBorder.Bottom - 1);

                penInnerShadowBottom1.Dispose();
                penInnerShadowBottom2.Dispose();
                penInnerShadowBottom3.Dispose();

                //
                // Inner shadow to the left of the right border (2 gradient lines)
                //
                Point ptInnerShadowRight1a = new Point(rcBorder.Right - 2, rcBorder.Top + 1);
                Point ptInnerShadowRight1b = new Point(rcBorder.Right - 2, rcBorder.Bottom - 1);
                Point ptInnerShadowRight2a = new Point(rcBorder.Right - 1, rcBorder.Top + 2);
                Point ptInnerShadowRight2b = new Point(rcBorder.Right - 1, rcBorder.Bottom - 2);

                LinearGradientBrush brushInnerShadowRight1 = new LinearGradientBrush(
                    ptInnerShadowRight1a, ptInnerShadowRight1b,
                    clrInnerShadowRight1a, clrInnerShadowRight1b);
                Pen penInnerShadowRight1 = new Pen(brushInnerShadowRight1);

                LinearGradientBrush brushInnerShadowRight2 = new LinearGradientBrush(
                    ptInnerShadowRight2a, ptInnerShadowRight2b,
                    clrInnerShadowRight2a, clrInnerShadowRight2b);
                Pen penInnerShadowRight2 = new Pen(brushInnerShadowRight2);

                g.DrawLine(penInnerShadowRight1, ptInnerShadowRight1a, ptInnerShadowRight1b);
                g.DrawLine(penInnerShadowRight2, ptInnerShadowRight2a, ptInnerShadowRight2b);

                penInnerShadowRight1.Dispose();
                penInnerShadowRight2.Dispose();
                brushInnerShadowRight1.Dispose();
                brushInnerShadowRight2.Dispose();

                // Top showing light source
                Pen penTop = new Pen(Color.White);

                g.DrawLine(penTop, rcBorder.Left + 2, rcBorder.Top + 1,
                    rcBorder.Right - 2, rcBorder.Top + 1);
                g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 2,
                    rcBorder.Right - 1, rcBorder.Top + 2);
                g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 3,
                    rcBorder.Right - 1, rcBorder.Top + 3);

                penTop.Dispose();
            }
        }

        /// <summary>
        /// Draws the outer shadow of the XpButton object.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the outer shadow.</param>
        private void DrawOuterShadow(Graphics g)
        {
            LinearGradientBrush brushOuterShadow = new LinearGradientBrush(
                ClientRectangle, clrOuterShadow1, clrOuterShadow2, LinearGradientMode.Vertical);
            g.FillRectangle(brushOuterShadow, ClientRectangle);
            brushOuterShadow.Dispose();
        }
        private void DrawEllipseOuterShadow(Graphics g)
        {
            LinearGradientBrush brushOuterShadow = new LinearGradientBrush(
                ClientRectangle, clrOuterShadow1, clrOuterShadow2, LinearGradientMode.Vertical);
            g.FillRectangle(brushOuterShadow, ClientRectangle);
            brushOuterShadow.Dispose();
        }

        /// <summary>
        /// Draws the dark blue border of the XpButton object.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to paint the border.</param>
        private void DrawBorder(Graphics g)
        {
            Pen penBorder = new Pen(clrBorder);
            MyControlPaint.DrawRoundedRectangle(g, penBorder, this.BorderRectangle,
                sizeBorderPixelIndent);
            penBorder.Dispose();
        }
        private void DrawEllipseBorder(Graphics g)
        {
            Pen penBorder = new Pen(Color.FromArgb(0, 0, 0));

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penBorder, this.BorderRectangle);
            g.SmoothingMode = oldSmoothingMode;

            penBorder.Dispose();
        }
        private void DrawEllipseDefaultBorder(Graphics g)
        {
            Pen penTop2 = new Pen(Color.FromArgb(137, 173, 228), 2);
            Rectangle rcInFrame = new Rectangle(
                this.BorderRectangle.X + 2, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 4, this.BorderRectangle.Height - 2);

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penTop2, rcInFrame);
            g.SmoothingMode = oldSmoothingMode;

            penTop2.Dispose();
        }
        private void DrawEllipseHoverBorder(Graphics g)
        {
            Pen penTop2 = new Pen(Color.FromArgb(248, 178, 48), 2);
            Rectangle rcInFrame = new Rectangle(
                this.BorderRectangle.X + 2, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 4, this.BorderRectangle.Height - 2);

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penTop2, rcInFrame);
            g.SmoothingMode = oldSmoothingMode;

            penTop2.Dispose();
        }
        #endregion
    }

    public class emunType
    {
        public enum XPStyle { Default, Blue, OliveGreen, Silver }
        public enum BtnShape { Rectangle, Ellipse }
    }

    internal sealed class MyControlPaint
    {
        private MyControlPaint()
        {
        }

        public static Color BorderColor
        {
            get { return Color.FromArgb(127, 157, 185); }
        }

        public static Color DisabledBorderColor
        {
            get { return Color.FromArgb(201, 199, 186); }
        }

        public static Color ButtonBorderColor
        {
            get { return Color.FromArgb(28, 81, 128); }
        }

        public static Color DisabledButtonBorderColor
        {
            get { return Color.FromArgb(202, 200, 187); }
        }

        public static Color DisabledBackColor
        {
            get { return Color.FromArgb(236, 233, 216); }
        }

        public static Color DisabledForeColor
        {
            get { return Color.FromArgb(161, 161, 146); }
        }



        public static StringFormat GetStringFormat(ContentAlignment contentAlignment)
        {
            if (!Enum.IsDefined(typeof(ContentAlignment), (int)contentAlignment))
                throw new System.ComponentModel.InvalidEnumArgumentException(
                    "contentAlignment", (int)contentAlignment, typeof(ContentAlignment));

            StringFormat stringFormat = new StringFormat();

            switch (contentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleLeft:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.MiddleRight:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.TopCenter:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.TopLeft:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopRight:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomCenter:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.BottomLeft:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.BottomRight:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
            }

            return stringFormat;
        }

        /// <summary>
        /// Draws a rectangle with rounded edges.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to be used to draw the rectangle.</param>
        /// <param name="p">A System.Drawing.Pen object that determines the color, width, and style of the rectangle.</param>
        /// <param name="rc">A System.Drawing.Rectangle structure that represents the rectangle to draw.</param>
        /// <param name="size">Pixel indentation that determines the roundness of the corners.</param>
        public static void DrawRoundedRectangle(Graphics g, Pen p, Rectangle rc, Size size)
        {
            // 1 pixel indent in all sides = Size(4, 4)
            // To make pixel indentation larger, change by a factor of 4,
            // i. e., 2 pixels indent = Size(8, 8);

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(p, rc.Left + size.Width / 2, rc.Top,
                rc.Right - size.Width / 2, rc.Top);
            g.DrawArc(p, rc.Right - size.Width, rc.Top,
                size.Width, size.Height, 270, 90);

            g.DrawLine(p, rc.Right, rc.Top + size.Height / 2,
                rc.Right, rc.Bottom - size.Height / 2);
            g.DrawArc(p, rc.Right - size.Width, rc.Bottom - size.Height,
                size.Width, size.Height, 0, 90);

            g.DrawLine(p, rc.Right - size.Width / 2, rc.Bottom,
                rc.Left + size.Width / 2, rc.Bottom);
            g.DrawArc(p, rc.Left, rc.Bottom - size.Height,
                size.Width, size.Height, 90, 90);

            g.DrawLine(p, rc.Left, rc.Bottom - size.Height / 2,
                rc.Left, rc.Top + size.Height / 2);
            g.DrawArc(p, rc.Left, rc.Top,
                size.Width, size.Height, 180, 90);

            g.SmoothingMode = oldSmoothingMode;
        }

        public static void DrawBorder(Graphics g, int x, int y, int width, int height)
        {
            g.DrawRectangle(new Pen(MyControlPaint.BorderColor, 0), x, y,
                width, height);
        }

        public static void EraseExcessOldDropDown(Graphics g, Rectangle newButton)
        {
            g.FillRectangle(new SolidBrush(SystemColors.Window), newButton.X - 2, newButton.Y,
                2, newButton.Height + 1);
        }

    }
}
