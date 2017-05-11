using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;
using System.Runtime.InteropServices;
using System.Threading;

using System.Diagnostics;
using UI;


namespace GG
{
    public partial class LoginForm : CCSkinMain
    {        
        //private IRapidPassiveEngine rapidPassiveEngine;
        //private ICustomizeHandler customizeHandler;
        private string currentNickName = "随风而逝";


        public LoginForm()
        {
            //this.rapidPassiveEngine = engine;
            //this.customizeHandler = handler;
            InitializeComponent();
        }


        public CCWin.SkinControl.ChatListSubItem.UserStatus LoginStatus
        {
            get
            {
                return (ChatListSubItem.UserStatus)int.Parse(this.skinButton_State.Tag.ToString());
            }
        }

        public Image StateImage
        {
            get
            {
                return this.skinButton_State.Image;
            }
        }

        #region FrmLogin_Load       
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();            
            for (int i = 0; i < 5; i++)
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
        #endregion

        #region toolStripMenuItemID_Click
        
        //从帐号下拉列表中 选中某个登录帐号
        void toolStripMenuItemID_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] tag = (string[])item.Tag;
            //textBoxId.SkinTxt.Text = tag[0];
            //panelHeadImage.BackgroundImage = item.Image;
            this.currentNickName = tag[1];
        }     
        #endregion

        #region buttonLogin_Click        
        private void buttonLogin_Click(object sender, EventArgs e)
        {            
            string id = this.textBoxId.SkinTxt.Text;
            string pwd = this.textBoxPwd.SkinTxt.Text ;
            if (id.Length == 0) { return; }

            this.Cursor = Cursors.WaitCursor;
            this.buttonLogin.Enabled = false;
            try
            {
                //this.rapidPassiveEngine.SecurityLogEnabled = false;
                //string pwdMD5 = pwd;
                //if (!this.logonAfterRegister)
                //{
                //    pwdMD5 = SecurityHelper.MD5String(pwd);
                //}
                //LogonResponse response = this.rapidPassiveEngine.Initialize(id, pwdMD5, ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["ServerPort"]), this.customizeHandler);
                //if (response.LogonResult == LogonResult.Failed)
                //{
                //    MessageBox.Show(response.FailureCause);
                //    return;
                //}

                //if (response.LogonResult == LogonResult.HadLoggedOn)
                //{
                //    MessageBox.Show("该帐号已经在其它地方登录！");
                //    return;
                //}
            }
            catch (Exception ee)
            {
                this.toolShow.Show(ee.Message, this.buttonLogin, new Point(this.buttonLogin.Width/2,-this.buttonLogin.Height), 3000);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.buttonLogin.Enabled = true;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        } 
        #endregion

        //选择状态
        private void btnState_Click(object sender, EventArgs e)
        {
            this.menuStripState.Show(this.Left + pnlTx.Left + panelHeadImage.Left + skinButton_State.Left, this.Top + pnlTx.Top + panelHeadImage.Top + skinButton_State.Top + skinButton_State.Height + 5);
        }

        //状态选择项
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.skinButton_State.Image = item.Image;
            this.skinButton_State.Tag = item.Tag;
        }

        //账号下拉按钮
        private Image buttonIdImage;
        private void buttonId_MouseDown(object sender, MouseEventArgs e)
        {
            this.menuStripId.Show(this.textBoxId, 1, this.textBoxId.Height + 1);
            this.buttonIdImage = this.buttonId.NormlBack;
            this.buttonId.NormlBack = this.buttonId.DownBack;
            this.buttonId.Enabled = false;
        }

        //账号下拉菜单关闭时
        private void menuStripId_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.buttonId.Enabled = true;
            this.buttonId.NormlBack = buttonIdImage;
            this.buttonId.ControlState = ControlState.Normal;
        }

        //点击 软键盘
        private void textBoxPwd_IconClick(object sender, EventArgs e)
        {
            PassKey pass = new PassKey(this.Left + this.textBoxPwd.Left - 25, this.Top + this.textBoxPwd.Bottom, this.textBoxPwd.SkinTxt);
            pass.Show(this);
        }

        //点击 自动登录CheckBox
        private void checkBoxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxRememberPwd.Checked = this.checkBoxAutoLogin.Checked ? true : this.checkBoxRememberPwd.Checked;
        }

        //点击 记住密码CheckBox
        private void checkBoxRememberPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxRememberPwd.Checked && this.checkBoxAutoLogin.Checked)
            {
                this.checkBoxAutoLogin.Checked = false;
            }
        }       
        
        //关闭
        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool logonAfterRegister = false;
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //RegisterForm registerForm = new RegisterForm();
            //if (registerForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    this.textBoxId.SkinTxt.Text = registerForm.RegisteredUser.ID;
            //    this.textBoxPwd.SkinTxt.Text = registerForm.RegisteredUser.PasswordMD5;
            //    this.logonAfterRegister = true;
            //    this.buttonLogin.PerformClick();
            //}
        }
    }
}
