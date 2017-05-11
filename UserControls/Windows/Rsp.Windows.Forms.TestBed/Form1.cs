using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RMS.UserControls.TestBed
{
    public partial class Form1 : RoundedForm
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void roundedButton1_Click(object sender, EventArgs e)
		{
			MsgboxResult result = MsgboxUI.OKCancelQuestion("Warning!", "Are you sure you want to proceed with the operation?");
		}

		private void shadedButton1_Click(object sender, EventArgs e)
		{
			MsgboxResult result = MsgboxUI.YesNoCancel("Warning!", "Are you sure you want to proceed with the operation?");
		}

		private void colorizedButton1_Click(object sender, EventArgs e)
		{
			MsgboxResult result = MsgboxUI.Exlamation("Error!", "Error occured! The operation has been canceled.");
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void chkShadow_CheckedChanged(object sender, EventArgs e)
        {
            this.DropShadow = chkShadow.Checked;
        }
	}
}
