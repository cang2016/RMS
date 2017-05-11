using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UI
{
	/// <summary>
	/// FrmOrderDishMode 的摘要说明。
	/// </summary>
	public class frmOrderDishMode : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
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
		public string orderDishMode="";

		public frmOrderDishMode()
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "即起";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "叫起";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "免做";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 40);
            this.button4.TabIndex = 2;
            this.button4.Text = "外卖";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(79, 117);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 40);
            this.button5.TabIndex = 7;
            this.button5.Text = "全部免做";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Location = new System.Drawing.Point(79, 78);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 40);
            this.button6.TabIndex = 6;
            this.button6.Text = "全部外卖";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(79, 39);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 40);
            this.button7.TabIndex = 5;
            this.button7.Text = "全部叫起";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(79, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(80, 40);
            this.button8.TabIndex = 4;
            this.button8.Text = "全部即起";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(0, 156);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(159, 40);
            this.button9.TabIndex = 8;
            this.button9.Text = "关闭";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // frmOrderDishMode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(159, 197);
            this.ControlBox = false;
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmOrderDishMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "上菜模式选择";
            this.Load += new System.EventHandler(this.FrmOrderDishMode_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmOrderDishMode_Load(object sender, System.EventArgs e)
		{
			
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button1.Text;
			this.Close();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button8.Text;
			this.Close();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button2.Text;
			this.Close();
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button7.Text;
			this.Close();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button4.Text;
			this.Close();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button6.Text;
			this.Close();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button3.Text;
			this.Close();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			this.orderDishMode=button5.Text;
			this.Close();
		}
	}
}