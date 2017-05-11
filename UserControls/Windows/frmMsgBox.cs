using System;
using System.Windows.Forms;
using RMS.UserControls.Properties;

//using RMS.UserControls.Properties;

namespace RMS.UserControls
{
	public partial class frmMsgBox : Form
	{
		MsgboxButtonStyle buttonStyle;
		MsgboxIconStyle iconStyle;

		public frmMsgBox(string title, string message, MsgboxButtonStyle buttonStyle, MsgboxIconStyle icon)
		{
			InitializeComponent();

			this.Text = title;
			lblMessage.Text = message;

			this.buttonStyle = buttonStyle;
			this.iconStyle = icon;

			ApplyImage();
			AdjustButtons();
			AdjustSizes();
		}

		#region Interface Adjustments

		private void ApplyImage()
		{
			switch (iconStyle)
			{
				case MsgboxIconStyle.Question:
                    picIcon.Image = RMS.UserControls.Properties.Resources.Question1;
					break;

				case MsgboxIconStyle.Exlamation:
                    picIcon.Image = RMS.UserControls.Properties.Resources.Exlamation1;
					break;

				case MsgboxIconStyle.None:
					picIcon.Hide();
					break;
			}
		}

		private void AdjustButtons()
		{
			if (buttonStyle == MsgboxButtonStyle.OK)
			{
				btn1.Text = "OK    ";
				btn2.Hide();
				btn3.Hide();
				pnlButtons.Width = btn1.Width;
			}
			else if (buttonStyle == MsgboxButtonStyle.OKCancel)
			{
				btn1.Text = "OK    ";
				btn2.Text = "Cancel";
				btn3.Hide();
				pnlButtons.Width = btn1.Width + btn2.Width + 9;
			}
			else if (buttonStyle == MsgboxButtonStyle.YesNo)
			{
				btn1.Text = "Yes   ";
				btn2.Text = "No    ";
				btn3.Hide();
				pnlButtons.Width = btn1.Width + btn2.Width + 9;
			}
			else if (buttonStyle == MsgboxButtonStyle.YesNoCancel)
			{
				btn1.Text = "Yes   ";
				btn2.Text = "No    ";
				btn3.Text = "Cancel";
				pnlButtons.Width = btn1.Width + btn2.Width + btn3.Width + 18;
			}
		}

		private void AdjustSizes()
		{
			Control longestControl;

			if (pnlMessage.Width > pnlButtons.Width)
				longestControl = pnlMessage;
			else
				longestControl = pnlButtons;

			pnlButtons.Top = pnlMessage.Top + pnlMessage.Height + 5;
			this.Height = pnlButtons.Top + pnlButtons.Height + 35;

			this.Width = longestControl.Width + longestControl.Left * 3;
			pnlButtons.Left = (this.ClientSize.Width - pnlButtons.ClientSize.Width) /2;
		}

		#endregion

		#region Button Clicks

		private void btn1_Click(object sender, EventArgs e)
		{
			if (buttonStyle == MsgboxButtonStyle.OK || buttonStyle == MsgboxButtonStyle.OKCancel)
				this.DialogResult = DialogResult.OK;
			else
				this.DialogResult = DialogResult.Yes;

			this.Close();
		}

		private void btn2_Click(object sender, EventArgs e)
		{
			if (buttonStyle == MsgboxButtonStyle.OKCancel)
				this.DialogResult = DialogResult.Cancel;
			else
				this.DialogResult = DialogResult.No;

			this.Close();
		}

		private void btn3_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;

			this.Close();
		}

		#endregion
	}

	public enum MsgboxButtonStyle
	{
		OK,
		OKCancel,
		YesNo,
		YesNoCancel
	}

	public enum MsgboxIconStyle
	{
		None,
		Information,
		Question,
		Exlamation,
		Error
	}

	public enum MsgboxResult
	{
		None,
		OK,
		Cancel,
		Yes,
		No
	}
}