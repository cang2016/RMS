namespace RMS.WinForms
{
    using RMS.UserControls;

    partial class CCMsgBox
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
            this.topLogo1 = new topLogo();
            this.SuspendLayout();
            // 
            // topLogo1
            // 
            this.topLogo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo1.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo1.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo1.Location = new System.Drawing.Point(0, 0);
            this.topLogo1.Name = "topLogo1";
            this.topLogo1.Size = new System.Drawing.Size(474, 55);
            this.topLogo1.TabIndex = 0;
            this.topLogo1.TabStop = false;
            // 
            // CCMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 277);
            this.Controls.Add(this.topLogo1);
            this.Name = "CCMsgBox";
            this.Text = "frmMsg";
            this.ResumeLayout(false);

        }

        #endregion

        private topLogo topLogo1;
    }
}