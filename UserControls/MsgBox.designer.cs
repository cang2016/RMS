namespace RMS.UserControls
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.MessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new RMS.UserControls.XPButton();
            this.btnCancel = new RMS.UserControls.XPButton();
            this.btnOK = new RMS.UserControls.XPButton();
            this.btnNo = new RMS.UserControls.XPButton();
            this.btnYes = new RMS.UserControls.XPButton();
            this.chkShowDetails = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.DetailsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageRichTextBox
            // 
            resources.ApplyResources(this.MessageRichTextBox, "MessageRichTextBox");
            this.MessageRichTextBox.BackColor = System.Drawing.Color.White;
            this.MessageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageRichTextBox.Name = "MessageRichTextBox";
            this.MessageRichTextBox.ReadOnly = true;
            this.MessageRichTextBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RMS.UserControls.Properties.Resources.Alert;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnNo);
            this.panelButtons.Controls.Add(this.btnYes);
            this.panelButtons.Controls.Add(this.chkShowDetails);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnClose
            // 
            this.btnClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnClose.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnCancel.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnOK.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNo
            // 
            this.btnNo.AdjustImageLocation = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNo.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnNo.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnNo.Name = "btnNo";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.AdjustImageLocation = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.BackColor = System.Drawing.SystemColors.Control;
            this.btnYes.BtnShape = RMS.UserControls.emunType.BtnShape.Rectangle;
            this.btnYes.BtnStyle = RMS.UserControls.emunType.XPStyle.Default;
            this.btnYes.Name = "btnYes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // chkShowDetails
            // 
            resources.ApplyResources(this.chkShowDetails, "chkShowDetails");
            this.chkShowDetails.BackColor = System.Drawing.SystemColors.Control;
            this.chkShowDetails.Checked = true;
            this.chkShowDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDetails.Name = "chkShowDetails";
            this.chkShowDetails.UseVisualStyleBackColor = false;
            this.chkShowDetails.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelDetail);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.DetailsRichTextBox);
            resources.ApplyResources(this.panelDetail, "panelDetail");
            this.panelDetail.Name = "panelDetail";
            // 
            // DetailsRichTextBox
            // 
            resources.ApplyResources(this.DetailsRichTextBox, "DetailsRichTextBox");
            this.DetailsRichTextBox.BackColor = System.Drawing.Color.White;
            this.DetailsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DetailsRichTextBox.Name = "DetailsRichTextBox";
            this.DetailsRichTextBox.ReadOnly = true;
            this.DetailsRichTextBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.MessageRichTextBox);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox2);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // MsgBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MessageBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox MessageRichTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelButtons;
        private XPButton btnYes;
        private XPButton btnClose;
        private XPButton btnOK;
        private XPButton btnCancel;
        private XPButton btnNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkShowDetails;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.RichTextBox DetailsRichTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
    }
}