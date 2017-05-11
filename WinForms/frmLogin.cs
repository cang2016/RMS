using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using RMS.UserControls;
using RMS.DataAccess;
using RMS.Business;
using RMS.Logging;
using RMS.Utility;
using CCWin.SkinControl;
using DockSample;
using RMS.UICommon;


namespace RMS.WinForms
{
    /// <summary>
    /// loginForm 的摘要说明。
    /// </summary>
    public class frmLogin : frmBase
    {
        private CCWin.SkinControl.SkinContextMenuStrip menuStripId;


        //private CCWin.SkinControl.SkinTextBox txtLoginName;
        //private CCWin.SkinControl.SkinComboBox cmbUsers;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnSetDB;
        //private InputUserNameInitial cmbUsersList;
        private topLogo topLogo1;
        //private CCWin.SkinControl.SkinTextBox txtPassword;
        //private XPButton xpButton1;
        //private AxYL_Button.AxchameleonButton axchameleonButton1;
        private ColorLabel colorLabel1;
        private CustomLabel customLabel1;
        private WaterMarkTextBox waterMarkTextBox1;
        private RoundedButton roundedButton1;
        private CCWin.SkinControl.SkinButton buttonId;
        private CCWin.SkinControl.SkinPanel panelHeadImage;
        private IContainer components;
        private CCWin.SkinControl.SkinTextBox textBoxPwd;
        private RoundedButton roundedButton2;
        private WaterMarkTextBox txtLoginName;
        private topLogo topLogo2;



        private string currentNickName = "CC";

        public frmLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //SysConfigInfo.frmOrderDish = new frmOrderDishes(null, null);
            //SysConfigInfo.frmOrderDish.InitRootMenuCategoriesBtns();

            //SysConfigInfo.frmOrderDish.InitDishCard();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnSetDB = new System.Windows.Forms.Button();
            this.buttonId = new CCWin.SkinControl.SkinButton();
            this.panelHeadImage = new CCWin.SkinControl.SkinPanel();
            this.menuStripId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.textBoxPwd = new CCWin.SkinControl.SkinTextBox();
            this.topLogo2 = new RMS.UserControls.topLogo();
            this.txtLoginName = new RMS.UserControls.WaterMarkTextBox();
            this.roundedButton2 = new RMS.UserControls.RoundedButton();
            this.roundedButton1 = new RMS.UserControls.RoundedButton();
            this.textBoxPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(197, 171);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 17);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "用户名[&N]:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(197, 222);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(77, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "密   码[&P]:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetDB
            // 
            this.btnSetDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetDB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDB.Location = new System.Drawing.Point(241, 383);
            this.btnSetDB.Name = "btnSetDB";
            this.btnSetDB.Size = new System.Drawing.Size(124, 28);
            this.btnSetDB.TabIndex = 8;
            this.btnSetDB.Text = "数据源设置[&S]...";
            this.btnSetDB.Visible = false;
            this.btnSetDB.Click += new System.EventHandler(this.btnSetDB_Click);
            // 
            // buttonId
            // 
            this.buttonId.BackColor = System.Drawing.Color.White;
            this.buttonId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonId.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonId.DownBack = ((System.Drawing.Image)(resources.GetObject("buttonId.DownBack")));
            this.buttonId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.buttonId.Location = new System.Drawing.Point(437, 169);
            this.buttonId.Margin = new System.Windows.Forms.Padding(0);
            this.buttonId.MouseBack = ((System.Drawing.Image)(resources.GetObject("buttonId.MouseBack")));
            this.buttonId.Name = "buttonId";
            this.buttonId.NormlBack = ((System.Drawing.Image)(resources.GetObject("buttonId.NormlBack")));
            this.buttonId.Size = new System.Drawing.Size(22, 24);
            this.buttonId.TabIndex = 35;
            this.buttonId.UseVisualStyleBackColor = false;
            this.buttonId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonId_MouseDown);
            // 
            // panelHeadImage
            // 
            this.panelHeadImage.BackColor = System.Drawing.Color.Transparent;
            this.panelHeadImage.BackgroundImage = global::RMS.WinForms.Properties.Resources.girl;
            this.panelHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelHeadImage.DownBack = null;
            this.panelHeadImage.Location = new System.Drawing.Point(75, 164);
            this.panelHeadImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeadImage.MouseBack = null;
            this.panelHeadImage.Name = "panelHeadImage";
            this.panelHeadImage.NormlBack = null;
            this.panelHeadImage.Radius = 4;
            this.panelHeadImage.Size = new System.Drawing.Size(85, 85);
            this.panelHeadImage.TabIndex = 36;
            // 
            // menuStripId
            // 
            this.menuStripId.Arrow = System.Drawing.Color.Black;
            this.menuStripId.AutoSize = false;
            this.menuStripId.Back = System.Drawing.Color.White;
            this.menuStripId.BackColor = System.Drawing.Color.White;
            this.menuStripId.BackRadius = 4;
            this.menuStripId.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(209)))));
            this.menuStripId.Fore = System.Drawing.Color.Black;
            this.menuStripId.HoverFore = System.Drawing.Color.White;
            this.menuStripId.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStripId.ItemAnamorphosis = false;
            this.menuStripId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemBorderShow = false;
            this.menuStripId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemRadius = 4;
            this.menuStripId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripId.Name = "MenuId";
            this.menuStripId.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Size = new System.Drawing.Size(183, 4);
            this.menuStripId.TitleAnamorphosis = false;
            this.menuStripId.TitleColor = System.Drawing.Color.White;
            this.menuStripId.TitleRadius = 4;
            this.menuStripId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.menuStripId_Closing);
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPwd.BackgroundImage = global::RMS.WinForms.Properties.Resources.bg;
            this.textBoxPwd.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.Icon = ((System.Drawing.Image)(resources.GetObject("textBoxPwd.Icon")));
            this.textBoxPwd.IconIsButton = true;
            this.textBoxPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Location = new System.Drawing.Point(277, 221);
            this.textBoxPwd.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.textBoxPwd.MouseBack = null;
            this.textBoxPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.NormlBack = null;
            this.textBoxPwd.Padding = new System.Windows.Forms.Padding(5, 5, 120, 5);
            this.textBoxPwd.Size = new System.Drawing.Size(182, 28);
            // 
            // textBoxPwd.BaseText
            // 
            this.textBoxPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxPwd.SkinTxt.Name = "BaseText";
            this.textBoxPwd.SkinTxt.PasswordChar = '*';
            this.textBoxPwd.SkinTxt.Size = new System.Drawing.Size(57, 18);
            this.textBoxPwd.SkinTxt.TabIndex = 0;
            this.textBoxPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxPwd.SkinTxt.WaterText = "密码";
            this.textBoxPwd.TabIndex = 37;
            this.textBoxPwd.IconClick += new System.EventHandler(this.textBoxPwd_IconClick);
            // 
            // topLogo2
            // 
            this.topLogo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo2.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo2.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo2.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo2.Location = new System.Drawing.Point(0, 0);
            this.topLogo2.Name = "topLogo2";
            this.topLogo2.Size = new System.Drawing.Size(613, 55);
            this.topLogo2.TabIndex = 40;
            this.topLogo2.TabStop = false;
            this.topLogo2.Text = "topLogo2";
            // 
            // txtLoginName
            // 
            this.txtLoginName.ForeColor = System.Drawing.Color.LightGray;
            this.txtLoginName.IsShowWaterText = true;
            this.txtLoginName.Location = new System.Drawing.Point(277, 168);
            this.txtLoginName.MarkText = "用户名";
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.ParentControl = null;
            this.txtLoginName.Size = new System.Drawing.Size(160, 25);
            this.txtLoginName.StartSearch = false;
            this.txtLoginName.TabIndex = 39;
            this.txtLoginName.Text = "用户名";
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.roundedButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundedButton2.Location = new System.Drawing.Point(329, 326);
            this.roundedButton2.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton2.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(103, 35);
            this.roundedButton2.TabIndex = 38;
            this.roundedButton2.Text = "退 出";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.roundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundedButton1.Location = new System.Drawing.Point(166, 326);
            this.roundedButton1.MouseDownBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.roundedButton1.MouseOverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(103, 35);
            this.roundedButton1.TabIndex = 10;
            this.roundedButton1.Text = "登  录";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(613, 432);
            this.Controls.Add(this.topLogo2);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.panelHeadImage);
            this.Controls.Add(this.buttonId);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnSetDB);
            this.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.Controls.SetChildIndex(this.btnSetDB, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.roundedButton1, 0);
            this.Controls.SetChildIndex(this.buttonId, 0);
            this.Controls.SetChildIndex(this.panelHeadImage, 0);
            this.Controls.SetChildIndex(this.textBoxPwd, 0);
            this.Controls.SetChildIndex(this.roundedButton2, 0);
            this.Controls.SetChildIndex(this.txtLoginName, 0);
            this.Controls.SetChildIndex(this.topLogo2, 0);
            this.textBoxPwd.ResumeLayout(false);
            this.textBoxPwd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void loginForm_Load(object sender, System.EventArgs e)
        {
            //if (Program.currLocalSetting.LastLoginUser != null || Program.currLocalSetting.LastLoginUser != string.Empty)
            //{
            //    this.cmbUsersList.strUserName = Program.currLocalSetting.LastLoginUser;
            //}


            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {

                string testUserID = (10000 + i).ToString();
                string nickName = Program.NickNameArray[i];
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.AutoSize = false;
                item.Size = new System.Drawing.Size(182, 45);
                item.Text = nickName + "\n" + testUserID;
                item.Tag = new string[] { testUserID, nickName };  //Tag用于存储UserID 和 NickName
                item.Image = Image.FromFile("head/" + i.ToString() + ".png"); //根据ID获取头像
                item.Click += new EventHandler(toolStripMenuItemID_Click);
                menuStripId.Height += 45;
                menuStripId.Items.Add(item);
            }
        }

        //从帐号下拉列表中 选中某个登录帐号
        void toolStripMenuItemID_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] tag = (string[])item.Tag;
            txtLoginName.Text = tag[0];
            panelHeadImage.BackgroundImage = item.Image;
            currentNickName = tag[1];
        }



        #region 按钮点击事件

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            UsersBusinesscs users = new UsersBusinesscs();
            //DataTable dt = null;
            bool isLogin = users.Exists(this.txtLoginName.Text, this.textBoxPwd.Text);
            if (isLogin)
            {
                UserInfo.LoginName = txtLoginName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Hide();
                // 提示
                if (MessageBox.Show("对不起，用户名和密码不匹配，请重新输入！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Show();
                    txtLoginName.Focus();
                }
            }
        }

        private void btnSetDB_Click(object sender, System.EventArgs e)
        {
            //frmDBSetting setting = new frmDBSetting();

            //setting.ShowDialog();
        }

        #endregion

        public void Clear()
        {
            //txtPassword.Text = string.Empty;
            //UserProvider.GetInstance().CurrentUser = null;
        }

        /// <summary>
        /// 封装的用户列表 控件事件之text改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputUserNameInitial1_ChTextChanged(object sender, InputUserNameInitial.TextEventArgs e)
        {
            //ComboboxItem comItem = (ComboboxItem)e.Item;
            //if (comItem != null)
            //{
            //    txtLoginName.Text = comItem.Code;
            //}
        }

        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 13 || txtLoginName.Text.Trim() == "")
            //{
            //    return;
            //}

            //e.Handled = true;

            //// 获取指定员工号的相关信息
            ////int iCode=int.Parse(this.txtCode.Text);
            //if (!this.cmbUsersList.SetSelectItemByCode(this.txtLoginName.Text))
            //{
            //    // 提示没有找到该员工
            //    MessageBox.Show("对不起，没有找到员工号为[" + txtLoginName.Text + "]的员工信息！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtLoginName.Focus();
            //}
            //else
            //{
            //    txtPassword.Focus();
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString() != Microsoft.VisualBasic.Constants.vbCr)
            {
                return;
            }

            e.Handled = true;

            //btnLogin.PerformClick();
        }

        private void textBoxPwd_IconClick(object sender, EventArgs e)
        {
            PassKey pass = new PassKey(this.Left + this.textBoxPwd.Left - 25, this.Top + this.textBoxPwd.Bottom, this.textBoxPwd.SkinTxt);
            pass.Show(this);
        }

        private Image buttonIdImage;
        private void buttonId_MouseDown(object sender, MouseEventArgs e)
        {
            this.menuStripId.Show(this.txtLoginName, 0, this.txtLoginName.Height - 1);
            this.buttonIdImage = this.buttonId.NormlBack;
            this.buttonId.NormlBack = this.buttonId.DownBack;
            this.buttonId.Enabled = false;
        }

        private void menuStripId_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.buttonId.Enabled = true;
            this.buttonId.NormlBack = buttonIdImage;
            //this.buttonId.ControlState = ControlState.Normal;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            UsersBusinesscs userBusiness = new UsersBusinesscs();
            if (!userBusiness.UserExists(this.txtLoginName.Text))
            {
                MessageBox.Show("此用户名不存在", "用户登录");
                return;
            }
            if (!userBusiness.PasswordExists(this.textBoxPwd.SkinTxt.Text))
            {
                MessageBox.Show("此密码不正确", "用户登录");
                return;
            }
            if (!userBusiness.Exists(this.txtLoginName.Text, this.textBoxPwd.SkinTxt.Text))
            {
                MessageBox.Show("此用户名或密码错误", "用户登录");
                return;
            }
            UserInfo.LoginName = txtLoginName.Text;
            new MainForm().ShowDialog();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
