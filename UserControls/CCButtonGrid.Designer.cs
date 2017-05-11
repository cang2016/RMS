

namespace RMS.UserControls
{
    partial class CCButtonGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCButtonGrid));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedButton1.BackgroundImage")));
            this.roundedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton1.BorderColor = System.Drawing.Color.Red;
            this.roundedButton1.BorderWidth = 2F;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.Location = new System.Drawing.Point(14, 14);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Roundness = 30;
            this.roundedButton1.Size = new System.Drawing.Size(126, 95);
            this.roundedButton1.TabIndex = 1;
            this.roundedButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Visible = false;
            this.roundedButton1.MouseLeave += new System.EventHandler(this.roundedButton1_MouseLeave);
            this.roundedButton1.MouseHover += new System.EventHandler(this.roundedButton1_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CCButtonGrid
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.roundedButton1);
            this.Name = "CCButtonGrid";
            this.Size = new System.Drawing.Size(949, 520);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton roundedButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timer1;
    }
}
