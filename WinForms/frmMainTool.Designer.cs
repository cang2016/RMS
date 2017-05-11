namespace RMS.WinForms
{
    partial class frmMainTool
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grbDishTableInfo = new System.Windows.Forms.GroupBox();
            this.lblOpenDate = new System.Windows.Forms.Label();
            this.lblCarNo = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTableOrderNo = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblDishTableNo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTableCount = new System.Windows.Forms.Label();
            this.lblTotalGuestCount = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbDishTableInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 146);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbDishTableInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 120);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前台桌信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grbDishTableInfo
            // 
            this.grbDishTableInfo.BackColor = System.Drawing.Color.Silver;
            this.grbDishTableInfo.Controls.Add(this.lblOpenDate);
            this.grbDishTableInfo.Controls.Add(this.lblCarNo);
            this.grbDishTableInfo.Controls.Add(this.lblCount);
            this.grbDishTableInfo.Controls.Add(this.lblTableOrderNo);
            this.grbDishTableInfo.Controls.Add(this.lblArea);
            this.grbDishTableInfo.Controls.Add(this.lblType);
            this.grbDishTableInfo.Controls.Add(this.lblTableName);
            this.grbDishTableInfo.Controls.Add(this.lblDishTableNo);
            this.grbDishTableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDishTableInfo.Location = new System.Drawing.Point(3, 3);
            this.grbDishTableInfo.Name = "grbDishTableInfo";
            this.grbDishTableInfo.Size = new System.Drawing.Size(503, 114);
            this.grbDishTableInfo.TabIndex = 4;
            this.grbDishTableInfo.TabStop = false;
            // 
            // lblOpenDate
            // 
            this.lblOpenDate.AutoSize = true;
            this.lblOpenDate.Location = new System.Drawing.Point(203, 87);
            this.lblOpenDate.Name = "lblOpenDate";
            this.lblOpenDate.Size = new System.Drawing.Size(65, 12);
            this.lblOpenDate.TabIndex = 9;
            this.lblOpenDate.Text = "开台时间：";
            // 
            // lblCarNo
            // 
            this.lblCarNo.AutoSize = true;
            this.lblCarNo.Location = new System.Drawing.Point(215, 63);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(53, 12);
            this.lblCarNo.TabIndex = 6;
            this.lblCarNo.Text = "泊车号：";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(227, 39);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 12);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "人数：";
            // 
            // lblTableOrderNo
            // 
            this.lblTableOrderNo.AutoSize = true;
            this.lblTableOrderNo.Location = new System.Drawing.Point(227, 15);
            this.lblTableOrderNo.Name = "lblTableOrderNo";
            this.lblTableOrderNo.Size = new System.Drawing.Size(41, 12);
            this.lblTableOrderNo.TabIndex = 4;
            this.lblTableOrderNo.Text = "单号：";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(29, 87);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(65, 12);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "台桌区域：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(29, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(65, 12);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "台桌类型：";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(17, 39);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(77, 12);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "台桌包厢名：";
            // 
            // lblDishTableNo
            // 
            this.lblDishTableNo.AutoSize = true;
            this.lblDishTableNo.Location = new System.Drawing.Point(17, 15);
            this.lblDishTableNo.Name = "lblDishTableNo";
            this.lblDishTableNo.Size = new System.Drawing.Size(77, 12);
            this.lblDishTableNo.TabIndex = 0;
            this.lblDishTableNo.Text = "台桌包厢号：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 120);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "当天营业信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTableCount);
            this.groupBox1.Controls.Add(this.lblTotalGuestCount);
            this.groupBox1.Controls.Add(this.lblTotalMoney);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "待结数：";
            // 
            // lblTableCount
            // 
            this.lblTableCount.AutoSize = true;
            this.lblTableCount.Location = new System.Drawing.Point(21, 72);
            this.lblTableCount.Name = "lblTableCount";
            this.lblTableCount.Size = new System.Drawing.Size(53, 12);
            this.lblTableCount.TabIndex = 11;
            this.lblTableCount.Text = "总桌数：";
            // 
            // lblTotalGuestCount
            // 
            this.lblTotalGuestCount.AutoSize = true;
            this.lblTotalGuestCount.Location = new System.Drawing.Point(252, 44);
            this.lblTotalGuestCount.Name = "lblTotalGuestCount";
            this.lblTotalGuestCount.Size = new System.Drawing.Size(53, 12);
            this.lblTotalGuestCount.TabIndex = 10;
            this.lblTotalGuestCount.Text = "总人数：";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Location = new System.Drawing.Point(21, 44);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(53, 12);
            this.lblTotalMoney.TabIndex = 9;
            this.lblTotalMoney.Text = "总金额：";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MenuName,
            this.Amount,
            this.UnitName,
            this.TotalMoney});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 146);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.Size = new System.Drawing.Size(517, 402);
            this.dgvOrders.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // MenuName
            // 
            this.MenuName.HeaderText = "菜名";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            this.MenuName.Width = 130;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "数量";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 65;
            // 
            // UnitName
            // 
            this.UnitName.HeaderText = "单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 60;
            // 
            // TotalMoney
            // 
            this.TotalMoney.HeaderText = "金额";
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.ReadOnly = true;
            this.TotalMoney.Width = 80;
            // 
            // frmMainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 548);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmMainTool";
            this.Text = "Properties";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbDishTableInfo.ResumeLayout(false);
            this.grbDishTableInfo.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grbDishTableInfo;
        private System.Windows.Forms.Label lblOpenDate;
        private System.Windows.Forms.Label lblCarNo;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTableOrderNo;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblDishTableNo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTableCount;
        private System.Windows.Forms.Label lblTotalGuestCount;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
    }
}