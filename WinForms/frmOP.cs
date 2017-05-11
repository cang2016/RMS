using System;
using System.Data;
using System.Windows.Forms;
using OD.Entities.Dish;

namespace UI
{
    public partial class frmOP : Form
    {
        private TableOrdersEntity m_tableOrders = null;
        public frmMain frmMain = null;
        private TableEntity dishTable = null;


        public frmOP(TableOrdersEntity tableOrders)
        {
            m_tableOrders = tableOrders;
            dishTable = new OD.DataAccess.DBSqlServer.SqlServerDbMapper<TableEntity>().GetSingleObj(new TableEntity { Id = m_tableOrders.Table_Id });
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BindData()
        {
            DataTable dt = new OD.Business.Dish.OrdersManage().GetOPDataSource(m_tableOrders);

            this.radGV.MasterTemplate.AutoGenerateColumns = true;

            radGV.DataSource = dt.DefaultView;
            radGV.Columns["Menu_Id"].IsVisible = false;
            radGV.Columns["IsReturn"].IsVisible = false;
            radGV.Columns["TableOrders_ID"].IsVisible = false;

            radGV.Columns["CategoryName"].HeaderText = "类 别";
            radGV.Columns["CategoryName"].Width = 100;
            radGV.Columns["MenuName"].HeaderText = "名 称";
            radGV.Columns["MenuName"].Width = 200;
            radGV.Columns["Amount"].HeaderText = "数 量";
            radGV.Columns["Amount"].Width = 100;
            radGV.Columns["price"].HeaderText = "单 价";
            radGV.Columns["price"].Width = 80;
            radGV.Columns["totalMoney"].HeaderText = "金 额";
            radGV.Columns["totalMoney"].Width = 120;
            radGV.Columns["UnitName"].HeaderText = "单 位";
            radGV.Columns["UnitName"].Width = 100;
            radGV.Columns["Discount"].HeaderText = "折 扣";
            radGV.Columns["Discount"].Width = 80;
            radGV.Columns["CanDiscount"].HeaderText = "能否折扣";
            radGV.Columns["CanDiscount"].Width = 80;
            radGV.Columns["IsPresent"].HeaderText = "是否赠送";
            radGV.Columns["IsPresent"].Width = 80;
        }

        private void frmOP_Load(object sender, EventArgs e)
        {
            BindData();

            SetStatusStrip();
        }

        /// <summary>
        /// 设置状态栏信息
        /// </summary>
        private void SetStatusStrip()
        {
            SysConfigInfo.SetStatusStripInfo(this.stsStrip);
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            this.stsStrip.Items[1].Text = string.Format("当前时间:{0:yyyy-MM-dd HH:mm:ss}", new OD.Business.QueryDbDate().GetSystemDateTime());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SysConfigInfo.frmOrderDish.dishTable = this.dishTable;
            SysConfigInfo.frmOrderDish.tableOrders = m_tableOrders;
            SysConfigInfo.frmOrderDish.Init();
            SysConfigInfo.frmOrderDish.SetCCOrderDishInfo();
            SysConfigInfo.frmOrderDish.Hide();
            SysConfigInfo.frmOrderDish.Visible = false;

            //SysConfigInfo.frmOrderDish.frmOP = this;
            //SysConfigInfo.frmOrderDish.Close();
            SysConfigInfo.frmOrderDish.ShowDialog();



            this.BindData();
            this.SetStatusStrip();
            //}
            //SysConfigInfo.frmOrderDish.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }


    }
}
