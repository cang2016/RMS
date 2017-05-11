using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using RMS.UserControls;

namespace RMS.WinForms
{
    /// <summary>
    /// frmMessageBox 的摘要说明。
    /// </summary>
    public class MessageBox : System.Windows.Forms.Form
    {
        //private iEIS.GM.BaseControl.topLogo topLogo1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label lblButton2;
        private System.Windows.Forms.Label lblButton1;
        private System.Windows.Forms.Label lblButton3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.PictureBox picWarning;
        private topLogo topLogo1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private MessageBox()
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBox));
            this.lblMessage = new System.Windows.Forms.Label();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.lblButton1 = new System.Windows.Forms.Label();
            this.lblButton2 = new System.Windows.Forms.Label();
            this.lblButton3 = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.topLogo1 = new topLogo();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(85, 84);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(382, 78);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "MessageBox Information...";
            // 
            // picInfo
            // 
            this.picInfo.BackColor = System.Drawing.Color.Transparent;
            this.picInfo.Image = ((System.Drawing.Image)(resources.GetObject("picInfo.Image")));
            this.picInfo.Location = new System.Drawing.Point(32, 84);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(32, 32);
            this.picInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInfo.TabIndex = 29;
            this.picInfo.TabStop = false;
            this.picInfo.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(383, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(383, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // line
            // 
            this.line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.line.BackColor = System.Drawing.Color.SteelBlue;
            this.line.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.line.ForeColor = System.Drawing.Color.White;
            this.line.Location = new System.Drawing.Point(29, 188);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(438, 2);
            this.line.TabIndex = 2;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.SystemColors.Control;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(383, 221);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(84, 28);
            this.btnYes.TabIndex = 7;
            this.btnYes.Text = "是";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(383, 221);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(84, 28);
            this.btnNo.TabIndex = 8;
            this.btnNo.Text = "否";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.SystemColors.Control;
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.Location = new System.Drawing.Point(383, 221);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(84, 28);
            this.btnRetry.TabIndex = 9;
            this.btnRetry.Text = "重试";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.SystemColors.Control;
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnIgnore.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.Location = new System.Drawing.Point(383, 221);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(84, 28);
            this.btnIgnore.TabIndex = 10;
            this.btnIgnore.Text = "忽略";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Visible = false;
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.SystemColors.Control;
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbort.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(383, 221);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(84, 28);
            this.btnAbort.TabIndex = 30;
            this.btnAbort.Text = "中止";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Visible = false;
            // 
            // lblButton1
            // 
            this.lblButton1.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblButton1.Location = new System.Drawing.Point(383, 221);
            this.lblButton1.Name = "lblButton1";
            this.lblButton1.Size = new System.Drawing.Size(84, 28);
            this.lblButton1.TabIndex = 33;
            this.lblButton1.Visible = false;
            // 
            // lblButton2
            // 
            this.lblButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblButton2.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblButton2.Location = new System.Drawing.Point(287, 221);
            this.lblButton2.Name = "lblButton2";
            this.lblButton2.Size = new System.Drawing.Size(84, 28);
            this.lblButton2.TabIndex = 4;
            this.lblButton2.Visible = false;
            // 
            // lblButton3
            // 
            this.lblButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblButton3.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblButton3.Location = new System.Drawing.Point(191, 221);
            this.lblButton3.Name = "lblButton3";
            this.lblButton3.Size = new System.Drawing.Size(84, 28);
            this.lblButton3.TabIndex = 3;
            this.lblButton3.Visible = false;
            // 
            // picError
            // 
            this.picError.BackColor = System.Drawing.Color.Transparent;
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(30, 84);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(32, 32);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picError.TabIndex = 29;
            this.picError.TabStop = false;
            this.picError.Visible = false;
            // 
            // picQuestion
            // 
            this.picQuestion.BackColor = System.Drawing.Color.Transparent;
            this.picQuestion.Image = ((System.Drawing.Image)(resources.GetObject("picQuestion.Image")));
            this.picQuestion.Location = new System.Drawing.Point(32, 83);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(32, 32);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picQuestion.TabIndex = 29;
            this.picQuestion.TabStop = false;
            this.picQuestion.Visible = false;
            // 
            // picWarning
            // 
            this.picWarning.BackColor = System.Drawing.Color.Transparent;
            this.picWarning.Image = ((System.Drawing.Image)(resources.GetObject("picWarning.Image")));
            this.picWarning.Location = new System.Drawing.Point(32, 84);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(32, 32);
            this.picWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWarning.TabIndex = 29;
            this.picWarning.TabStop = false;
            this.picWarning.Visible = false;
            // 
            // topLogo1
            // 
            this.topLogo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLogo1.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLogo1.gradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.topLogo1.gradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(179)))), ((int)(((byte)(228)))));
            this.topLogo1.Location = new System.Drawing.Point(0, 0);
            this.topLogo1.Name = "topLogo1";
            this.topLogo1.Size = new System.Drawing.Size(507, 55);
            this.topLogo1.TabIndex = 34;
            this.topLogo1.TabStop = false;
            this.topLogo1.Text = "topLogo1";
            // 
            // MessageBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 273);
            this.Controls.Add(this.topLogo1);
            this.Controls.Add(this.line);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.lblButton1);
            this.Controls.Add(this.lblButton2);
            this.Controls.Add(this.lblButton3);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.picQuestion);
            this.Controls.Add(this.picWarning);
            this.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        static MessageBoxIcon _icon = MessageBoxIcon.Information;
        static MessageBoxButtons _buttons = MessageBoxButtons.OK;
        static String _message = String.Empty;
        static MessageBoxDefaultButton _defaultButton = MessageBoxDefaultButton.Button1;
        static String _caption = String.Empty;
        static MessageBox msgBox = new MessageBox();
        static Exception _exception = new Exception();

        public static DialogResult Show(String message)
        {
            _message = message;
            _caption = String.Empty;
            _buttons = MessageBoxButtons.OK;
            _icon = MessageBoxIcon.Information;
            _defaultButton = MessageBoxDefaultButton.Button1;

            initForm();

            return msgBox.ShowDialog();
        }

        public static DialogResult Show(String message, String caption)
        {
            _message = message;
            _caption = caption;
            _buttons = MessageBoxButtons.OK;
            _icon = MessageBoxIcon.Information;
            _defaultButton = MessageBoxDefaultButton.Button1;

            initForm();

            return msgBox.ShowDialog();
        }

        public static DialogResult Show(String message, Exception ex)
        {
            _message = message;
            _caption = string.Empty;
            _buttons = MessageBoxButtons.OK;
            _icon = MessageBoxIcon.Hand;
            _defaultButton = MessageBoxDefaultButton.Button1;

            _exception = ex;

            initForm();

            return msgBox.ShowDialog();
        }



        public static DialogResult Show(String message, String caption, MessageBoxButtons buttons)
        {
            _message = message;
            _caption = caption;
            _buttons = buttons;
            _icon = MessageBoxIcon.Information;
            _defaultButton = MessageBoxDefaultButton.Button1;

            initForm();

            return msgBox.ShowDialog();
        }

        public static DialogResult Show(String message, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            _message = message;
            _caption = caption;
            _buttons = buttons;
            _icon = icon;
            _defaultButton = MessageBoxDefaultButton.Button1;

            initForm();

            return msgBox.ShowDialog();
        }

        public static DialogResult Show(String message, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton dButton)
        {
            _message = message;
            _caption = caption;
            _buttons = buttons;
            _icon = icon;
            _defaultButton = dButton;

            initForm();

            return msgBox.ShowDialog();
        }

        public static void initForm()
        {
            if (_caption.Length == 0)
            {
                _caption = Application.ProductName;
            }

            msgBox.Text = _caption;

            msgBox.lblMessage.Text = _message;

            // 先隐藏所有的图标和按钮...
            msgBox.picError.Visible = false;
            msgBox.picInfo.Visible = false;
            msgBox.picQuestion.Visible = false;
            msgBox.picWarning.Visible = false;

            msgBox.btnAbort.Visible = false;
            msgBox.btnCancel.Visible = false;
            msgBox.btnIgnore.Visible = false;
            msgBox.btnNo.Visible = false;
            msgBox.btnOK.Visible = false;
            msgBox.btnRetry.Visible = false;
            msgBox.btnYes.Visible = false;

            // 确定需要显示什么图标...
            switch (_icon)
            {
                case MessageBoxIcon.Error:
                    msgBox.picError.Visible = true;
                    break;
                case MessageBoxIcon.Information:
                    msgBox.picInfo.Visible = true;
                    break;
                case MessageBoxIcon.Question:
                    msgBox.picQuestion.Visible = true;
                    break;
                case MessageBoxIcon.Warning:
                    msgBox.picWarning.Visible = true;
                    break;
                default:
                    msgBox.picInfo.Visible = true;
                    break;
            }

            // 确定需要显示什么按钮...
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    msgBox.btnOK.Visible = true;
                    msgBox.btnOK.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.AcceptButton = msgBox.btnOK;
                    msgBox.CancelButton = msgBox.btnOK;
                    msgBox.btnOK.Select();

                    break;
                case MessageBoxButtons.OKCancel:
                    msgBox.btnOK.Visible = true;
                    msgBox.btnCancel.Visible = true;
                    msgBox.btnOK.Location = new Point(msgBox.lblButton2.Left, msgBox.lblButton2.Top);
                    msgBox.btnCancel.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.CancelButton = msgBox.btnCancel;

                    switch (_defaultButton)
                    {
                        case MessageBoxDefaultButton.Button2:
                            msgBox.AcceptButton = msgBox.btnCancel;
                            msgBox.btnCancel.Select();
                            break;
                        default:
                            msgBox.AcceptButton = msgBox.btnOK;
                            msgBox.btnOK.Select();
                            break;
                    }

                    break;
                case MessageBoxButtons.YesNo:
                    msgBox.btnYes.Visible = true;
                    msgBox.btnNo.Visible = true;
                    msgBox.btnYes.Location = new Point(msgBox.lblButton2.Left, msgBox.lblButton2.Top);
                    msgBox.btnNo.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.CancelButton = msgBox.btnNo;

                    switch (_defaultButton)
                    {
                        case MessageBoxDefaultButton.Button2:
                            msgBox.AcceptButton = msgBox.btnNo;
                            msgBox.btnNo.Select();
                            break;
                        default:
                            msgBox.AcceptButton = msgBox.btnYes;
                            msgBox.btnYes.Select();
                            break;
                    }

                    break;
                case MessageBoxButtons.YesNoCancel:
                    msgBox.btnYes.Visible = true;
                    msgBox.btnNo.Visible = true;
                    msgBox.btnCancel.Visible = true;
                    msgBox.btnYes.Location = new Point(msgBox.lblButton3.Left, msgBox.lblButton3.Top);
                    msgBox.btnNo.Location = new Point(msgBox.lblButton2.Left, msgBox.lblButton2.Top);
                    msgBox.btnCancel.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.CancelButton = msgBox.btnCancel;

                    switch (_defaultButton)
                    {
                        case MessageBoxDefaultButton.Button2:
                            msgBox.AcceptButton = msgBox.btnNo;
                            msgBox.btnNo.Select();
                            break;
                        case MessageBoxDefaultButton.Button3:
                            msgBox.AcceptButton = msgBox.btnCancel;
                            msgBox.btnCancel.Select();
                            break;
                        default:
                            msgBox.AcceptButton = msgBox.btnYes;
                            msgBox.btnYes.Select();
                            break;
                    }

                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    msgBox.btnAbort.Visible = true;
                    msgBox.btnRetry.Visible = true;
                    msgBox.btnIgnore.Visible = true;
                    msgBox.btnAbort.Location = new Point(msgBox.lblButton3.Left, msgBox.lblButton3.Top);
                    msgBox.btnRetry.Location = new Point(msgBox.lblButton2.Left, msgBox.lblButton2.Top);
                    msgBox.btnIgnore.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.CancelButton = msgBox.btnIgnore;

                    switch (_defaultButton)
                    {
                        case MessageBoxDefaultButton.Button2:
                            msgBox.AcceptButton = msgBox.btnRetry;
                            msgBox.btnRetry.Select();
                            break;
                        case MessageBoxDefaultButton.Button3:
                            msgBox.AcceptButton = msgBox.btnIgnore;
                            msgBox.btnIgnore.Select();
                            break;
                        default:
                            msgBox.AcceptButton = msgBox.btnAbort;
                            msgBox.btnAbort.Select();
                            break;
                    }

                    break;
                case MessageBoxButtons.RetryCancel:
                    msgBox.btnRetry.Visible = true;
                    msgBox.btnCancel.Visible = true;
                    msgBox.btnRetry.Location = new Point(msgBox.lblButton2.Left, msgBox.lblButton2.Top);
                    msgBox.btnCancel.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);

                    msgBox.CancelButton = msgBox.btnCancel;

                    switch (_defaultButton)
                    {
                        case MessageBoxDefaultButton.Button2:
                            msgBox.AcceptButton = msgBox.btnCancel;
                            msgBox.btnCancel.Select();
                            break;
                        default:
                            msgBox.AcceptButton = msgBox.btnRetry;
                            msgBox.btnRetry.Select();
                            break;
                    }

                    break;
                default:
                    msgBox.btnOK.Visible = true;
                    msgBox.btnOK.Location = new Point(msgBox.lblButton1.Left, msgBox.lblButton1.Top);
                    break;
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            MessageBox2.Show(msgBox.lblMessage.Text, msgBox.Text, MessageBoxButtons.OK);
            msgBox.Close();
            msgBox.Visible = false;
        }
    }
}
