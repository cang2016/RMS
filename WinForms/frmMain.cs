using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using RMS.UserControls;
using WinForms;
using RMS.Business;
using RMS.Entities;
using RMS.UICommon;
using WeifenLuo.WinFormsUI.Docking;

namespace RMS.WinForms
{
    public partial class frmMain : DockContent
    {
        #region Fields

        // 定义台桌数组
        private int _mCurrDishTableId = 0;
        private int _mCurrDishTablePage = 0;
        private int _mMaxDishTablePage = 0;

        private frmMainInfo m_mainInfo = new frmMainInfo();
        frmMainScreenControl mainScreenControl = new frmMainScreenControl();
        //frmSelectArea selectArea = new frmSelectArea();

        public frmMainScreenControl MainScreenControl
        {
            get
            {
                return mainScreenControl;
            }
            set
            {
                mainScreenControl = value;
            }
        }



        private bool isRefreshing = false;

        private static int m_currentAreaId = 0;

        public string CurrentAreaName = string.Empty;
        internal frmSelectArea frmSelectArea = new frmSelectArea();
        public RMS.Entities.Tables dishTable = null;

        #endregion Fields

        #region Property

        public static int CurrentAreaId
        {
            get
            {
                return m_currentAreaId;
            }
            set
            {
                //if(value != m_currentAreaId)
                //{
                m_currentAreaId = value;
                //}
            }
        }

        #endregion Property

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion End Constructor

        #region Control Event

        //private void tmrUpdate_Tick(object sender, EventArgs e)
        //{
        //    RefreshDishTable();
        //}





        //private void txtSearchTable_TextChanged(object sender, EventArgs e)
        //{
        //    DishTableStatus status = GetCheckedStatus();

        //    frmMainBusiness mainBusiness = new frmMainBusiness();

        //    mainBusiness.Status = status;

        //    string sql = mainBusiness.GetExeSql(this.CurrentAreaId, SysConfigInfo.s_salesPoint.Id, this.txtSearchTable.Text);

        //    FillDishTableData(sql);
        //}

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmExit exit = new frmExit();

            switch(exit.SelectOperation())
            {
                case 1:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case 2:
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmMainTool mainTool = new frmMainTool();

            //mainTool.Show(this.dockPanel1);

            //mainTool.DockTo(this.dockPanel1, DockStyle.Right);


            //frmMainInfo mainInfo = new frmMainInfo();
            //mainInfo.Show(this.dockPanel1);

            //mainInfo.DockTo(this.dockPanel1, DockStyle.Bottom);

            //this.frmSelectArea.Left = 517;
            //this.frmSelectArea.Top = 107;
            //this.frmSelectArea.frmMain = this;

            //try
            //{


            frmSelectArea.frmMain = this;
            //m_mainInfo.frmMain = this;
            CurrentUIForms.mainForm = this;
            mainScreenControl.SetStatusStripInfo(this.stsStrip);     // 设置状态栏
            //InitBtnsDesk();
            FillDishTable();
            //BindDishTableDisplaylInfo();   // 状态统计信息

       
        }

        public void FillDishTable()
        {
            this.InitBtnsDesk();  // 初始化台桌
            this.FillDishTableData();  // 填充台桌信息
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            this.stsStrip.Items[1].Text = string.Format("当前时间:{0:yyyy-MM-dd HH:mm:ss}", GetDbDateTime.GetSystemDateTime());
        }

        /// <summary>
        /// 单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccButtonGrid1_BtnClickEvent(object sender, EventArgs e)
        {
            object obj = sender;
            
            RoundedButton btn = obj as RoundedButton;
            if(btn != null)
            {
                if(btn.Text.Equals("翻 页"))
                {
                    this._mCurrDishTablePage++;
                    if(_mCurrDishTablePage > _mMaxDishTablePage)
                    {
                        _mCurrDishTablePage = 0;
                    }
                }
                else
                {
                    DishTables_Click((int)btn.Tag);
                }
            }

            this.FillDishTableData();
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ccButtonGrid1_DoubleClick(object sender, EventArgs e)
        //{
        //object obj = sender;
        //EllipseButton btn = obj as EllipseButton;
        //if (btn.Tag != null)
        //{
        //    this.m_currDishTableId = (int)btn.Tag;
        //}
        ////MessageBox.Show(m_currDishTableId.ToString(), Application.ProductName, MessageBoxButtons.OK);
        //int status = new OD.Business.Dish.TableManage().GetDishTableEntity(m_currDishTableId).Status;

        //this.OpenTable(m_currDishTableId, status);
        //SysConfigInfo.frmOrderDish.frmMain = this;
        //}

        public void FillDishTableData()
        {
            // string sql = GetSqlStatement();

            //m_currDishTablePage = 0;
            this.FillDishTableData("");
        }

    #endregion Control Event

    #region Loacl Method

    private void DishTables_Click(int tableId)
    {
      this._mCurrDishTableId = tableId;
      //MessageBox.Show(m_currDishTableId.ToString(), Application.ProductName, MessageBoxButtons.OK);
      //int status = new OD.Business.Dish.TableManage().GetDishTableEntity(tableId).Status;

      new frmOrderDishes().Show();
      ////this.OpenTable(tableId, status);

      //DataRow dr = new OD.Business.Dish.TableManage().GetDishTableDataRow(tableId);
      //if (dr != null)
      //{
      //  BindDishTableInfo(dr);
      //}
      //else
      //{
      //  ClearDishTableInfo();
      //}

      //this.BindDgvOrders(tableId);
    }

    /// <summary>
    /// 初始化台桌
    /// </summary>
    private void InitBtnsDesk()
        {
            this.ccButtonGrid1.ColMargin = 4;
            this.ccButtonGrid1.RowMargin = 4;

            // 仅测试用  可以改变控件宽度与高度
            //this.ccButtonGrid1.SetBtnHeight(40);
            //this.ccButtonGrid1.SetBtnWeight(60);
            //this.ccButtonGrid1.SetBtnFontSize(8);
            this.ccButtonGrid1.RefreshBtn();
            //this.ccButtonGrid1.SetBtnText(0, "DDDDD");

            //this.ccButtonGrid1.SetBtnVisual(0, true);
            CurrentUIForms.custDishTables = new CCustomDishTable[ccButtonGrid1.Cols * ccButtonGrid1.Rows - 1];     


            for(int i = 0; i < CurrentUIForms.custDishTables.Length; i++)
            {
                CurrentUIForms.custDishTables[i] = new CCustomDishTable();
                CurrentUIForms.custDishTables[i].TableName = string.Empty;
                CurrentUIForms.custDishTables[i].Status = 0;
            }

            _mCurrDishTableId = 0;
        }

        public void FillDishTableData(string sql)
        {
            if(mainScreenControl.DishTableDataTable != null)
            {
                mainScreenControl.DishTableDataTable = null;
            }


            sql = mainScreenControl.GetExeSql(CurrentAreaId, CurrentSystemInfo.SalesPoint.Id, m_mainInfo.txtSearchTable.Text);

            mainScreenControl.DishTableDataTable = mainScreenControl.GetDishTableInfo(sql);
            frmMainScreenControl.DishTableDataTableClone = mainScreenControl.DishTableDataTable;
            if(mainScreenControl.DishTableDataTable.Rows.Count > 0)
            {
                this._mMaxDishTablePage = Convert.ToInt32(mainScreenControl.DishTableDataTable.Rows.Count / CurrentUIForms.custDishTables.Length) + 1;
            }
            if(this._mCurrDishTablePage < 1)
            {
                this._mCurrDishTablePage = 1;
            }
            if(_mMaxDishTablePage > 0)
            {
                if(this._mCurrDishTablePage > this._mMaxDishTablePage)
                {
                    this._mCurrDishTablePage = _mMaxDishTablePage;
                }
            }

            for(int i = 0; i < CurrentUIForms.custDishTables.Length; i++)
            {

                if((this._mCurrDishTablePage - 1) * CurrentUIForms.custDishTables.Length + i < mainScreenControl.DishTableDataTable.DefaultView.Count)
                {
                    CurrentUIForms.custDishTables[i].TableId = Convert.ToInt32(mainScreenControl.DishTableDataTable.DefaultView[(this._mCurrDishTablePage - 1) * CurrentUIForms.custDishTables.Length + i]["Id"]);
                    CurrentUIForms.custDishTables[i].GuestCount = Convert.ToInt32(mainScreenControl.DishTableDataTable.DefaultView[(this._mCurrDishTablePage - 1) * CurrentUIForms.custDishTables.Length + i]["GuestCount"]);
                    CurrentUIForms.custDishTables[i].Status = Convert.ToInt32(mainScreenControl.DishTableDataTable.DefaultView[(this._mCurrDishTablePage - 1) * CurrentUIForms.custDishTables.Length + i]["Status"]);
                    CurrentUIForms.custDishTables[i].TableName = Convert.ToString(mainScreenControl.DishTableDataTable.DefaultView[(this._mCurrDishTablePage - 1) * CurrentUIForms.custDishTables.Length + i]["Name"]);
                    //this.custDishTables[i].Style = Convert.ToString(mainScreenControl.DishTableDataTable.DefaultView[(this.m_currDishTablePage - 1) * this.custDishTables.Length + i]["Style"]);
                    CurrentUIForms.custDishTables[i].Visible = true;

                    this.ccButtonGrid1.SetBtnVisual(i, true);
                }
                else
                {
                    ccButtonGrid1.SetBtnVisual(i, false);
                }
                ccButtonGrid1.SetBtnId(i, CurrentUIForms.custDishTables[i].TableId);
                ccButtonGrid1.SetBtnText(i, CurrentUIForms.custDishTables[i].GetTableCaption());
                //Color color = this.custDishTables[i].GetBtnBackColor();
                Color color = Color.White;
                this.ccButtonGrid1.SetBtnColr(i, color);
                switch(CurrentUIForms.custDishTables[i].Status)
                {
                    case 1:
                        this.ccButtonGrid1.SetBtnImage(i, @"E:\51CTO下载-C# 餐饮管理系统 详细源代码\MrCy\Backup\MrCy\Image\a_1.gif");
                        break;
                    case 2:
                        this.ccButtonGrid1.SetBtnImage(i, @"E:\51CTO下载-C# 餐饮管理系统 详细源代码\MrCy\Backup\MrCy\Image\a_2.gif");
                        break;
                    case 3:
                        this.ccButtonGrid1.SetBtnImage(i, @"E:\51CTO下载-C# 餐饮管理系统 详细源代码\MrCy\Backup\MrCy\Image\a_3.jpg");
                        break;
                    case 4:
                        this.ccButtonGrid1.SetBtnImage(i, @"E:\51CTO下载-C# 餐饮管理系统 详细源代码\MrCy\Backup\MrCy\Image\a_4.jpg");
                        break;
                    default:
                        break;
                }

                this.ccButtonGrid1.SetBtnText(CurrentUIForms.custDishTables.Length, "翻 页");
                this.ccButtonGrid1.SetBtnColr(CurrentUIForms.custDishTables.Length, Color.PeachPuff);
                this.ccButtonGrid1.SetBtnImage(CurrentUIForms.custDishTables.Length, @"e:\RMS\RMS\WinForms\bin\Debug\Task1.ico");
                if(mainScreenControl.DishTableDataTable.Rows.Count < CurrentUIForms.custDishTables.GetUpperBound(0))
                {
                    this.ccButtonGrid1.SetBtnVisual(CurrentUIForms.custDishTables.Length, false);
                }
                else
                {
                    this.ccButtonGrid1.SetBtnVisual(CurrentUIForms.custDishTables.Length, true);
                }

                if(this._mCurrDishTableId == CurrentUIForms.custDishTables[i].TableId)
                {
                    this.ccButtonGrid1.SetBtnText(i, "√" + CurrentUIForms.custDishTables[i].TableName);
                }
            }

            //frmMainInfo mainInfo = new frmMainInfo();

            //mainInfo.BindDishTableInfo();
            //BindDishTableInfo();
            isRefreshing = false;
        }

        private string GetSqlStatement()
        {
            DishTableStatus status = m_mainInfo.GetCheckedStatus();

            frmMainScreenControl mainScreenControl = new frmMainScreenControl();

            frmMainScreenControl.Status = status;

            return mainScreenControl.GetExeSql(CurrentAreaId, (CurrentSystemInfo.CurrentSysInfo[typeof(SalesPoint).FullName].FirstOrDefault() as SalesPoint).Id, m_mainInfo.txtSearchTable.Text);
        }

        private void RefreshDishTable()
        {
            if(!isRefreshing)
            {
                //if(this..Text.Length < 1)
                //{
                _mCurrDishTablePage = 0;
                FillDishTable();
            }
        }

        internal void ChangeArea()
        {
            while(!this.isRefreshing)
            {
                this.FillDishTableData();
                //RefreshDishTable();
                break;
            }
        }

        // TODO :  xucj 2012-07-11 未完待续
        private void OpenTable(int tableId, int state)
        {
            //dishTable = new OD.Business.Dish.TableManage().GetDishTableEntity(tableId);

            //switch (state)
            //{
            //    case 6:
            //        if (dishTable != null)
            //        {
            //            if (MessageBox.Show("你确定【" + dishTable.Name + "】台已经清理完毕?", "清理", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                // TODO: xucj 2012-07-11 未完待续
            //                new SqlServerExecute().ExecuteNonQuery("update dish_tableOrders set state = 0 where State = 5 and Table_Id =" + dishTable.Id.ToString());
            //                new SqlServerExecute().ExecuteNonQuery("exec dbo.TableStateChange " + dishTable.Id.ToString());
            //            }
            //        }
            //        break;
            //    case 0:
            //        if (dishTable != null)
            //        {
            //            frmOpenTable openTable = new frmOpenTable(dishTable);
            //            openTable.frmMain = this;
            //            openTable.ShowDialog();
            //            openTable.Dispose();
            //            openTable = null;
            //        }
            //        break;

            //    case 1:
            //    case 2:
            //    case 3:
            //    case 4:

            //        if (dishTable != null)
            //        {

            //            SqlServerExecute execute = new SqlServerExecute();
            //            DataTable dt = execute.GetDataTable("Select Id From dish_tableorders Where table_Id=" + dishTable.Id.ToString() + " And (STATE=1 OR STATE=2 OR STATE=4 OR STATE=3 OR STATE=5)");
            //            //DataTable dt = execute.GetDataTable("Select Id From dish_tableorders Where table_Id=" + dishTable.Id.ToString() + " And (STATE=1 OR STATE=2 OR STATE=4 OR STATE=3 OR STATE=5)");
            //            if (dt.DefaultView.Count == 1)
            //            {
            //                //TableOrdersEntity tableOrders = new SqlServerDbMapper<TableOrdersEntity>().GetSingleObj(new TableOrdersEntity { Id = Convert.ToInt32(dt.DefaultView[0][0]) });
            //                TableOrdersEntity tableOrders = new TableOrdersEntity();

            //                if (dt.Rows.Count > 0)
            //                {
            //                    tableOrders = new SqlServerDbMapper<TableOrdersEntity>().GetSingleObj(new TableOrdersEntity { Id = Convert.ToInt32(dt.DefaultView[0][0]) });
            //                }
            //                frmOP frmOrderOP = new frmOP(tableOrders);
            //                //SysConfigInfo.frmOrderDish.frmMain = this;
            //                SysConfigInfo.frmOrderDish.tableOrders = tableOrders;
            //                //SysConfigInfo.frmOrderDish.frmOP = frmOrderOP;

            //                //SysConfigInfo.frmOrderDish.frmOP.frmMain = this;
            //                frmOrderOP.ShowDialog();
            //                //frmOrderOP.Dispose();
            //            }
            //            else
            //            {
            //                if (dt.DefaultView.Count > 1)     // 多单
            //                {
            //                    //FrmSelectOrder frmSelectOrder = new FrmSelectOrder(dishTable);
            //                    //frmSelectOrder.frmMain = this;
            //                    //frmSelectOrder.ShowDialog();
            //                    //frmSelectOrder.Dispose(); 
            //                }
            //                else
            //                {
            //                    new SqlServerExecute().ExecuteNonQuery("Exec dbo.TableStateChange " + dishTable.Id.ToString());
            //                    dishTable.Status = 0;
            //                    this.OpenTable(dishTable.Id, 0);
            //                }
            //            }
            //            dt.Dispose();
            //            dt = null;
            //        }

            //        break;
            //    default:
            //        break;
            //}
        }

        private void ccButtonGrid1_BtnClickEvent_1(object sender, RMS.UserControls.CCButtonGrid.MyClickEventArgs e)
        {

        }
        private void ccButtonGrid1_DoubleClick(object sender, RMS.UserControls.CCButtonGrid.MyClickEventArgs e)
        {
            MessageBox.Show("ddddd");
        }



        //private void BindDishTableInfo(DataRow dr)
        //{
        //    ClearDishTableInfo();

        //    lblDishTableNo.Text += Constants.vbTab + Convert.ToString(dr["TableNo"]);
        //    lblTableOrderNo.Text += Constants.vbTab + Convert.ToString(dr["TableNumber"]);
        //    lblTableName.Text += Constants.vbTab + Convert.ToString(dr["Name"]);
        //    lblCount.Text += Constants.vbTab + Convert.ToString(dr["GuestCount"]);
        //    lblType.Text += Constants.vbTab + Convert.ToString(dr["StyleName"]);
        //    lblCarNo.Text += Constants.vbTab + Convert.ToString(dr["CarNo"]);
        //    lblArea.Text += Constants.vbTab + Convert.ToString(dr["AreaName"]);
        //    //lblWaiter2.Text += Constants.vbTab + Convert.ToString(dr["Waiter"]);
        //    //lblServicer2.Text += Constants.vbTab + Convert.ToString(dr["Sales"]);
        //    lblOpenDate.Text += Constants.vbTab + Convert.ToString(dr["OpenDateTime"]);
        //}

        //private void ClearDishTableInfo()
        //{
        //    foreach (Control ctrl in grbDishTableInfo.Controls)
        //    {
        //        if (ctrl is Label)
        //        {
        //            if (Regex.Split((ctrl as Label).Text, Constants.vbTab, RegexOptions.IgnoreCase).Length > 1)
        //            {
        //                (ctrl as Label).Text = (ctrl as Label).Text.Substring(0, (ctrl as Label).Text.IndexOf(Constants.vbTab));
        //            }
        //        }
        //    }
        //}

        //private void BindDgvOrders(int tableId)
        //{
        //DataTable dt = new OD.Business.Dish.OrdersManage().GetOrdersByDishTableId(tableId);

        //if (this.dgvOrders.Rows.Count > 0)
        //{
        //    this.dgvOrders.Rows.Clear();
        //}
        //foreach (DataRow dr in dt.Rows)
        //{
        //    DataGridViewRow dataGridRow = new DataGridViewRow();
        //    dataGridRow.CreateCells(this.dgvOrders, Convert.ToString(dr["Menu_Id"]), Convert.ToString(dr["MenuName"]), Convert.ToString(dr["Amount"]), Convert.ToString(dr["UnitName"]), Convert.ToString(dr["TotalMoney"]));

        //    this.dgvOrders.Rows.Add(dataGridRow);
        //}
        //}

        //private void SetDataGridViewValue(DataGridViewRow dgvr, DataRow dr)
        //{
        //    int i = 0;
        //    DataGridViewTextBoxCell name = dgvr.Cells[i++] as DataGridViewTextBoxCell;
        //    name.Value = Convert.ToString(dr["MenuName"]);

        //    DataGridViewTextBoxCell amount = dgvr.Cells[i++] as DataGridViewTextBoxCell;
        //    amount.Value = Convert.ToString(dr["Amount"]);

        //    DataGridViewTextBoxCell price = dgvr.Cells[i++] as DataGridViewTextBoxCell;
        //    price.Value = Convert.ToString(dr["UnitName"]);

        //    DataGridViewTextBoxCell totalMoney = dgvr.Cells[i++] as DataGridViewTextBoxCell;
        //    totalMoney.Value = Convert.ToString(dr["TotalMoney"]);

        //    dgvr.Tag = dr;
        //}

        #endregion Loacl Method
    }
}
