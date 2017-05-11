namespace RMS.UserControls.TestBed
{
	partial class Form1
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
            this.shadedButton1 = new RMS.UserControls.ShadedButton();
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.colorizedButton1 = new RMS.UserControls.ColorizedButton();
            this.chkShadow = new System.Windows.Forms.CheckBox();
            this.numericTextBox1 = new RMS.UserControls.NumericTextBox();
            this.roundedButton2 = new RMS.UserControls.RoundedButton();
            this.shadedButton2 = new RMS.UserControls.ShadedButton();
            this.SuspendLayout();
            // 
            // shadedButton1
            // 
            this.shadedButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shadedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shadedButton1.BorderColor = System.Drawing.Color.Maroon;
            this.shadedButton1.FlatAppearance.BorderSize = 0;
            this.shadedButton1.ForeColor = System.Drawing.Color.White;
            this.shadedButton1.HotBorderWidth = 1F;
            this.shadedButton1.HotBrightenAmount = 75;
            this.shadedButton1.LightAmount = 200;
            this.shadedButton1.Location = new System.Drawing.Point(24, 126);
            this.shadedButton1.MouseDownBackColor = System.Drawing.Color.Empty;
            this.shadedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shadedButton1.MouseOverBackColor = System.Drawing.Color.Empty;
            this.shadedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.shadedButton1.Name = "shadedButton1";
            this.shadedButton1.Roundness = 35;
            this.shadedButton1.Size = new System.Drawing.Size(136, 37);
            this.shadedButton1.TabIndex = 2;
            this.shadedButton1.Text = "shadedButton1";
            this.shadedButton1.UseVisualStyleBackColor = false;
            this.shadedButton1.Click += new System.EventHandler(this.shadedButton1_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.roundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.Location = new System.Drawing.Point(24, 74);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Roundness = 25;
            this.roundedButton1.Size = new System.Drawing.Size(136, 37);
            this.roundedButton1.TabIndex = 1;
            this.roundedButton1.Text = "roundedButton1";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // colorizedButton1
            // 
            this.colorizedButton1.BackgroundImage = global::RMS.UserControls.TestBed.Properties.Resources.Chrysanthemum;
            this.colorizedButton1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.colorizedButton1.DefaultColor = System.Drawing.Color.Empty;
            this.colorizedButton1.FlatAppearance.BorderSize = 0;
            this.colorizedButton1.ForeColor = System.Drawing.Color.White;
            this.colorizedButton1.HotBorderWidth = 2F;
            this.colorizedButton1.Location = new System.Drawing.Point(24, 177);
            this.colorizedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.colorizedButton1.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.colorizedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorizedButton1.MouseOverColor = System.Drawing.Color.Black;
            this.colorizedButton1.Name = "colorizedButton1";
            this.colorizedButton1.Roundness = 25;
            this.colorizedButton1.Size = new System.Drawing.Size(136, 37);
            this.colorizedButton1.TabIndex = 0;
            this.colorizedButton1.Text = "colorizedButton1";
            this.colorizedButton1.UseVisualStyleBackColor = true;
            this.colorizedButton1.Click += new System.EventHandler(this.colorizedButton1_Click);
            // 
            // chkShadow
            // 
            this.chkShadow.AutoSize = true;
            this.chkShadow.Location = new System.Drawing.Point(32, 44);
            this.chkShadow.Name = "chkShadow";
            this.chkShadow.Size = new System.Drawing.Size(90, 16);
            this.chkShadow.TabIndex = 3;
            this.chkShadow.Text = "Form shadow";
            this.chkShadow.UseVisualStyleBackColor = true;
            this.chkShadow.CheckedChanged += new System.EventHandler(this.chkShadow_CheckedChanged);
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(236, 97);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(100, 21);
            this.numericTextBox1.TabIndex = 4;
            this.numericTextBox1.Text = "0.00";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // roundedButton2
            // 
            this.roundedButton2.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.Location = new System.Drawing.Point(245, 165);
            this.roundedButton2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(75, 23);
            this.roundedButton2.TabIndex = 5;
            this.roundedButton2.Text = "roundedButton2";
            this.roundedButton2.UseVisualStyleBackColor = true;
            // 
            // shadedButton2
            // 
            this.shadedButton2.BackColor = System.Drawing.Color.Red;
            this.shadedButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shadedButton2.BorderColor = System.Drawing.Color.Red;
            this.shadedButton2.FlatAppearance.BorderSize = 0;
            this.shadedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.shadedButton2.Location = new System.Drawing.Point(236, 221);
            this.shadedButton2.MouseDownBackColor = System.Drawing.Color.Empty;
            this.shadedButton2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shadedButton2.MouseOverBackColor = System.Drawing.Color.Empty;
            this.shadedButton2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.shadedButton2.Name = "shadedButton2";
            this.shadedButton2.Size = new System.Drawing.Size(75, 23);
            this.shadedButton2.TabIndex = 6;
            this.shadedButton2.Text = "shadedButton2";
            this.shadedButton2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 307);
            this.Controls.Add(this.shadedButton2);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.chkShadow);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.shadedButton1);
            this.Controls.Add(this.colorizedButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.colorizedButton1, 0);
            this.Controls.SetChildIndex(this.shadedButton1, 0);
            this.Controls.SetChildIndex(this.roundedButton1, 0);
            this.Controls.SetChildIndex(this.chkShadow, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.Controls.SetChildIndex(this.roundedButton2, 0);
            this.Controls.SetChildIndex(this.shadedButton2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ColorizedButton colorizedButton1;
		private RoundedButton roundedButton1;
		private ShadedButton shadedButton1;
		private System.Windows.Forms.CheckBox chkShadow;
        private NumericTextBox numericTextBox1;
        private RoundedButton roundedButton2;
        private ShadedButton shadedButton2;
	}
}

