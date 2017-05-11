using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RMS.UserControls
{
	/// <summary>
	/// topLogo 的摘要说明。
	/// </summary>
	public class topLogo : System.Windows.Forms.ContainerControl
	{
		private System.Windows.Forms.PictureBox picToplogo;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public topLogo()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
			// 设置缺省属性
			_gradientColor1 = System.Drawing.Color.FromArgb(((System.Byte)(59)), ((System.Byte)(109)), ((System.Byte)(158)));
			_gradientColor2 = System.Drawing.Color.FromArgb(((System.Byte)(129)), ((System.Byte)(179)), ((System.Byte)(228)));
			base.Height = controlHeight;
			base.TabStop = false;
			base.Dock = System.Windows.Forms.DockStyle.Top;
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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(topLogo));
            this.picToplogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picToplogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picToplogo
            // 
            this.picToplogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picToplogo.BackgroundImage")));
            this.picToplogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.picToplogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picToplogo.InitialImage")));
            this.picToplogo.Location = new System.Drawing.Point(420, 0);
            this.picToplogo.Name = "picToplogo";
            this.picToplogo.Size = new System.Drawing.Size(80, 63);
            this.picToplogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picToplogo.TabIndex = 15;
            this.picToplogo.TabStop = false;
            // 
            // topLogo
            // 
            this.Controls.Add(this.picToplogo);
            this.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(500, 63);
            ((System.ComponentModel.ISupportInitialize)(this.picToplogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 属性定义
		private Color _gradientColor1;

		/// <summary>
		/// 渐变颜色1
		/// </summary>
		[Category("Appearance"), 
		Description("渐变颜色1"), 
		DefaultValue(null), 
		Localizable(true)]
		public Color gradientColor1
		{
			get
			{
				return _gradientColor1;
			}
			set
			{
				_gradientColor1 = value;
				this.Redraw();
			}
		}

		private Color _gradientColor2;

		/// <summary>
		/// 渐变颜色2
		/// </summary>
		[Category("Appearance"), 
		Description("渐变颜色2"), 
		DefaultValue(null), 
		Localizable(true)]
		public Color gradientColor2
		{
			get
			{
				return _gradientColor2;
			}
			set
			{
				_gradientColor2 = value;
				this.Redraw();
			}
		}

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}


		#endregion

		#region 重写的方法
		public void Redraw()
		{
			this.Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			
			this.Height = controlHeight;
			this.Redraw();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			Rectangle gradientRC = new Rectangle(0, 0, picToplogo.Left, this.Height);
			Brush gBrush = new LinearGradientBrush(gradientRC, _gradientColor1, _gradientColor2, LinearGradientMode.Horizontal);

			Graphics g = e.Graphics;

			g.FillRectangle(gBrush, gradientRC);

			gBrush.Dispose();
		}
		#endregion

		private const int controlHeight = 55;
	}
}
