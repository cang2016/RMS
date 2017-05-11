using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace RMS.UserControls
{
	public class NumericTextBox: TextBox
	{
		string formatString = "N2";

		public NumericTextBox()
		{
			this.TextAlign = HorizontalAlignment.Right;
		}

		[DefaultValue("N2"), Description("The format specifier to which the value should be formatted.")]
		public string Format
		{
			get { return formatString; }
			set { formatString = value; FormatText(); }
		}

		private void FormatText(string text)
		{
			double doubleValue = 0.0;

			double.TryParse(text, out doubleValue);

			base.Text = doubleValue.ToString(formatString);
		}

		private void FormatText()
		{
			FormatText(base.Text);
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				FormatText(value);
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && !(e.KeyChar >= ',' && e.KeyChar <= '.')
				&& e.KeyChar != 8 /*Backspace*/ )

				e.Handled = true;
		}

		protected override void OnValidated(EventArgs e)
		{
			base.OnValidated(e);
			FormatText();
		}
	}
}
