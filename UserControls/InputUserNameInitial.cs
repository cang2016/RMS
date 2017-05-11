using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace RMS.UserControls
{
    /// <summary>
    /// InputUserNameInitial 根据输入的名字首字母取得相应的中文名字--created by cc
    /// </summary>
    public class InputUserNameInitial : System.Windows.Forms.UserControl
    {
        #region 自动生成代码
        //private System.Windows.Forms.ComboBox cbUserList;
        //private CCWin.SkinControl.SkinComboBox cbUserList;
        private ComboBox cbUserList;

        /// <summary>
        /// TextChanged事件
        /// </summary>
        public event TextEventHandler ChTextChanged;

        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public InputUserNameInitial()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化

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

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbUserList = new ComboBox();
            this.SuspendLayout();
            // 
            // cbUserList
            // 
            this.cbUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUserList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUserList.Location = new System.Drawing.Point(0, 0);
            this.cbUserList.Name = "cbUserList";
            this.cbUserList.Size = new System.Drawing.Size(120, 22);
            this.cbUserList.TabIndex = 0;
            //this.cbUserList.WaterText = "";
            this.cbUserList.TextChanged += new System.EventHandler(this.cbUserName_TextChanged);
            // 
            // InputUserNameInitial
            // 
            this.Controls.Add(this.cbUserList);
            this.Name = "InputUserNameInitial";
            this.Size = new System.Drawing.Size(120, 28);
            this.Load += new System.EventHandler(this.InputUserNameInitial_Load);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        #region 公共字段
        /// <summary>
        /// 获取和设置输入框中的用户名字
        /// </summary>
        public string strUserName
        {
            get
            {
                return this.cbUserList.Text;
            }
            set
            {
                if (strUserName != null)
                {
                    cbUserList.Text = value;
                }
                else
                {
                    this.cbUserList.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 用户列表中的item
        /// </summary>
        private ComboboxItem m_comItem;
        public ComboboxItem ComItem
        {
            get
            {
                return m_comItem;
            }

            set
            {
                value = m_comItem;
            }
        }

        private string waterText;

        ///// <summary>
        ///// 水印文本
        ///// </summary>
        //[Category("Style")]
        //[Browsable(true)]
        //public string WaterText
        //{
        //    get { return this.cbUserList.WaterText; }
        //    set { this.cbUserList.WaterText = value; }
        //}


        #endregion

        #region 私有字段
        DataTable usersDataTable = null;     //缓存用户列表
        private bool isLoadAll = false;//指示下拉菜单是不是全部载入了数据
        private bool isSamme = false; //防止名字和首字母一样进入死循环和多一次循环（只有非中文字母才会出现）
        #endregion

        #region 私有方法

        /// <summary>
        /// 绑定用户列表
        /// </summary>
        private void BindComBox()
        {
            //if (usersDataTable == null)
            //{
            //    //Users user = new Users();
            //    //dtUser = DataAccess.ODSqlServer.ODSqlServer.ExecuteDataTable(CommandType.Text, "SELECT distinct * FROM USERS", null);
            //    usersDataTable = new UsersManage().GetUsersDataTable();

            //    if (usersDataTable == null)
            //    {
            //        return;
            //    }
            //}

            //this.cbUserList.Items.Clear();
            //ComboboxItem comItem = new ComboboxItem(); ;
            //foreach (DataRow dr in usersDataTable.Rows)//循环绑定
            //{
            //    comItem = new ComboboxItem();
            //    Itemfactory(comItem, dr);   //组装item

            //    cbUserList.Items.Add(comItem);
            //}

            //this.isLoadAll = true;    //设置下拉菜单已经全部载入
        }

        /// <summary>
        /// 根据首写字母查询指定用户
        /// </summary>
        /// <param name="strInitAlphabet"></param>

        private void QueyUserName(string strInitAlphabet)
        {
            if (string.IsNullOrEmpty(strInitAlphabet))
            {
                throw new Exception("参数不能为空!");
            }

            int times = 0;//计数器 计算查询到几个用户
            ArrayList addUsers = new ArrayList();//存放找到的用户信息在缓存表里的索引
            ComboboxItem comItem = null;
            for (int i = 0; i < usersDataTable.Rows.Count; i++)
            {
                //if (usersDataTable.Rows[i]["Code"].ToString().StartsWith(strInitAlphabet.ToUpper())
                //    || GetPinYinHelper.GetInitialPinYin(Convert.ToString(usersDataTable.Rows[i]["Code"]).ToUpper()).StartsWith(strInitAlphabet.ToUpper()))
                //{
                //    times++;
                //    comItem = new ComboboxItem();
                //    Itemfactory(comItem, usersDataTable.Rows[i]);
                //    if (!addUsers.Contains(i.ToString()))
                //    {
                //        addUsers.Add(i.ToString());
                //    }
                //}
            }

            if (times > 1)//如果找到2个以上 清除列表并加载aAdd的用户信息
            {
                this.cbUserList.Items.Clear();
                this.isLoadAll = false;
                foreach (object user in addUsers)
                {
                    comItem = new ComboboxItem();
                    Itemfactory(comItem, usersDataTable.Rows[int.Parse(user.ToString())]);
                    this.cbUserList.Items.Add(comItem);
                }

                this.cbUserList.DroppedDown = true;
                this.cbUserList.SelectionStart = strInitAlphabet.Length;

            }
            else if (times == 1)//只找到一个用户名
            {
                this.cbUserList.Items.Clear();
                this.isLoadAll = false;
                comItem = new ComboboxItem();
                Itemfactory(comItem, usersDataTable.Rows[int.Parse(addUsers[0].ToString())]);
                this.isSamme = true;//减少一次事件
                this.cbUserList.Items.Add(comItem);
                this.cbUserList.SelectedIndex = 0;
                this.cbUserList.DroppedDown = false;
                this.cbUserList.Focus();
            }
        }

        /// <summary>
        /// 用户下拉信息存储工厂
        /// </summary>
        /// <param name="item"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private void Itemfactory(ComboboxItem comItem, DataRow dr)
        {
            comItem.SearchWord = dr["Code"].ToString();
            comItem.Text = dr["LoginName"].ToString();
            comItem.Code = dr["Code"].ToString();
            comItem.Value = dr["Id"].ToString();
            comItem.Tag = dr["Dep_Id"].ToString();
        }


        #endregion

        #region 公共方法
        /// <summary>
        /// 根据用户id设置选定项item
        /// </summary>
        public void SetSelectItemById(string strUid)
        {
            if (strUid == null || strUid == "")
            {
                //this.cbUserList.Text  = "";
                cbUserList.SelectedIndex = -1;
                return;
            }
            DataRow[] dr = this.usersDataTable.Select("Id = '" + strUid + "'");
            if (dr != null && dr.Length > 0)
            {
                this.cbUserList.Text = dr[0]["Code"].ToString();
                ComboboxItem comItem = new ComboboxItem();
                Itemfactory(comItem, dr[0]);
                this.cbUserList.SelectedItem = comItem;
            }
            else
            {
                cbUserList.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 根据用户编号设置选定项item
        /// </summary>
        /// <param name="strUid"></param>
        public bool SetSelectItemByCode(string strCode)
        {
            return false;
            //if (usersDataTable == null)
            //{
            //    usersDataTable = new UsersManage().GetUsersDataTable();
            //}
            //DataRow[] dr = usersDataTable.Select("Code = '" + strCode.Trim() + "'");
            //if (dr != null && dr.Length > 0)
            //{
            //    this.cbUserList.Text = dr[0]["LoginName"].ToString();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        #endregion

        #region 控件事件

        /// <summary>
        /// 改变输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbUserName_TextChanged(object sender, System.EventArgs e)
        {
            if (this.cbUserList.Text != String.Empty)
            {
                if (!this.isSamme)
                {
                    QueyUserName(cbUserList.Text);
                }
                this.isSamme = false;
            }
            else
            {
                if (!this.isLoadAll)
                {
                    BindComBox();
                    this.cbUserList.DroppedDown = true;
                }

            }
            if (this.cbUserList.SelectedItem != null)
            {
                this.m_comItem = (ComboboxItem)this.cbUserList.SelectedItem;
            }

            TextEventArgs args = new TextEventArgs(this.cbUserList.SelectedItem);//装配委托参数
            CheckTextChanged(args);
        }

        /// <summary>
        /// 判断是否为空否则不执行防止异常产生
        /// </summary>
        /// <param name="e"></param>
        protected virtual void CheckTextChanged(TextEventArgs e)
        {
            //判断事件是否为null，也就是是否绑定了方法 
            if (ChTextChanged != null)
            {
                ChTextChanged(this, e);
            }
        }

        /// <summary>
        /// 载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputUserNameInitial_Load(object sender, System.EventArgs e)
        {
            if (!this.isLoadAll)
            {
                BindComBox();
            }
        }

        #endregion

        #region 定义委托以及委托参数，此委托为标准的事件委托！
        public delegate void TextEventHandler(object sender, TextEventArgs e);//定义委托 
        public class TextEventArgs : EventArgs //定义委托参数 
        {
            public TextEventArgs(object arsItem)
            {
                _Item = arsItem;
            }
            private object _Item;
            public object Item
            {
                get { return _Item; }
                set { Item = value; }
            }
        }

        #endregion
    }
}
