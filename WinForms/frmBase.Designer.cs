namespace RMS.WinForms
{
    partial class frmBase
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
            if(disposing && (components != null))
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
            this.roundedButton2 = new RMS.UserControls.RoundedButton();
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.SuspendLayout();
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.roundedButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundedButton2.Location = new System.Drawing.Point(393, 291);
            this.roundedButton2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(103, 35);
            this.roundedButton2.TabIndex = 40;
            this.roundedButton2.Text = "取 消";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Visible = false;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.roundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundedButton1.Location = new System.Drawing.Point(237, 291);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(103, 35);
            this.roundedButton1.TabIndex = 39;
            this.roundedButton1.Text = " 确 定";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Visible = false;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RMS.WinForms.Properties.Resources.bg0;
            this.ClientSize = new System.Drawing.Size(508, 325);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBase";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.RoundedButton roundedButton2;
        private UserControls.RoundedButton roundedButton1;

    }
}