using CCWin.SkinControl;
using RMS.UserControls;
using WeifenLuo.WinFormsUI.Docking;


namespace RMS.WinForms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.ccButtonGrid1 = new RMS.UserControls.CCButtonGrid();
            this.stsStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.stsStrip.Location = new System.Drawing.Point(0, 466);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(1329, 22);
            this.stsStrip.TabIndex = 1;
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
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            // 
            // ccButtonGrid1
            // 
            this.ccButtonGrid1.AllowDrop = true;
            this.ccButtonGrid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ccButtonGrid1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ccButtonGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ccButtonGrid1.ColMargin = 0;
            this.ccButtonGrid1.Cols = 7;
            this.ccButtonGrid1.Count = 1;
            this.ccButtonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccButtonGrid1.Location = new System.Drawing.Point(0, 0);
            this.ccButtonGrid1.Name = "ccButtonGrid1";
            this.ccButtonGrid1.RowMargin = 0;
            this.ccButtonGrid1.Rows = 4;
            this.ccButtonGrid1.Size = new System.Drawing.Size(1329, 466);
            this.ccButtonGrid1.TabIndex = 6;
            this.ccButtonGrid1.BtnClickEvent += new System.EventHandler(this.ccButtonGrid1_BtnClickEvent);
            this.ccButtonGrid1.BtnDoubleClickEvent += new System.EventHandler(this.ccButtonGrid1_BtnClickEvent);
            this.ccButtonGrid1.Click += new System.EventHandler(this.ccButtonGrid1_BtnClickEvent);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1329, 488);
            this.Controls.Add(this.ccButtonGrid1);
            this.Controls.Add(this.stsStrip);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "CC点菜系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
          private CCButtonGrid ccButtonGrid1;
         
    }
}