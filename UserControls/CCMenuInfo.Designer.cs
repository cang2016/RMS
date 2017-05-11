using RMS.UserControls.Properties;

namespace RMS.UserControls
{
    partial class CCMenuInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private XPButton btnAdd;
        private XPButton btnSend;
        private XPButton btnStatus;
        private XPButton btnCal;
        private XPButton btnDel;
        private XPButton btnSub;
        private XPButton btnExport;



        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCMenuInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExport = new RMS.UserControls.XPButton();
            this.btnSend = new RMS.UserControls.XPButton();
            this.btnStatus = new RMS.UserControls.XPButton();
            this.btnCal = new RMS.UserControls.XPButton();
            this.btnDel = new RMS.UserControls.XPButton();
            this.btnSub = new RMS.UserControls.XPButton();
            this.btnAdd = new RMS.UserControls.XPButton();
            this.dgvOrderDish = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new RMS.UserControls.XPButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDish)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnExport.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnExport.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(577, 404);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 51);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "导出";
            // 
            // btnSend
            // 
            this.btnSend.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnSend.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnSend.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(577, 296);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 51);
            this.btnSend.TabIndex = 172;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnStatus
            // 
            this.btnStatus.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnStatus.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnStatus.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnStatus.Image")));
            this.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatus.Location = new System.Drawing.Point(577, 242);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(84, 51);
            this.btnStatus.TabIndex = 171;
            this.btnStatus.Text = "状态";
            this.btnStatus.UseVisualStyleBackColor = true;
            // 
            // btnCal
            // 
            this.btnCal.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnCal.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnCal.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnCal.Image = ((System.Drawing.Image)(resources.GetObject("btnCal.Image")));
            this.btnCal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCal.Location = new System.Drawing.Point(577, 188);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(84, 51);
            this.btnCal.TabIndex = 170;
            this.btnCal.Text = "计算器";
            this.btnCal.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnDel.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnDel.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(577, 134);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(84, 51);
            this.btnDel.TabIndex = 169;
            this.btnDel.Text = "删";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnSub
            // 
            this.btnSub.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnSub.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnSub.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnSub.Image = ((System.Drawing.Image)(resources.GetObject("btnSub.Image")));
            this.btnSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSub.Location = new System.Drawing.Point(577, 80);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(84, 51);
            this.btnSub.TabIndex = 168;
            this.btnSub.Text = "减";
            this.btnSub.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnAdd.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnAdd.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(577, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 51);
            this.btnAdd.TabIndex = 167;
            this.btnAdd.Text = "加";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvOrderDish
            // 
            this.dgvOrderDish.AllowUserToAddRows = false;
            this.dgvOrderDish.AllowUserToDeleteRows = false;
            this.dgvOrderDish.AllowUserToOrderColumns = true;
            this.dgvOrderDish.AllowUserToResizeColumns = false;
            this.dgvOrderDish.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvOrderDish.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderDish.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvOrderDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrderDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DishName,
            this.Amount,
            this.Price,
            this.TotalMoney,
            this.UnitName,
            this.State});
            this.dgvOrderDish.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvOrderDish.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderDish.MultiSelect = false;
            this.dgvOrderDish.Name = "dgvOrderDish";
            this.dgvOrderDish.ReadOnly = true;
            this.dgvOrderDish.RowHeadersVisible = false;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgvOrderDish.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderDish.RowTemplate.Height = 23;
            this.dgvOrderDish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrderDish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDish.Size = new System.Drawing.Size(571, 484);
            this.dgvOrderDish.TabIndex = 173;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 50;
            // 
            // DishName
            // 
            this.DishName.HeaderText = "菜名";
            this.DishName.Name = "DishName";
            this.DishName.ReadOnly = true;
            this.DishName.Width = 170;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "数量";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // Price
            // 
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 90;
            // 
            // TotalMoney
            // 
            this.TotalMoney.HeaderText = "金额";
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.ReadOnly = true;
            // 
            // UnitName
            // 
            this.UnitName.HeaderText = "单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 70;
            // 
            // State
            // 
            this.State.HeaderText = "状态";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnPrint.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnPrint.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(577, 350);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 51);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            // 
            // CCMenuInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvOrderDish);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnAdd);
            this.Name = "CCMenuInfo";
            this.Size = new System.Drawing.Size(665, 484);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDish)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private XPButton btnPrint;
    }
}
