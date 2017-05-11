using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using RMS.UserControls;
using RMS.UICommon;
using RMS.DataAccess;

namespace  RMS.WinForms
{
	/// <summary>
	/// FrmSelectArea 的摘要说明。
	/// </summary>
	public class frmSelectArea : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnTablesPre;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public int currentAreaID=0;
		private System.Windows.Forms.Button[] btnArea=new Button[9];
        public frmMain frmMain = CurrentUIForms.mainForm;
		private int currentPage=0;
        private topLogo topLogo1;
		private int maxPageCount=0;

		public frmSelectArea()
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTablesPre = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.topLogo1 = new topLogo();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTablesPre
            // 
            this.btnTablesPre.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTablesPre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTablesPre.Location = new System.Drawing.Point(334, 56);
            this.btnTablesPre.Name = "btnTablesPre";
            this.btnTablesPre.Size = new System.Drawing.Size(56, 142);
            this.btnTablesPre.TabIndex = 86;
            this.btnTablesPre.Text = "翻 页";
            this.btnTablesPre.Click += new System.EventHandler(this.btnTablesPre_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(112, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 48);
            this.button2.TabIndex = 88;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(223, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 48);
            this.button3.TabIndex = 90;
            this.button3.Text = "button3";
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(1, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 48);
            this.button4.TabIndex = 93;
            this.button4.Text = "button4";
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(112, 103);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 48);
            this.button5.TabIndex = 92;
            this.button5.Text = "button5";
            this.button5.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(223, 103);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 48);
            this.button6.TabIndex = 91;
            this.button6.Text = "button6";
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.Location = new System.Drawing.Point(1, 150);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 48);
            this.button7.TabIndex = 96;
            this.button7.Text = "button7";
            this.button7.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.Location = new System.Drawing.Point(112, 150);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 48);
            this.button8.TabIndex = 95;
            this.button8.Text = "button8";
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.Location = new System.Drawing.Point(223, 150);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 48);
            this.button9.TabIndex = 94;
            this.button9.Text = "button9";
            // 
            // topLogo1
            // 
            this.topLogo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo1.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo1.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo1.Location = new System.Drawing.Point(0, 0);
            this.topLogo1.Name = "topLogo1";
            this.topLogo1.Size = new System.Drawing.Size(392, 55);
            this.topLogo1.TabIndex = 97;
            this.topLogo1.TabStop = false;
            this.topLogo1.Text = "topLogo1";
            // 
            // FrmSelectArea
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(392, 200);
            this.ControlBox = false;
            this.Controls.Add(this.topLogo1);
            this.Controls.Add(this.btnTablesPre);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmSelectArea";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "选择区域";
            this.Load += new System.EventHandler(this.FrmSelectArea_Load);
            this.Enter += new System.EventHandler(this.FrmSelectArea_Enter);
            this.Leave += new System.EventHandler(this.FrmSelectArea_Leave);
            this.Move += new System.EventHandler(this.FrmSelectArea_Move);
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmSelectArea_Load(object sender, System.EventArgs e)
		{
			this.btnArea[0]=this.button1;
			this.btnArea[1]=this.button2;
			this.btnArea[2]=this.button3;
			this.btnArea[3]=this.button4;
			this.btnArea[4]=this.button5;
			this.btnArea[5]=this.button6;
			this.btnArea[6]=this.button7;
			this.btnArea[7]=this.button8;
			this.btnArea[8]=this.button9;
            this.BindArea();
		}

        private void BindArea()
        {
            string sql = "select 0 as Id,'-所有桌台-' AS Name union Select id,name From areas Where id In (Select area_id From salespointarea Where SalesPoint_Id = " + CurrentSystemInfo.SalesPoint.Id.ToString() + ")";

            System.Data.DataTable dt =new SqlServerExecute().FillDataTable( System.Data.CommandType.Text,sql);
            if (dt.DefaultView.Count > 0)
            {
                this.maxPageCount = Convert.ToInt32(dt.DefaultView.Count / 9) + 1;
            }
            if (this.maxPageCount <= 0) this.maxPageCount = 1;
            if (this.currentPage < 1) this.currentPage = 1;
            if (this.currentPage > this.maxPageCount) this.currentPage = this.maxPageCount;

            int i = 0;
            System.Drawing.Font f = new Font("宋体", 10);
            for (i = 0; i < 9; i++)
            {
                this.btnArea[i].Text = "";
                this.btnArea[i].Tag = "";
                this.btnArea[i].Font = f;
                if (((this.currentPage - 1) * 9) + i + 1 <= dt.DefaultView.Count)
                {
                    this.btnArea[i].Tag = Convert.ToInt32(dt.DefaultView[((this.currentPage - 1) * 9) + i]["Id"]);
                    this.btnArea[i].Text = dt.DefaultView[((this.currentPage - 1) * 9) + i]["Name"].ToString();
                }
            }
            for (i = 0; i < this.btnArea.Length; i++)
            {
                if (!this.btnArea[i].Tag.ToString().Equals(""))
                {
                    if (this.currentAreaID == Convert.ToInt32(this.btnArea[i].Tag))
                    {
                        this.btnArea[i].Font = new Font("宋体", 10, System.Drawing.FontStyle.Bold);
                    }
                }
            }

            if (!this.btnArea[1].Tag.ToString().Equals(""))
                this.currentAreaID = Convert.ToInt32(this.btnArea[1].Tag);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            if(btn.Tag.ToString().Equals(""))
                return;
            this.currentAreaID = Convert.ToInt32(btn.Tag);
            //this.frmMain.currentAreaID=this.currentAreaID;
            if(frmMain == null)
            {
                frmMain = new frmMain();
            }
            frmMain.CurrentAreaId = this.currentAreaID;
           
            this.frmMain.CurrentAreaName = btn.Text;
            this.frmMain.ChangeArea();
            //this.BindArea();
        }

		private void FrmSelectArea_Leave(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void FrmSelectArea_Move(object sender, System.EventArgs e)
		{
			
		}

		private void FrmSelectArea_Enter(object sender, System.EventArgs e)
		{
			this.Left=517;
			this.Top=107;
		}

		private void btnTablesPre_Click(object sender, System.EventArgs e)
		{
			this.currentPage++;
			if(this.currentPage>this.maxPageCount) this.currentPage=0;
            this.BindArea();
		}
	}
}