namespace RMS.WinForms
{
    partial class frmMainInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpDishTableInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkReservation = new System.Windows.Forms.CheckBox();
            this.chkHasServed = new System.Windows.Forms.CheckBox();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.chkOpened = new System.Windows.Forms.CheckBox();
            this.gpbShow = new System.Windows.Forms.GroupBox();
            this.customLabel1 = new RMS.UserControls.CustomLabel(this.components);
            this.roundedButton2 = new RMS.UserControls.RoundedButton();
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.txtSearchTable = new RMS.UserControls.WaterMarkTextBox();
            this.lblTableNo = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.grpDishTableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpbShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpDishTableInfo);
            this.panel1.Controls.Add(this.gpbShow);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 156);
            this.panel1.TabIndex = 0;
            // 
            // grpDishTableInfo
            // 
            this.grpDishTableInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpDishTableInfo.Controls.Add(this.pictureBox4);
            this.grpDishTableInfo.Controls.Add(this.pictureBox3);
            this.grpDishTableInfo.Controls.Add(this.pictureBox2);
            this.grpDishTableInfo.Controls.Add(this.pictureBox1);
            this.grpDishTableInfo.Controls.Add(this.chkReservation);
            this.grpDishTableInfo.Controls.Add(this.chkHasServed);
            this.grpDishTableInfo.Controls.Add(this.chkEmpty);
            this.grpDishTableInfo.Controls.Add(this.chkOpened);
            this.grpDishTableInfo.Location = new System.Drawing.Point(525, 14);
            this.grpDishTableInfo.Name = "grpDishTableInfo";
            this.grpDishTableInfo.Size = new System.Drawing.Size(497, 130);
            this.grpDishTableInfo.TabIndex = 17;
            this.grpDishTableInfo.TabStop = false;
            this.grpDishTableInfo.Text = "台桌状态";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::RMS.WinForms.Properties.Resources.a_11;
            this.pictureBox4.Location = new System.Drawing.Point(409, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 50);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RMS.WinForms.Properties.Resources.a_21;
            this.pictureBox3.Location = new System.Drawing.Point(283, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 50);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RMS.WinForms.Properties.Resources.a_2;
            this.pictureBox2.Location = new System.Drawing.Point(157, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 50);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RMS.WinForms.Properties.Resources.a_1;
            this.pictureBox1.Location = new System.Drawing.Point(31, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // chkReservation
            // 
            this.chkReservation.AutoSize = true;
            this.chkReservation.Location = new System.Drawing.Point(411, 76);
            this.chkReservation.Name = "chkReservation";
            this.chkReservation.Size = new System.Drawing.Size(60, 16);
            this.chkReservation.TabIndex = 8;
            this.chkReservation.Text = "清理中";
            this.chkReservation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReservation.UseVisualStyleBackColor = true;
            this.chkReservation.CheckedChanged += new System.EventHandler(this.chkReservation_CheckedChanged);
            // 
            // chkHasServed
            // 
            this.chkHasServed.AutoSize = true;
            this.chkHasServed.Location = new System.Drawing.Point(285, 76);
            this.chkHasServed.Name = "chkHasServed";
            this.chkHasServed.Size = new System.Drawing.Size(60, 16);
            this.chkHasServed.TabIndex = 5;
            this.chkHasServed.Text = "已上菜";
            this.chkHasServed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHasServed.UseVisualStyleBackColor = true;
            this.chkHasServed.CheckedChanged += new System.EventHandler(this.chkHasServed_CheckedChanged);
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.Location = new System.Drawing.Point(45, 76);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(48, 16);
            this.chkEmpty.TabIndex = 3;
            this.chkEmpty.Text = "空台";
            this.chkEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEmpty.UseVisualStyleBackColor = true;
            this.chkEmpty.CheckedChanged += new System.EventHandler(this.chkEmpty_CheckedChanged);
            // 
            // chkOpened
            // 
            this.chkOpened.AutoSize = true;
            this.chkOpened.Location = new System.Drawing.Point(159, 76);
            this.chkOpened.Name = "chkOpened";
            this.chkOpened.Size = new System.Drawing.Size(60, 16);
            this.chkOpened.TabIndex = 4;
            this.chkOpened.Text = "已开台";
            this.chkOpened.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOpened.UseVisualStyleBackColor = true;
            this.chkOpened.CheckedChanged += new System.EventHandler(this.chkOpened_CheckedChanged);
            // 
            // gpbShow
            // 
            this.gpbShow.Controls.Add(this.customLabel1);
            this.gpbShow.Controls.Add(this.roundedButton2);
            this.gpbShow.Controls.Add(this.roundedButton1);
            this.gpbShow.Controls.Add(this.txtSearchTable);
            this.gpbShow.Controls.Add(this.lblTableNo);
            this.gpbShow.Location = new System.Drawing.Point(8, 14);
            this.gpbShow.Name = "gpbShow";
            this.gpbShow.Size = new System.Drawing.Size(512, 130);
            this.gpbShow.TabIndex = 5;
            this.gpbShow.TabStop = false;
            this.gpbShow.Text = "显示选项";
            // 
            // customLabel1
            // 
            this.customLabel1.LineDistance = 5;
            this.customLabel1.Location = new System.Drawing.Point(314, 44);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(71, 19);
            this.customLabel1.TabIndex = 7;
            this.customLabel1.Text = "台桌区域：";
            // 
            // roundedButton2
            // 
            this.roundedButton2.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.Location = new System.Drawing.Point(161, 31);
            this.roundedButton2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(115, 38);
            this.roundedButton2.TabIndex = 6;
            this.roundedButton2.Text = "台桌类型";
            this.roundedButton2.UseVisualStyleBackColor = true;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.Location = new System.Drawing.Point(25, 31);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(115, 38);
            this.roundedButton1.TabIndex = 5;
            this.roundedButton1.Text = "区 域";
            this.roundedButton1.UseVisualStyleBackColor = true;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // txtSearchTable
            // 
            this.txtSearchTable.ForeColor = System.Drawing.Color.LightGray;
            this.txtSearchTable.IsShowWaterText = true;
            this.txtSearchTable.Location = new System.Drawing.Point(382, 38);
            this.txtSearchTable.MarkText = "搜索台桌名称";
            this.txtSearchTable.Multiline = true;
            this.txtSearchTable.Name = "txtSearchTable";
            this.txtSearchTable.ParentControl = null;
            this.txtSearchTable.Size = new System.Drawing.Size(124, 26);
            this.txtSearchTable.StartSearch = false;
            this.txtSearchTable.TabIndex = 4;
            this.txtSearchTable.Text = "搜索台桌名称";
            // 
            // lblTableNo
            // 
            this.lblTableNo.AutoSize = true;
            this.lblTableNo.Location = new System.Drawing.Point(39, 94);
            this.lblTableNo.Name = "lblTableNo";
            this.lblTableNo.Size = new System.Drawing.Size(0, 12);
            this.lblTableNo.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "EmptyTable.gif");
            this.imageList1.Images.SetKeyName(1, "CleanTable.jpg");
            this.imageList1.Images.SetKeyName(2, "NoDish.gif");
            this.imageList1.Images.SetKeyName(3, "HasDish.jpg");
            // 
            // frmMainInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 185);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmMainInfo";
            this.Text = "frmMainInfo";
            this.panel1.ResumeLayout(false);
            this.grpDishTableInfo.ResumeLayout(false);
            this.grpDishTableInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpbShow.ResumeLayout(false);
            this.gpbShow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gpbShow;
        private System.Windows.Forms.CheckBox chkReservation;
        private System.Windows.Forms.CheckBox chkHasServed;
        private System.Windows.Forms.CheckBox chkOpened;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.Label lblTableNo;
        private System.Windows.Forms.GroupBox grpDishTableInfo;
        private UserControls.RoundedButton roundedButton2;
        private UserControls.RoundedButton roundedButton1;
        public UserControls.WaterMarkTextBox txtSearchTable;
        private UserControls.CustomLabel customLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}