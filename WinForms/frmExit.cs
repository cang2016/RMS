using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using RMS.UserControls;

namespace RMS.WinForms
{
	/// <summary>
	/// ExitForm 的摘要说明。
	/// </summary>
	public class frmExit : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ComboBox cbOperations;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.PictureBox picLoginBackground;
        private topLogo topLogo1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmExit()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExit));
            this.cbOperations = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.picLoginBackground = new System.Windows.Forms.PictureBox();
            this.topLogo1 = new topLogo();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOperations
            // 
            this.cbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperations.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOperations.Items.AddRange(new object[] {
            "注销系统",
            "退出系统"});
            this.cbOperations.Location = new System.Drawing.Point(154, 219);
            this.cbOperations.Name = "cbOperations";
            this.cbOperations.Size = new System.Drawing.Size(232, 25);
            this.cbOperations.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(151, 189);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 17);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "您希望系统做什么？";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(432, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(340, 377);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 28);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定";
            // 
            // picLoginBackground
            // 
            this.picLoginBackground.BackColor = System.Drawing.Color.White;
            this.picLoginBackground.Location = new System.Drawing.Point(1, 1);
            this.picLoginBackground.Name = "picLoginBackground";
            this.picLoginBackground.Size = new System.Drawing.Size(534, 430);
            this.picLoginBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoginBackground.TabIndex = 14;
            this.picLoginBackground.TabStop = false;
            // 
            // topLogo1
            // 
            this.topLogo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo1.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo1.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo1.Location = new System.Drawing.Point(0, 0);
            this.topLogo1.Name = "topLogo1";
            this.topLogo1.Size = new System.Drawing.Size(536, 55);
            this.topLogo1.TabIndex = 15;
            this.topLogo1.TabStop = false;
            this.topLogo1.Text = "topLogo1";
            // 
            // frmExit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 432);
            this.Controls.Add(this.topLogo1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbOperations);
            this.Controls.Add(this.picLoginBackground);
            this.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退出/注销";
            ((System.ComponentModel.ISupportInitialize)(this.picLoginBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public int SelectOperation()
		{
			cbOperations.SelectedIndex = 1;
			
			if(this.ShowDialog() != DialogResult.OK)
				return 0;							// 取消操作
			else
			{
				if(cbOperations.SelectedIndex == 0)
					return 1;						// 注销
				else
					return 2;						// 退出
			}
		}

      


	}
}
