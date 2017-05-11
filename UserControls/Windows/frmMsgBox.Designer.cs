namespace RMS.UserControls
{
	partial class frmMsgBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMsgBox));
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.pnlMessage = new System.Windows.Forms.Panel();
			this.lblMessage = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btn3 = new RMS.UserControls.ShadedButton();
			this.btn2 = new RMS.UserControls.ShadedButton();
			this.btn1 = new RMS.UserControls.ShadedButton();
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
			this.pnlMessage.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// picIcon
			// 
			this.picIcon.BackColor = System.Drawing.Color.Transparent;
			this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.picIcon.Location = new System.Drawing.Point(6, 3);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size(45, 60);
			this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picIcon.TabIndex = 0;
			this.picIcon.TabStop = false;
			// 
			// pnlMessage
			// 
			this.pnlMessage.AutoSize = true;
			this.pnlMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlMessage.BackColor = System.Drawing.Color.Transparent;
			this.pnlMessage.Controls.Add(this.lblMessage);
			this.pnlMessage.Controls.Add(this.picIcon);
			this.pnlMessage.Location = new System.Drawing.Point(3, 3);
			this.pnlMessage.Name = "pnlMessage";
			this.pnlMessage.Padding = new System.Windows.Forms.Padding(6, 3, 6, 5);
			this.pnlMessage.Size = new System.Drawing.Size(127, 68);
			this.pnlMessage.TabIndex = 1;
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMessage.Location = new System.Drawing.Point(51, 3);
			this.lblMessage.MaximumSize = new System.Drawing.Size(600, 500);
			this.lblMessage.MinimumSize = new System.Drawing.Size(70, 60);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Padding = new System.Windows.Forms.Padding(5);
			this.lblMessage.Size = new System.Drawing.Size(70, 60);
			this.lblMessage.TabIndex = 0;
			this.lblMessage.Text = "label1";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlButtons
			// 
			this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
			this.pnlButtons.Controls.Add(this.btn3);
			this.pnlButtons.Controls.Add(this.btn2);
			this.pnlButtons.Controls.Add(this.btn1);
			this.pnlButtons.Location = new System.Drawing.Point(8, 112);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(213, 29);
			this.pnlButtons.TabIndex = 0;
			// 
			// btn3
			// 
			this.btn3.BackColor = System.Drawing.Color.LightGray;
			this.btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn3.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.btn3.FlatAppearance.BorderSize = 0;
			this.btn3.HotBorderWidth = 1F;
			this.btn3.Image = ((System.Drawing.Image)(resources.GetObject("btn3.Image")));
			this.btn3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn3.Location = new System.Drawing.Point(144, 0);
			this.btn3.MouseDownBackColor = System.Drawing.Color.Empty;
			this.btn3.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btn3.MouseOverBackColor = System.Drawing.Color.Empty;
			this.btn3.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
			this.btn3.Name = "btn3";
			this.btn3.Roundness = 25;
			this.btn3.Size = new System.Drawing.Size(64, 24);
			this.btn3.TabIndex = 2;
			this.btn3.Text = "Button3";
			this.btn3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn3.UseVisualStyleBackColor = false;
			this.btn3.Click += new System.EventHandler(this.btn3_Click);
			// 
			// btn2
			// 
			this.btn2.BackColor = System.Drawing.Color.LightGray;
			this.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn2.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.btn2.FlatAppearance.BorderSize = 0;
			this.btn2.HotBorderWidth = 1F;
			this.btn2.Image = ((System.Drawing.Image)(resources.GetObject("btn2.Image")));
			this.btn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn2.Location = new System.Drawing.Point(72, 0);
			this.btn2.MouseDownBackColor = System.Drawing.Color.Empty;
			this.btn2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btn2.MouseOverBackColor = System.Drawing.Color.Empty;
			this.btn2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
			this.btn2.Name = "btn2";
			this.btn2.Roundness = 25;
			this.btn2.Size = new System.Drawing.Size(64, 24);
			this.btn2.TabIndex = 1;
			this.btn2.Text = "Button2";
			this.btn2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn2.UseVisualStyleBackColor = false;
			this.btn2.Click += new System.EventHandler(this.btn2_Click);
			// 
			// btn1
			// 
			this.btn1.BackColor = System.Drawing.Color.LightGray;
			this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn1.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.btn1.FlatAppearance.BorderSize = 0;
			this.btn1.HotBorderWidth = 1F;
			this.btn1.Image = ((System.Drawing.Image)(resources.GetObject("btn1.Image")));
			this.btn1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn1.Location = new System.Drawing.Point(0, 0);
			this.btn1.MouseDownBackColor = System.Drawing.Color.Empty;
			this.btn1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btn1.MouseOverBackColor = System.Drawing.Color.Empty;
			this.btn1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
			this.btn1.Name = "btn1";
			this.btn1.Roundness = 25;
			this.btn1.Size = new System.Drawing.Size(64, 24);
			this.btn1.TabIndex = 0;
			this.btn1.Text = "Button1";
			this.btn1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn1.UseVisualStyleBackColor = false;
			this.btn1.Click += new System.EventHandler(this.btn1_Click);
			// 
			// frmMsgBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(227, 147);
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.pnlMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMsgBox";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Message !";
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
			this.pnlMessage.ResumeLayout(false);
			this.pnlMessage.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Panel pnlMessage;
		private System.Windows.Forms.Label lblMessage;
		private ShadedButton btn1;
		private ShadedButton btn2;
		private System.Windows.Forms.Panel pnlButtons;
		private ShadedButton btn3;

	}
}