using System;
using System.Windows.Forms;

namespace RMS.UserControls
{
	/// <summary>
	/// A Form that has a drop shadow.
	/// </summary>
	public partial class ShadowedForm : Form
	{
		DropShadow shadowWindow;
        ShadowInfo shadowInfo = new ShadowInfo();
		bool dropShadow = false;

		public ShadowedForm()
		{
		}

		public bool DropShadow
		{
			get
			{
				return dropShadow;
			}
			set
			{
				if (!dropShadow && value == true)
				{
					shadowWindow = new DropShadow(this);
					shadowWindow.ShadowInfo = shadowInfo;

					shadowWindow.Show();
				}
				else if (dropShadow && value == false)
				{
					shadowWindow.Dispose();
					shadowWindow = null;
				}

				dropShadow = value;
			}
		}

		public ShadowInfo ShadowInfo
		{
			get { return shadowInfo; }
			set
			{
				if (shadowWindow != null)
				{
					shadowWindow.ShadowInfo = shadowInfo;
				}
			}
		}

		public void RefreshShadow()
		{
			if (shadowWindow != null)
				shadowWindow.RefreshShadow();
		}

		#region Overrides

		protected override void OnClosed(EventArgs e)
		{
			//If the shadow wasn't disposed here, user will see the whole shadow form
			//for a little time, after closing the window.
			if (shadowWindow != null)
				shadowWindow.Dispose();

			base.OnClosed(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!this.DesignMode && shadowWindow != null)
				shadowWindow.Show();
		}

		#endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShadowedForm
            // 
            this.ClientSize = new System.Drawing.Size(856, 750);
            this.MaximizeBox = false;
            this.Name = "ShadowedForm";
            this.ResumeLayout(false);

        }
	}
}