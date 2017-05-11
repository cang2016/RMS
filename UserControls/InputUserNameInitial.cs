using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace RMS.UserControls
{
    /// <summary>
    /// InputUserNameInitial �����������������ĸȡ����Ӧ����������--created by cc
    /// </summary>
    public class InputUserNameInitial : System.Windows.Forms.UserControl
    {
        #region �Զ����ɴ���
        //private System.Windows.Forms.ComboBox cbUserList;
        //private CCWin.SkinControl.SkinComboBox cbUserList;
        private ComboBox cbUserList;

        /// <summary>
        /// TextChanged�¼�
        /// </summary>
        public event TextEventHandler ChTextChanged;

        /// <summary> 
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        public InputUserNameInitial()
        {
            // �õ����� Windows.Forms ���������������ġ�
            InitializeComponent();

            // TODO: �� InitializeComponent ���ú�����κγ�ʼ��

        }

        /// <summary> 
        /// ������������ʹ�õ���Դ��
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

        #region �����������ɵĴ���
        /// <summary> 
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
        /// �޸Ĵ˷��������ݡ�
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

        #region �����ֶ�
        /// <summary>
        /// ��ȡ������������е��û�����
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
        /// �û��б��е�item
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
        ///// ˮӡ�ı�
        ///// </summary>
        //[Category("Style")]
        //[Browsable(true)]
        //public string WaterText
        //{
        //    get { return this.cbUserList.WaterText; }
        //    set { this.cbUserList.WaterText = value; }
        //}


        #endregion

        #region ˽���ֶ�
        DataTable usersDataTable = null;     //�����û��б�
        private bool isLoadAll = false;//ָʾ�����˵��ǲ���ȫ������������
        private bool isSamme = false; //��ֹ���ֺ�����ĸһ��������ѭ���Ͷ�һ��ѭ����ֻ�з�������ĸ�Ż���֣�
        #endregion

        #region ˽�з���

        /// <summary>
        /// ���û��б�
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
            //foreach (DataRow dr in usersDataTable.Rows)//ѭ����
            //{
            //    comItem = new ComboboxItem();
            //    Itemfactory(comItem, dr);   //��װitem

            //    cbUserList.Items.Add(comItem);
            //}

            //this.isLoadAll = true;    //���������˵��Ѿ�ȫ������
        }

        /// <summary>
        /// ������д��ĸ��ѯָ���û�
        /// </summary>
        /// <param name="strInitAlphabet"></param>

        private void QueyUserName(string strInitAlphabet)
        {
            if (string.IsNullOrEmpty(strInitAlphabet))
            {
                throw new Exception("��������Ϊ��!");
            }

            int times = 0;//������ �����ѯ�������û�
            ArrayList addUsers = new ArrayList();//����ҵ����û���Ϣ�ڻ�����������
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

            if (times > 1)//����ҵ�2������ ����б�����aAdd���û���Ϣ
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
            else if (times == 1)//ֻ�ҵ�һ���û���
            {
                this.cbUserList.Items.Clear();
                this.isLoadAll = false;
                comItem = new ComboboxItem();
                Itemfactory(comItem, usersDataTable.Rows[int.Parse(addUsers[0].ToString())]);
                this.isSamme = true;//����һ���¼�
                this.cbUserList.Items.Add(comItem);
                this.cbUserList.SelectedIndex = 0;
                this.cbUserList.DroppedDown = false;
                this.cbUserList.Focus();
            }
        }

        /// <summary>
        /// �û�������Ϣ�洢����
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

        #region ��������
        /// <summary>
        /// �����û�id����ѡ����item
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
        /// �����û��������ѡ����item
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

        #region �ؼ��¼�

        /// <summary>
        /// �ı������¼�
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

            TextEventArgs args = new TextEventArgs(this.cbUserList.SelectedItem);//װ��ί�в���
            CheckTextChanged(args);
        }

        /// <summary>
        /// �ж��Ƿ�Ϊ�շ���ִ�з�ֹ�쳣����
        /// </summary>
        /// <param name="e"></param>
        protected virtual void CheckTextChanged(TextEventArgs e)
        {
            //�ж��¼��Ƿ�Ϊnull��Ҳ�����Ƿ���˷��� 
            if (ChTextChanged != null)
            {
                ChTextChanged(this, e);
            }
        }

        /// <summary>
        /// �����¼�
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

        #region ����ί���Լ�ί�в�������ί��Ϊ��׼���¼�ί�У�
        public delegate void TextEventHandler(object sender, TextEventArgs e);//����ί�� 
        public class TextEventArgs : EventArgs //����ί�в��� 
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
