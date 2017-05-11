using CCWin.SkinControl;
using RMS.UserControls;
namespace RMS.WinForms
{
    partial class frmOrderDishes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderDishes));
            this.dgvOrderDish = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlHandWritten = new System.Windows.Forms.Panel();
            this.txtTasteWrite = new System.Windows.Forms.TextBox();
            this.txtHandWrite = new System.Windows.Forms.TextBox();
            this.ccMenuInfo1 = new RMS.UserControls.CCMenuInfo();
            this.btnHand = new RMS.UserControls.EllipseButton();
            this.txtPinyin = new RMS.UserControls.WaterMarkTextBox();
            this.ccOrderDishInfo1 = new RMS.UserControls.CCOrderDishInfo();
            this.rbtnPyCode = new RMS.UserControls.EllipseButton();
            this.topLogo1 = new RMS.UserControls.topLogo();
            this.btnColor2 = new RMS.UserControls.CCButton();
            this.btnColor1 = new RMS.UserControls.CCButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDish)).BeginInit();
            this.stsStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlHandWritten.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvOrderDish.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.dgvOrderDish.Size = new System.Drawing.Size(597, 533);
            this.dgvOrderDish.TabIndex = 1;
            this.dgvOrderDish.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvOrderDish_MouseClick);
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
            // stsStrip
            // 
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel4});
            this.stsStrip.Location = new System.Drawing.Point(0, 699);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(1362, 22);
            this.stsStrip.TabIndex = 18;
            this.stsStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "当前用户:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel2.Text = "当前时间:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel3.Text = "本机名与IP:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel5.Image")));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel6.Image")));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel6.Text = "toolStripStatusLabel6";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel7.Image")));
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel7.Text = "toolStripStatusLabel7";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel4.Image")));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOrderDish);
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 533);
            this.panel2.TabIndex = 177;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ccOrderDishInfo1);
            this.panel1.Location = new System.Drawing.Point(6, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 74);
            this.panel1.TabIndex = 178;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHand);
            this.groupBox1.Controls.Add(this.txtPinyin);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rbtnPyCode);
            this.groupBox1.Controls.Add(this.pnlHandWritten);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 570);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1287, 106);
            this.groupBox1.TabIndex = 165;
            this.groupBox1.TabStop = false;
            // 
            // pnlHandWritten
            // 
            this.pnlHandWritten.BackColor = System.Drawing.Color.Transparent;
            this.pnlHandWritten.Controls.Add(this.txtTasteWrite);
            this.pnlHandWritten.Controls.Add(this.txtHandWrite);
            this.pnlHandWritten.Location = new System.Drawing.Point(884, 13);
            this.pnlHandWritten.Name = "pnlHandWritten";
            this.pnlHandWritten.Size = new System.Drawing.Size(397, 74);
            this.pnlHandWritten.TabIndex = 177;
            this.pnlHandWritten.Tag = "-9999";
            this.pnlHandWritten.Visible = false;
            // 
            // txtTasteWrite
            // 
            this.txtTasteWrite.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTasteWrite.Location = new System.Drawing.Point(76, 41);
            this.txtTasteWrite.Name = "txtTasteWrite";
            this.txtTasteWrite.Size = new System.Drawing.Size(262, 30);
            this.txtTasteWrite.TabIndex = 30;
            this.txtTasteWrite.Tag = "";
            // 
            // txtHandWrite
            // 
            this.txtHandWrite.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHandWrite.Location = new System.Drawing.Point(76, 3);
            this.txtHandWrite.Name = "txtHandWrite";
            this.txtHandWrite.Size = new System.Drawing.Size(262, 30);
            this.txtHandWrite.TabIndex = 26;
            this.txtHandWrite.Tag = "";
            // 
            // ccMenuInfo1
            // 
            this.ccMenuInfo1.Location = new System.Drawing.Point(4, 67);
            this.ccMenuInfo1.Name = "ccMenuInfo1";
            this.ccMenuInfo1.Size = new System.Drawing.Size(676, 503);
            this.ccMenuInfo1.TabIndex = 166;
            // 
            // btnHand
            // 
            this.btnHand.ButtonBackColor = System.Drawing.Color.White;
            this.btnHand.Caption = "";
            this.btnHand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHand.HoverBackColor = System.Drawing.Color.SkyBlue;
            this.btnHand.Location = new System.Drawing.Point(786, 42);
            this.btnHand.MyCaption = "手写点菜";
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(80, 26);
            this.btnHand.TabIndex = 180;
            this.btnHand.Click += new System.EventHandler(this.rbtnHand_Click);
            // 
            // txtPinyin
            // 
            this.txtPinyin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPinyin.ForeColor = System.Drawing.Color.Magenta;
            this.txtPinyin.IsShowWaterText = true;
            this.txtPinyin.Location = new System.Drawing.Point(488, 45);
            this.txtPinyin.MarkText = "菜品编码或拼音码";
            this.txtPinyin.Name = "txtPinyin";
            this.txtPinyin.ParentControl = this;
            this.txtPinyin.Size = new System.Drawing.Size(174, 21);
            this.txtPinyin.StartSearch = false;
            this.txtPinyin.TabIndex = 179;
            this.txtPinyin.Text = "ddd码";
            this.txtPinyin.TextChanged += new System.EventHandler(this.txtPinyin_TextChanged);
            this.txtPinyin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPinyin_KeyDown);
            // 
            // ccOrderDishInfo1
            // 
            this.ccOrderDishInfo1.BackColor = System.Drawing.Color.Silver;
            this.ccOrderDishInfo1.DishCount = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.ccOrderDishInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccOrderDishInfo1.ForeColor = System.Drawing.Color.Black;
            this.ccOrderDishInfo1.Location = new System.Drawing.Point(0, 0);
            this.ccOrderDishInfo1.Name = "ccOrderDishInfo1";
            this.ccOrderDishInfo1.Size = new System.Drawing.Size(476, 74);
            this.ccOrderDishInfo1.TabIndex = 0;
            this.ccOrderDishInfo1.TableName = "";
            this.ccOrderDishInfo1.TableNo = "";
            this.ccOrderDishInfo1.TotalMoney = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            // 
            // rbtnPyCode
            // 
            this.rbtnPyCode.ButtonBackColor = System.Drawing.Color.White;
            this.rbtnPyCode.Caption = "";
            this.rbtnPyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPyCode.HoverBackColor = System.Drawing.Color.SkyBlue;
            this.rbtnPyCode.Location = new System.Drawing.Point(667, 42);
            this.rbtnPyCode.MyCaption = "拼音点菜";
            this.rbtnPyCode.Name = "rbtnPyCode";
            this.rbtnPyCode.Size = new System.Drawing.Size(100, 26);
            this.rbtnPyCode.TabIndex = 175;
            this.rbtnPyCode.Click += new System.EventHandler(this.rbtnPyCode_Click);
            // 
            // topLogo1
            // 
            this.topLogo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo1.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo1.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo1.Location = new System.Drawing.Point(0, 0);
            this.topLogo1.Name = "topLogo1";
            this.topLogo1.Size = new System.Drawing.Size(1287, 55);
            this.topLogo1.TabIndex = 0;
            this.topLogo1.TabStop = false;
            this.topLogo1.Text = "topLogo1";
            // 
            // btnColor2
            // 
            this.btnColor2.Location = new System.Drawing.Point(0, 0);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(150, 91);
            this.btnColor2.TabIndex = 0;
            // 
            // btnColor1
            // 
            this.btnColor1.Location = new System.Drawing.Point(0, 0);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(150, 91);
            this.btnColor1.TabIndex = 0;
            // 
            // frmOrderDishes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1287, 676);
            this.Controls.Add(this.ccMenuInfo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.topLogo1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderDishes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CC点菜系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrderDishes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDish)).EndInit();
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlHandWritten.ResumeLayout(false);
            this.pnlHandWritten.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private topLogo topLogo1;
        private System.Windows.Forms.DataGridView dgvOrderDish;
      
        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private CCButton  btnColor2;
        private CCButton  btnColor1;
        private System.Windows.Forms.Timer timer2;
        private XPButton radButton8;
        private XPButton radButton7;
        private XPButton radLabel2;
        private XPButton radLabel1;
        private XPButton btnAdd;
        private XPButton btnSend;
        private XPButton btnStatus;
        private XPButton btnCal;
        private XPButton btnDel;
        private XPButton btnSub;
        private XPButton btnCategory;
        private XPButton xpButton1;
        private XPButton btnPrint;
        private XPButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private EllipseButton rbtnPyCode;
        private System.Windows.Forms.Panel panel1;
        private CCOrderDishInfo ccOrderDishInfo1;
        internal WaterMarkTextBox txtPinyin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlHandWritten;
        private System.Windows.Forms.TextBox txtTasteWrite;
        private System.Windows.Forms.TextBox txtHandWrite;
        private EllipseButton btnHand;
        private CCMenuInfo ccMenuInfo1;

        //private AxMSFlexGridLib.AxMSFlexGrid flex;
        //private AxMSFlexGridLib.AxMSFlexGrid axMSFlexGrid1;
        //private AxYL_Button.AxchameleonButton axchameleonButton1;
        //private AxMSFlexGridLib.AxMSFlexGrid axMSFlexGrid2;
    }
}