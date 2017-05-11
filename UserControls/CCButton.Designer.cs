namespace RMS.UserControls
{
    partial class CCButton
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCButton));
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.SuspendLayout();
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedButton1.BackgroundImage")));
            this.roundedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton1.BorderColor = System.Drawing.Color.Red;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.Location = new System.Drawing.Point(0, 0);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(117, 91);
            this.roundedButton1.TabIndex = 1;
            this.roundedButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.roundedButton1.UseVisualStyleBackColor = true;
            this.roundedButton1.Visible = false;
            // 
            // CCButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundedButton1);
            this.Name = "CCButton";
            this.Size = new System.Drawing.Size(150, 91);
            this.ResumeLayout(false);

        }

        #endregion

        public  RoundedButton roundedButton1;

    }
}
