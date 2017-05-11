using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace RMS.WinForms
{
	/// <summary>
	/// frmSimpleCalc 的摘要说明。
	/// </summary>
	public class frmSimpleCalc : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button13;
		public System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		public bool isNotChange=false;
		public bool ifChangeNum=false;

		public frmSimpleCalc()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button15);
			this.groupBox1.Controls.Add(this.button14);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.button13);
			this.groupBox1.Controls.Add(this.button12);
			this.groupBox1.Controls.Add(this.button11);
			this.groupBox1.Controls.Add(this.button10);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Controls.Add(this.button9);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(202, 362);
			this.groupBox1.TabIndex = 40;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数字功能区";
			// 
			// button15
			// 
			this.button15.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button15.Location = new System.Drawing.Point(136, 208);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(54, 42);
			this.button15.TabIndex = 28;
			this.button15.Text = "负";
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// button14
			// 
			this.button14.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button14.Location = new System.Drawing.Point(76, 208);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(54, 42);
			this.button14.TabIndex = 27;
			this.button14.Text = ".";
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(16, 27);
			this.textBox1.MaxLength = 10;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(176, 26);
			this.textBox1.TabIndex = 26;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button13
			// 
			this.button13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button13.Location = new System.Drawing.Point(103, 304);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(88, 46);
			this.button13.TabIndex = 25;
			this.button13.Text = "关 闭";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button12
			// 
			this.button12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button12.Location = new System.Drawing.Point(16, 304);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(88, 46);
			this.button12.TabIndex = 24;
			this.button12.Text = "确 定";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button11
			// 
			this.button11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button11.Location = new System.Drawing.Point(16, 256);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(176, 41);
			this.button11.TabIndex = 23;
			this.button11.Text = "重新输入";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button10.Location = new System.Drawing.Point(16, 208);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(54, 42);
			this.button10.TabIndex = 22;
			this.button10.Text = "0";
			this.button10.Click += new System.EventHandler(this.button1_Click);
			// 
			// button7
			// 
			this.button7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button7.Location = new System.Drawing.Point(136, 161);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(54, 41);
			this.button7.TabIndex = 21;
			this.button7.Text = "9";
			this.button7.Click += new System.EventHandler(this.button1_Click);
			// 
			// button8
			// 
			this.button8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button8.Location = new System.Drawing.Point(76, 161);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(54, 41);
			this.button8.TabIndex = 20;
			this.button8.Text = "8";
			this.button8.Click += new System.EventHandler(this.button1_Click);
			// 
			// button9
			// 
			this.button9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button9.Location = new System.Drawing.Point(16, 161);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(54, 41);
			this.button9.TabIndex = 19;
			this.button9.Text = "7";
			this.button9.Click += new System.EventHandler(this.button1_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button4.Location = new System.Drawing.Point(136, 112);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(54, 41);
			this.button4.TabIndex = 18;
			this.button4.Text = "6";
			this.button4.Click += new System.EventHandler(this.button1_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button5.Location = new System.Drawing.Point(76, 112);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(54, 41);
			this.button5.TabIndex = 17;
			this.button5.Text = "5";
			this.button5.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button6.Location = new System.Drawing.Point(16, 112);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(54, 41);
			this.button6.TabIndex = 16;
			this.button6.Text = "4";
			this.button6.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button3.Location = new System.Drawing.Point(136, 63);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(54, 41);
			this.button3.TabIndex = 15;
			this.button3.Text = "3";
			this.button3.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button2.Location = new System.Drawing.Point(76, 63);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(54, 41);
			this.button2.TabIndex = 14;
			this.button2.Text = "2";
			this.button2.Click += new System.EventHandler(this.button1_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(16, 63);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(54, 41);
			this.button1.TabIndex = 13;
			this.button1.Text = "1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmSimpleCalc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(216, 373);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "FrmSimpleCalc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数字键";
			this.Load += new System.EventHandler(this.frmSimpleCalc_Load);
			this.Activated += new System.EventHandler(this.FrmSimpleCalc_Activated);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmSimpleCalc_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Button SBtnValue=(System.Windows.Forms.Button) sender;
			if(ifChangeNum)
			{
				this.textBox1.Text=SBtnValue.Text;
				ifChangeNum=false;
			}
			else
			{
				this.textBox1.Text=this.textBox1.Text + SBtnValue.Text;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "2";
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "3";
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "4";
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "5";
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "6";
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "7";
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "8";
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "9";
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text=this.textBox1.Text + "0";
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text="";
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			if(!this.textBox1.Text.Trim().Equals(""))
			{
				if(Information.IsNumeric(this.textBox1.Text))
				{
					this.isNotChange=false;
					this.Close();
				}
			}
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			isNotChange=true;
			this.Close();
		}

		private void button14_Click(object sender, System.EventArgs e)
		{
			if(!this.textBox1.Text.Equals(""))
			{
				if(this.textBox1.Text.IndexOf(".")==-1)
				{
					this.textBox1.Text=this.textBox1.Text+".";
				}
			}
		}

		private void button15_Click(object sender, System.EventArgs e)
		{
            if (Information.IsNumeric(this.textBox1.Text))
			{
				this.textBox1.Text=Convert.ToString((Convert.ToDecimal(this.textBox1.Text)*-1));
			}
		}

		private void FrmSimpleCalc_Activated(object sender, System.EventArgs e)
		{
		
		}
	}
}