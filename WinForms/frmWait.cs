using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using RMS.UserControls;

namespace RMS.WinForms

{
	/// <summary>
	/// Waiting 的摘要说明。
	/// </summary>
    public class Waiting : frmBase
	{
        private topLogo topLogo1;
        private System.Windows.Forms.Label lblPrompt;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ProgressBar pbWaiting;
		public System.Windows.Forms.Timer tmrAuto;
        private topLogo topLogo2;
        private PictureBox pictureBox2;
        //private Label lblPrompt;
        //private OD.Controls.topLogo topLogo2;
		private System.ComponentModel.IContainer components;

		public Waiting()
		{
             
            // .frmOrderDish = new rbtnPreSend(null, null);
            //info.Info.frmOrderDish.initDishCard();
            //info.Info.frmOrderDish.initCatBtns();



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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Waiting));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbWaiting = new System.Windows.Forms.ProgressBar();
            this.tmrAuto = new System.Windows.Forms.Timer(this.components);
            this.lblPrompt = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.topLogo2 = new RMS.UserControls.topLogo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pbWaiting
            // 
            this.pbWaiting.Location = new System.Drawing.Point(28, 151);
            this.pbWaiting.Name = "pbWaiting";
            this.pbWaiting.Size = new System.Drawing.Size(380, 23);
            this.pbWaiting.TabIndex = 96;
            // 
            // tmrAuto
            // 
            this.tmrAuto.Interval = 1000000000;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.BackColor = System.Drawing.SystemColors.Info;
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblPrompt.Location = new System.Drawing.Point(148, 95);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(0, 17);
            this.lblPrompt.TabIndex = 97;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(84, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 99;
            this.pictureBox2.TabStop = false;
            // 
            // topLogo2
            // 
            this.topLogo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo2.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo2.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo2.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo2.Location = new System.Drawing.Point(0, 0);
            this.topLogo2.Name = "topLogo2";
            this.topLogo2.Size = new System.Drawing.Size(444, 55);
            this.topLogo2.TabIndex = 98;
            this.topLogo2.TabStop = false;
            this.topLogo2.Text = "topLogo2";
            // 
            // Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(444, 258);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.topLogo2);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.pbWaiting);
            this.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Waiting";
            this.ShowInTaskbar = false;
            this.Text = "请稍候.....";
            this.Controls.SetChildIndex(this.pbWaiting, 0);
            this.Controls.SetChildIndex(this.lblPrompt, 0);
            this.Controls.SetChildIndex(this.topLogo2, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		static String _message = String.Empty;
		static Waiting wt = new Waiting();

		public static void Show(String message)
		{
			wt.tmrAuto.Tick += new System.EventHandler(wt.tmrAuto_Tick);
			wt.tmrAuto.Enabled = true;
			wt.tmrAuto.Start();

            wt.lblPrompt.Text = message;

			wt.Show();
			Application.DoEvents();
		}

		public static void Show(String message, int pgPercent)
		{
			//			wt.tmrAuto.Tick += new System.EventHandler(wt.tmrAuto_Tick);
			//			wt.tmrAuto.Stop();
			//			wt.tmrAuto.Enabled = false;

			wt.lblPrompt.Text = message;
			wt.pbWaiting.Value = pgPercent;

			wt.Show();
	
			Application.DoEvents();
		}

		public static new void Hide()
		{
			wt.tmrAuto.Stop();
			wt.tmrAuto.Enabled = false;
			wt.Close();
		}

		private void tmrAuto_Tick(object sender, System.EventArgs e)
		{
			wt.pbWaiting.Value += wt.pbWaiting.Step;

			if (wt.pbWaiting.Value > wt.pbWaiting.Maximum)
			{
				wt.pbWaiting.Value = wt.pbWaiting.Minimum;
			}

			Application.DoEvents();
		}
		
	}
}
