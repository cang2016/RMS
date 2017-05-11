namespace RMS.UserControls
{
    using System.Windows.Forms;
    partial class CCOrderDishInfo
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
            this.lblTableName = new Label();
            this.lblTableNo = new Label();
            this.lblTotalMoney = new Label();
            this.lblDishCount = new Label();
            this.radLabel1 = new Label();
            this.radLabel2 = new Label();
            this.radLabel3 = new Label();
            this.radLabel4 = new Label();
            //((System.ComponentModel.ISupportInitialize)(this.lblTableName)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblTableNo)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblTotalMoney)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblDishCount)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(86, 16);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(2, 2);
            this.lblTableName.TabIndex = 0;
            // 
            // lblTableNo
            // 
            this.lblTableNo.Location = new System.Drawing.Point(223, 16);
            this.lblTableNo.Name = "lblTableNo";
            this.lblTableNo.Size = new System.Drawing.Size(2, 2);
            this.lblTableNo.TabIndex = 1;
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.Location = new System.Drawing.Point(86, 43);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(2, 2);
            this.lblTotalMoney.TabIndex = 1;
            // 
            // lblDishCount
            // 
            this.lblDishCount.Location = new System.Drawing.Point(223, 43);
            this.lblDishCount.Name = "lblDishCount";
            this.lblDishCount.Size = new System.Drawing.Size(2, 2);
            this.lblDishCount.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(18, 16);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 17);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "台   号：";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(160, 16);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(56, 17);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "单  号：";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(18, 43);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(62, 17);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "总金额 ：";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(155, 43);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(62, 17);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = " 已点数：";
            // 
            // CCOrderDishInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblDishCount);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.lblTableNo);
            this.Name = "CCOrderDishInfo";
            this.Size = new System.Drawing.Size(300, 81);
            //((System.ComponentModel.ISupportInitialize)(this.lblTableName)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblTableNo)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblTotalMoney)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.lblDishCount)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblTableNo;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblDishCount;
        private System.Windows.Forms.Label radLabel1;
        private System.Windows.Forms.Label radLabel2;
        private System.Windows.Forms.Label radLabel4;
        private System.Windows.Forms.Label radLabel3;
    }
}
