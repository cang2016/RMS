using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OD.Entities;
using OD.Util;
using OD.Controls;
using OD.Business.Dish;
using OD.Entities.Dish;
using OD.Business;

namespace UI
{
    public partial class frmOpenTable : Form
    {
        private TableEntity m_dishTable;
        public frmMain frmMain = null;
        //public frmOP frmOrderOp = null;
        //public TableOrders m_tableOrders = null;
        public bool m_isNewOrderDish = false;

        public frmOpenTable(TableEntity dishTable)
        {
            m_dishTable = dishTable;

            InitializeComponent();
        }

        private void BindCombox()
        {
            DataTable waiterdt = new WaiterManage().GetSalesDataTable();
            this.cmbWaiter.DataSource = waiterdt;
            this.cmbWaiter.ValueMember = "Id";
            this.cmbWaiter.DisplayMember = "Name";

            DataTable salesdt = new SalesManage().GetSalesDataTable();

            this.cmbSales.DataSource = salesdt;
            this.cmbSales.ValueMember = "Id";
            this.cmbSales.DisplayMember = "Name";
        }

        private void BindText()
        {
            this.txtTableNo.Text = new GenerateVariousNo().AutoCreateNumber("dish_tableorders", "TableNo");
            this.txtMealTime.Text = SysConfigInfo.s_mealTime.Name;
            this.txtOpenMan.Text = Program.userInfo.LoginName;
            this.txtOpenTime.Text = string.Format("{0:yy-MM-dd HH:mm}", new OD.Business.QueryDbDate().GetSystemDateTime());

            this.txtTableName.Text = m_dishTable.Name;
            this.txtDishTableNo.Text = m_dishTable.TableNo;
        }

        private void frmOpenTable_Load(object sender, EventArgs e)
        {
            BindText();
            BindCombox();
        }

        private void btnOpenTable_Click(object sender, EventArgs e)
        {
            
            SysConfigInfo.frmOrderDish.dishTable = m_dishTable;
        
            TableOrdersEntity tableOrders = new TableOrdersEntity();

            tableOrders.GuestCount = Convert.ToInt32(this.txtCount.Text);
            tableOrders.SalesId = Convert.ToInt32(this.cmbSales.SelectedValue);
            tableOrders.WaiterId = Convert.ToInt32(this.cmbSales.SelectedValue);
            SysConfigInfo.frmOrderDish.tableOrders = tableOrders;

            SysConfigInfo.frmOrderDish = new frmOrderDishes(m_dishTable, tableOrders);
            SysConfigInfo.frmOrderDish.Init();
            //SysConfigInfo.frmOrderDish.SetCCOrderDishInfo();
            SysConfigInfo.frmOrderDish.ShowDialog();

            this.m_isNewOrderDish = true;
            this.Close();

            if (SysConfigInfo.frmOrderDish.frmOP == null)
            {
                SysConfigInfo.frmOrderDish.frmOP = new frmOP(tableOrders);

                SysConfigInfo.frmOrderDish.frmOP.ShowDialog();
                
            }



            this.Dispose();
        }
    }
}
