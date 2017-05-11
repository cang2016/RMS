namespace RMS.UserControls
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ColorLabel : Control
    {
        #region Fields

        private Color _borderColor = Color.FromArgb(65, 173, 236);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorLabel"/> class.
        /// </summary>
        public ColorLabel()
            : base()
        {
            SetStyles();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [DefaultValue(typeof(Color), "65, 173, 236")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value></value>
        /// <returns>The default <see cref="T:System.Drawing.Size"/> of the control.</returns>
        protected override Size DefaultSize
        {
            get { return new Size(16, 16); }
        }

        #endregion

        #region Private Methods

        private void SetStyles()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw, true);
            base.UpdateStyles();
        }

        #endregion

        #region OverideMethods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;
            using (SolidBrush brush = new SolidBrush(base.BackColor))
            {
                g.FillRectangle(
                    brush,
                    rect);
            }

            ControlPaint.DrawBorder(
                g,
                rect,
                _borderColor,
                ButtonBorderStyle.Solid);

            rect.Inflate(-1, -1);
            ControlPaint.DrawBorder(
                g,
                rect,
                Color.White,
                ButtonBorderStyle.Solid);
        }

        #endregion
    }
}
