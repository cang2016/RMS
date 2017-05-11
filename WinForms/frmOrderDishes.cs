using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using RMS.Entities;
using RMS.UserControls;
using  RMS.Business;
using RMS.DataAccess;
using RMS.Logging;
using UI;

namespace RMS.WinForms
{
    public partial class frmOrderDishes : Form
    {
        private readonly DishCard[] dishCards = new DishCard[64];

        private readonly Button[] catBtns = new Button[16];
        private bool isBindingData = false;

        private int currentCatPage = 1;
        private int maxCatPageCount = 0;
        private int selectedCatId = 0;

        private int currentCat2Page = 1;
        private int maxCat2PageCount = 0;
        private int selectedmenuCategoryId;

        private int currentDishPage = 1;
        private int maxDishPageCount = 0;

        private int currentDishMOPage = 1;
        private int maxDishMOPageCount = 0;

        private System.Data.DataTable menuTopCategoryDT = null;
        private IList<MenuSubCategory> subCategories = null;
        private System.Data.DataTable orderDishDT = null;
        private System.Data.DataTable dishPriceDT = null;
        private ArrayList dishList = new ArrayList();
        private int maxOdishPageCount = 1;
        private bool isInitCatBtn = false;
        public TableOrders tableOrders = null;
        public string orderMemo = "";
        private bool isInitDishCard = false;
        //private TableEntity orderDishTableInfo = new TableEntity();
        public bool isAutoRefresh = false;
        //public frmOP frmOP = null;
        public frmMain frmMain = null;
        private string currDishName = string.Empty;
        //private BillEntity bill = null;
        //public TableEntity dishTable = null;
        private bool visiual = false;
        private int currRowIndex = 0;
        private int clickCount = 0;

        private frmPinyinAndCode frmPinyinAndCode = null;

        //public frmOP frmOrderOp = null;

        //private DataRow selectedOrderdish = null;
        //private OrdersEntity m_selectOrderDish = null;

        private IList<MenuRootCategory> topMenus;


        public frmOrderDishes()
        {
            //this.tableOrders = tableOrders;
            //this.dishTable = dishTable;

            //SysConfigInfo.dishTable = dishTable;

            InitializeComponent();

        }

        private void axchameleonButton9_ClickEvent(object sender, EventArgs e)
        {
            MessageBox.Show("dfa");
        }

        /// <summary>
        /// 设置状态栏信息
        /// </summary>
        private void SetStatusStrip()
        {
            SetStatusStripInfo(this.stsStrip);
        }

        private void SetStatusStripInfo(StatusStrip statusStrip)
        {
            //throw new NotImplementedException();
        }

        private void frmOrderDishes_Load(object sender, EventArgs e)
        {
            Init();
            this.dgvOrderDish.ClearSelection();
            this.dgvOrderDish.TabStop = false;
            if (dgvOrderDish.Rows.Count > 0)
            {
                dgvOrderDish.Rows[0].Selected = false;
            }
        }

        public void Init()
        {
            this.timer2.Enabled = false;
            this.dgvOrderDish.Height = this.ClientSize.Height - 40;

            //if (this.tableOrders.Id == 0)
            //{
            //    CreateNewTableOrders();
            //}
            ////this.bill = GetBill();


            SetStatusStrip();
            InitMenuTopCategoryCat();
            this.InitRootMenuCategoriesBtns();

            this.InitDishCard();
            this.BindRootCat();
            //this.BindDishCard();
            //this.dishList.Clear();
            //BindData();

            this.timer2.Enabled = true;
        }

        //private BillEntity GetBill()
        //{
        //    bill = new BillEntity();
        //    //bill = ODSqlServer.FillObjBySql<Bill>(bill, "select * from Bill where TableOrdersId = " + this.tableOrders.Id.ToString());

        //    //if (bill == null)
        //    //{
        //    //    bill = CreateBill();
        //    //}

        //    return bill;
        //}

        //private void CreateNewTableOrders()
        //{
        //    tableOrders.Table_Id = this.dishTable.Id;
        //    tableOrders.OpenDateTime = new QueryDbDate().GetSystemDateTime();
        //    tableOrders.State = 1;
        //    tableOrders.SalesPoint_Id = SysConfigInfo.s_salesPoint.Id;
        //    tableOrders.IsPrint = 0;
        //    tableOrders.IsPrivilege = 0;
        //    tableOrders.MinConsumption = this.dishTable.Minconsumption;
        //    tableOrders.PrivilegeMoney = 0;
        //    tableOrders.RoundType = SysConfigInfo.s_roundType;
        //    tableOrders.RoundType = 0;
        //    tableOrders.ServiceType = 0;

        //    new TableOrdersManage().CreateTableOrders(tableOrders);

        //    this.tableOrders = tableOrders;
        //    this.tableOrders.TableNo = tableOrders.TableNo;
        //}

        //private BillEntity CreateBill()
        //{
        //    if (SysConfigInfo.s_mealTime == null)
        //    {
        //        MessageBox.Show("找不到班次信息,创建帐单失败");
        //        return null;
        //    }
        //    System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
        //    //comm.Connection = (System.Data.SqlClient.SqlConnection)ODSqlServer.CreateConnection();
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    comm.CommandText = "createOrderBill";

        //    comm.Parameters.Add("@DISHTYPEID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@DISHTYPEID"].Value = SysConfigInfo.s_dishType.Id;

        //    comm.Parameters.Add("@TABLEORDERSID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@TABLEORDERSID"].Value = this.tableOrders.Id;

        //    comm.Parameters.Add("@ORDER_MAN", System.Data.SqlDbType.VarChar, 50);
        //    comm.Parameters["@ORDER_MAN"].Value = Program.userInfo.Name;

        //    comm.Parameters.Add("@ORDER_MAN_ID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@ORDER_MAN_ID"].Value = Program.userInfo.Id;

        //    comm.Parameters.Add("@WORK_SHIFT_NAME", System.Data.SqlDbType.VarChar, 300);
        //    comm.Parameters["@WORK_SHIFT_NAME"].Value = SysConfigInfo.s_mealTime.Name;

        //    comm.Parameters.Add("@WORK_SHIFT_ID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@WORK_SHIFT_ID"].Value = SysConfigInfo.s_mealTime.Id;

        //    comm.Parameters.Add("@SALE_POINT_ID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@SALE_POINT_ID"].Value = SysConfigInfo.s_salesPoint.Id;

        //    comm.Parameters.Add("@ID", System.Data.SqlDbType.Int);
        //    comm.Parameters["@ID"].Direction = System.Data.ParameterDirection.Output;

        //    if (comm.Connection.State == ConnectionState.Closed)
        //    {
        //        comm.Connection.Open();
        //    }

        //    comm.ExecuteNonQuery();
        //    int returnId = Convert.ToInt32(comm.Parameters["@ID"].Value);
        //    comm.Dispose();

        //    BillEntity bill = new BillEntity();

        //    return bill;
        //}

        //private Bill CreateBill()
        //{
        //    if (ClientInfo.s_mealTime == null)
        //    {
        //        MessageBox.Show("找不到班次信息,创建帐单失败");
        //        return null;
        //    }

        //    Bill bill1 = new Bill();
        //    bill1.TableOrdersId = this.tableOrders.Id;
        //    bill1.OrderMan = Entrance.userInfo.UserName;
        //    bill1.OrderId = Entrance.userInfo.UserID;
        //    bill1.SalePointId = ClientInfo.s_salesPoint.Id;


        //    ODSqlServer.InsertOrUpdateOrDelete(bill1);
        //    bill = ODSqlServer.FillObject<Bill>(bill1, 1);
        //    return bill;
        //}

        private void BindData()
        {
            //lock (this)
            //{
            //    int i = 0;
            //    int j = 0;
            //    if (!this.isBindingData)
            //    {
            //        isBindingData = true;
            //        this.orderDishDT = new OrdersManage().GetOrdersByTableOrderId(this.tableOrders.Id);

            //        for (i = 0; i < this.orderDishDT.DefaultView.Count; i++)
            //        {
            //            OrdersEntity orderDish = this.getOrderDishByID(Convert.ToInt32(this.orderDishDT.DefaultView[i]["Id"]));
            //            if (orderDish == null)
            //            {
            //                orderDish = new OrdersEntity();
            //                orderDish.Orders = Convert.ToInt32(this.orderDishDT.DefaultView[i]["Orders"]);
            //                if (orderDish.Orders > this.dishList.Count)
            //                {
            //                    orderDish.Orders = this.dishList.Count;

            //                    new SqlServerExecute().ExecuteNonQuery("exec TrimOrderDishSort " + this.tableOrders.Id.ToString());
            //                }
            //                this.dishList.Insert(orderDish.Orders, orderDish);
            //            }
            //            orderDish.Id = Convert.ToInt32(this.orderDishDT.DefaultView[i]["Id"]);
            //            orderDish.Menu_Id = Convert.ToInt32(this.orderDishDT.DefaultView[i]["Menu_Id"]);
            //            orderDish.Amount = Convert.ToDecimal(this.orderDishDT.DefaultView[i]["Amount"]);
            //            orderDish.MenuName = this.orderDishDT.DefaultView[i]["menuName"].ToString();
            //            orderDish.IsSend = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISSEND"]);
            //            //orderDish.IsSetMeal = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISSETMEAL"]);
            //            orderDish.IsTwoeat = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISTWOEAT"]);
            //            orderDish.Price = Convert.ToDecimal(this.orderDishDT.DefaultView[i]["PRICE"]);
            //            orderDish.Orders = Convert.ToInt32(this.orderDishDT.DefaultView[i]["Orders"]);
            //            orderDish.Status = Convert.ToInt32(this.orderDishDT.DefaultView[i]["Status"]);
            //            orderDish.TableOrders_Id = Convert.ToInt32(this.orderDishDT.DefaultView[i]["TableOrders_Id"]);
            //            orderDish.IsSelfPrice = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISSELFPRICE"]);
            //            orderDish.SelfPrice = Convert.ToInt32(this.orderDishDT.DefaultView[i]["SELFPRICE"]);
            //            orderDish.OrderMan = this.orderDishDT.DefaultView[i]["ORDERMAN"].ToString();
            //            orderDish.Discount = Convert.ToInt32(this.orderDishDT.DefaultView[i]["DISCOUNT"]);
            //            orderDish.IsPresent = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISPRESENT"] == DBNull.Value ? 0 : this.orderDishDT.DefaultView[i]["ISPRESENT"]);
            //            orderDish.IsReturn = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISRETURN"] == DBNull.Value ? 0 : this.orderDishDT.DefaultView[i]["ISRETURN"]);
            //            orderDish.CanDiscount = Convert.ToInt32(this.orderDishDT.DefaultView[i]["CANDISCOUNT"]);
            //            //orderDish.IsMember = Convert.ToInt32(this.orderDishDT.DefaultView[i]["ISMEMBER"]);
            //            //orderDish.CanMember = Convert.ToInt32(this.orderDishDT.DefaultView[i]["CANMEMBER"]);
            //        }

            //        this.orderDishDT.Clear();
            //        this.isBindingData = false;
            //        this.LoadOrderData();
            //    }
            //}
        }

        //private void LoadOrderData()
        //{
        //    DataTable dt = new OrdersManage().GetDgvDataSource(this.tableOrders);
        //    this.dgvOrderDish.Rows.Clear();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        DataGridViewRow dataGridRow = new DataGridViewRow();
        //        dataGridRow.Tag = dr;
        //        dataGridRow.CreateCells(dgvOrderDish, Convert.ToString(dr["ID"]), Convert.ToString(dr["menuName"]), Convert.ToString(dr["Amount"]), Convert.ToString(dr["Price"]), Convert.ToString(dr["TotalMoney"]), Convert.ToString(dr["UnitName"]), Convert.ToString(dr["Status"]));
        //        this.dgvOrderDish.Rows.Add(dataGridRow);
        //    }

        //    this.dgvOrderDish.Columns[0].Visible = false;
        //    this.dgvOrderDish.ClearSelection();
        //    this.dgvOrderDish.TabStop = false;
        //    if (dgvOrderDish.Rows.Count > 0)
        //    {
        //        dgvOrderDish.Rows[0].Selected = false;
        //    }
        //}

        //private OrdersEntity getOrderDishByID(int id)
        //{
        //    for (int i = 0; i < this.dishList.Count; i++)
        //    {
        //        OrdersEntity orderDish = (OrdersEntity)this.dishList[i];
        //        if (orderDish.Id == id)
        //        {
        //            return orderDish;
        //        }
        //    }

        //    return null;
        //}

        private void BindRootCat()
        {
            if (this.currentCatPage < 1) this.currentCatPage = 1;
            if (this.currentCatPage > this.maxCatPageCount) this.currentCatPage = this.maxCatPageCount;
            for (int i = 0; i < 8; i++)
            {
                this.catBtns[i].Text = "";
                this.catBtns[i].Tag = null;

                if (((this.currentCatPage - 1) * 8) + i + 1 <= this.topMenus.Count)
                {
                    this.catBtns[i].Text = topMenus[i].Name;
                    this.catBtns[i].Tag = topMenus[i].Id;
                }
            }

            this.selectedCatId = Convert.ToInt32(this.catBtns[0].Tag);
            this.ChangeCatColor();
            this.BindSubCategories();
        }

        // TODO : xucj cat
        private void ChangeCatColor()
        {
            for (int i = 0; i < 8; i++)
            {
                if (this.selectedCatId == Convert.ToInt32(this.catBtns[i].Tag))
                {
                    this.catBtns[i].BackColor = Color.Coral;
                }
                else
                {
                    this.catBtns[i].BackColor = this.btnColor1.BackColor;
                }
            }
        }

        private void BindSubCategories()
        {
            int i = 0;
            if (this.selectedCatId != 0)
            {
                if (this.subCategories != null) this.subCategories.Clear();

                this.subCategories = new MenuSubCategoryBusiness().GetSubCategoriesByParentId(this.selectedCatId);
                if (subCategories.Count > 0)
                {
                    if (Convert.ToInt32(this.subCategories.Count % 8) == 0)
                    {
                        this.maxCat2PageCount = Convert.ToInt32(this.subCategories.Count / 8);
                    }
                    else
                    {
                        this.maxCat2PageCount = Convert.ToInt32(this.subCategories.Count / 8) + 1;
                    }
                }
                if (this.currentCat2Page < 1)
                {
                    this.currentCat2Page = 1;
                }
                if (this.currentCat2Page > this.maxCat2PageCount) this.currentCat2Page = this.maxCat2PageCount;

                for (i = 8; i < 16; i++)
                {
                    this.catBtns[i].Text = "";
                    this.catBtns[i].Tag = null;

                    if (this.subCategories.Count > 0)
                    {
                        if (((this.currentCat2Page - 1) * 8) + (i - 8) + 1 <= this.subCategories.Count)
                        {
                            this.catBtns[i].Text = this.subCategories[((this.currentCat2Page - 1) * 8) + (i - 8)].Name;
                            this.catBtns[i].Tag = this.subCategories[((this.currentCat2Page - 1)*8) + (i - 8)].Id;
                        }
                    }
                }

                this.selectedmenuCategoryId = Convert.ToInt32(this.catBtns[8].Tag);
                this.ClickMenuCategory();
            }
            else
            {
                this.currentCat2Page = 0;
                this.maxCat2PageCount = 0;
                for (i = 8; i < 16; i++)
                {
                    this.catBtns[i].Text = "";
                    this.catBtns[i].Tag = null;
                }
            }
        }

        private void ClickMenuCategory()
        {
            if (this.selectedmenuCategoryId != 0)
            {
                DishMenuBusiness menuManage = new DishMenuBusiness();
                DataTable dt = menuManage.GetDishMenus(this.selectedmenuCategoryId);

                this.BindDishCard(dt);
            }
        }

        private void BindDishCard(DataTable dataTable = null)
        {
            if (dataTable == null)
            {
                dataTable = new DishMenuBusiness().GetDishMenus();
            }

            if (this.dishPriceDT != null)
            {
                this.dishPriceDT.Clear();
            }
            this.dishPriceDT = dataTable;

            if (this.currentDishPage < 1)
            {
                this.currentDishPage = 1;
            }
            if (this.dishPriceDT == null) return;
            if (this.dishPriceDT.DefaultView.Count > 0)
            {
                this.maxDishPageCount = Convert.ToInt32(this.dishPriceDT.DefaultView.Count / 64) + 1;
            }
            else
            {
                this.maxDishPageCount = 1;
            }

            if (this.currentDishPage > this.maxDishPageCount)
            {
                this.currentDishPage = this.maxDishPageCount;
            }
            if (this.dishPriceDT.DefaultView.Count > 0)
            {
                for (int i = 0; i < 64; i++)
                {
                    this.dishCards[i].init();

                    if (((this.currentDishPage - 1) * 64) + i + 1 <= this.dishPriceDT.DefaultView.Count)
                    {
                        this.dishCards[i].DishId = Convert.ToInt32(this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Id"]);
                        this.dishCards[i].MOID = Convert.ToInt32(this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["UnitId"]);
                        this.dishCards[i].Code = "[" + this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Code"].ToString() + "]";
                        this.dishCards[i].DishName = this.dishCards[i].Code + "\r\n" + this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Name"].ToString();
                        this.dishCards[i].MoName = this.dishPriceDT.DefaultView[(this.currentDishPage - 1) * 64 + i]["UnitName"].ToString();
                        this.dishCards[i].Price = this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Price"].ToString() + "/" + this.dishCards[i].MoName;
                        this.dishCards[i].isgq = Convert.ToInt32(this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Isgq"]);    // 是否沽清
                        //this.dishCards[i].issetmeal = Convert.ToInt32(this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["ISSETMEAL"]);

                        this.dishCards[i].Class = Convert.ToString(this.dishPriceDT.DefaultView[((this.currentDishPage - 1) * 64) + i]["Category_Id"]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 64; i++)
                {
                    this.dishCards[i].init();
                }
            }
        }

        public void InitRootMenuCategoriesBtns()
        {
            if (this.isInitCatBtn) return;
            int i = 0;
            int j = 0;
         
       
           for (int k = 0; k < catBtns.Length; k++)
            {
                this.catBtns[k] = new Button();
            }

            for (i = 0; i < 2; i++)
            {
               int currentTop =55 + (i * 40);
             
                for (j = 0; j < 8; j++)
                {
                    this.catBtns[i * 8 + j].Text = "";

                    this.catBtns[i * 8 + j].Location = new System.Drawing.Point(690 + (66 * j), currentTop);
                    this.catBtns[i * 8 + j].Size = new System.Drawing.Size(68, 40);
                    if (i == 0)
                    {
                        this.catBtns[i * 8 + j].Click += new EventHandler(CatBtns_Click);
                        this.catBtns[i*8 + j].BackColor = Color.BlueViolet;
                    }
                    else
                    {
                        this.catBtns[i * 8 + j].Click += new EventHandler(Cat2Btns_Click);
                        this.catBtns[i * 8 + j].BackColor = Color.DarkOliveGreen;
                    }

                    this.Controls.Add(this.catBtns[i * 8 + j]);
                }
            }

            this.isInitCatBtn = true;
        }

        private void InitMenuTopCategoryCat()
        {
            //大类初始化
             topMenus  = new RMS.Business.MenuRootCategoryBusiness().GetAllrootCategories();
            if (topMenus.Count > 0)
            {
                if (Convert.ToInt32(topMenus.Count % 8) == 0)
                {
                    this.maxCatPageCount = Convert.ToInt32(topMenus.Count / 8);
                }
                else
                {
                    this.maxCatPageCount = Convert.ToInt32(topMenus.Count / 8) + 1;
                }
            }
        }

        /// <summary>
        /// 初始化DishCard
        /// </summary>
        public void InitDishCard()
        {
            if (this.isInitDishCard)
            {
                return;
            }
            int i = 0;
            int j = 0;
            int currentTop = 80;
            //
            // dishCards
            //
            for (i = 0; i < 8; i++)
            {
                currentTop = 135 + (i * 60);
                for (j = 0; j < 8; j++)
                {
                    this.dishCards[i * 8 + j] = new DishCard();

                    this.dishCards[i * 8 + j].Code = string.Empty;
                    this.dishCards[i * 8 + j].MoName = string.Empty;

                    this.dishCards[i * 8 + j].BackColor = System.Drawing.SystemColors.AppWorkspace;
                    this.dishCards[i * 8 + j].DishId = 0;
                    this.dishCards[i * 8 + j].DishName = currentTop.ToString();
                    this.dishCards[i * 8 + j].Location = new System.Drawing.Point(690 + (75 * j), currentTop);
                    this.dishCards[i * 8 + j].MOID = 0;
                    this.dishCards[i * 8 + j].Price = Convert.ToString((583 + (75 * j)));
                    this.dishCards[i * 8 + j].Size = new System.Drawing.Size(75, 60);
                    this.dishCards[i * 8 + j].Spec = "";
                    this.dishCards[i * 8 + j].Visible = true;
                    this.dishCards[i * 8 + j].lblDishName.MouseDown += new MouseEventHandler(this.DishCards_MouseDown);
                    this.dishCards[i * 8 + j].lblDishName.MouseUp += new MouseEventHandler(this.DishCards_MouseUp);

                    this.dishCards[i * 8 + j].lblDishName.MouseHover += new EventHandler(DishCards_MouseHover);
                    this.dishCards[i * 8 + j].lblDishName.MouseLeave += new EventHandler(DishCards_MouseLeave);


                    //this.dishCards[i * 8 + j].lblDishName.Click += new EventHandler(this.DishCards_Click);

                    this.dishCards[i * 8 + j].lblPrice.MouseDown += new MouseEventHandler(this.DishCards_MouseDown);
                    this.dishCards[i * 8 + j].lblPrice.MouseUp += new MouseEventHandler(this.DishCards_MouseUp);

                    this.dishCards[i * 8 + j].lblPrice.MouseHover += new EventHandler(DishCards_MouseHover);
                    this.dishCards[i * 8 + j].lblPrice.MouseLeave += new EventHandler(DishCards_MouseLeave);


                    //this.dishCards[i * 8 + j].lblPrice.Click += new EventHandler(this.DishCards_Click);
                    this.Controls.Add(this.dishCards[i * 8 + j]);
                }
            }
            this.isInitDishCard = true;
        }

        private void DishCards_MouseHover(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            DishCard dc = (DishCard)lbl.Parent.Parent;

            dc.HoverBackColor = Color.FromArgb(200, 100, 100, 100);


            dc.DishNameBGColor = Color.BurlyWood;
            dc.DishPriceBGColor = Color.BurlyWood;
        }

        private void DishCards_MouseLeave(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            DishCard dc = (DishCard)lbl.Parent.Parent;

            dc.DishNameBGColor = Color.FromArgb(0, 92, 50, 50);
            dc.DishPriceBGColor = Color.FromArgb(93, 108, 179);
        }

        private void DishCards_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            DishCard dc = (DishCard)lbl.Parent.Parent;
            dc.DishNameBGColor = System.Drawing.Color.FromArgb(230, 20, 100);

            dc.DishPriceBGColor = System.Drawing.Color.FromArgb(230, 20, 100);

            if (dc.isgq == 1)
            {
                currDishName = dc.DishName;
                dc.DishName = "此菜已沽清...";
            }
        }

        private void DishCards_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            DishCard dc = (DishCard)lbl.Parent.Parent;

            dc.DishNameBGColor = Color.FromArgb(0, 92, 10, 50);
            dc.DishPriceBGColor = Color.FromArgb(93, 108, 179);

            if (dc.isgq == 1)
            {
                dc.DishName = currDishName;
                dc.ForeColor = Color.Black;
            }
        }

        private void updateOrdersPages()
        {
            if (this.dishList.Count > 0)
            {
                int i = this.dishList.Count - 1;
                if (i < 0)
                {
                    this.maxOdishPageCount = 1;
                }
                else
                {
                    this.maxOdishPageCount = Convert.ToInt32(i / 24) + 1;
                }
            }
        }

        private void CatBtns_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            this.selectedCatId = Convert.ToInt32(btn.Tag);
            this.BindSubCategories();
            this.ChangeCatColor();
        }

        private void Cat2Btns_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            this.selectedmenuCategoryId = Convert.ToInt32(btn.Tag);
            this.ClickMenuCategory();
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    this.BindData();

        //    Action<object, EventArgs> action = new Action<object, EventArgs>(Restore);
        //    action.Invoke(null, null);
        //}

        private void rbtnPyCode_Click(object sender, EventArgs e)
        {
            if (!visiual)
            {
                if (frmPinyinAndCode == null)
                {
                    frmPinyinAndCode = new frmPinyinAndCode(this);
                }
                frmPinyinAndCode.txtControl.Text = "";
                frmPinyinAndCode.targetTextBox = this.txtPinyin;
                frmPinyinAndCode.Left = 350;

                frmPinyinAndCode.Top = 508;

                frmPinyinAndCode.Focus();
                frmPinyinAndCode.Show();
                visiual = true;
            }
            else
            {
                visiual = false;
                frmPinyinAndCode.Hide();
            }
        }

        private void txtPinyin_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.txtPinyin.Text.Equals(""))
                {
                    return;
                }
                //dish.functions.CommValidate cv = new dish.functions.CommValidate();
                //string sql = "";
                string currentSearchType = "";

                DataTable dt = null;
                if (!Information.IsNumeric(this.txtPinyin.Text))
                {
                    if (!this.txtPinyin.Text.Equals(""))
                    {
                        //dt = new MenuManage().GetMenuInfoBySearchCondition(this.txtPinyin.Text);
                    }
                }
                else
                {
                    currentSearchType = "pinyin";
                    //dt = new MenuManage().GetMenuInfoBySearchCondition(this.txtPinyin.Text, true);
                }

                if (dt != null)
                {
                    this.BindDishCard(dt);
                }

                if (!this.dishCards[0].DishName.Equals("") && this.dishCards[1].DishName.Equals(""))
                {
                    this.DishCards_Click(this.dishCards[0].lblDishName, null);
                    if (this.frmPinyinAndCode == null)
                    {
                        this.frmPinyinAndCode = new frmPinyinAndCode();
                    }
                    this.frmPinyinAndCode.txtControl.Text = "";
                    this.txtPinyin.Text = string.Empty;
                    this.txtPinyin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox2.Show(ex.ToString());

                LoggerManager.GetILog().Error(ex.StackTrace);
            }
        }

        private void txtPinyin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (!this.dishCards[0].DishName.Equals(""))
                {
                    this.DishCards_Click(this.dishCards[0].lblDishName, null);
                    this.txtPinyin.Select();
                    this.txtPinyin.Focus();
                }
            }
        }

        private void rbtnHand_Click(object sender, EventArgs e)
        {
            this.pnlHandWritten.Visible = !this.pnlHandWritten.Visible;

            if (frmPinyinAndCode == null)
            {
                frmPinyinAndCode = new frmPinyinAndCode(this);
            }

            if (this.frmPinyinAndCode.Visible)
            {
                this.frmPinyinAndCode.Visible = false;
            }
            if (this.pnlHandWritten.Visible)
            {
                this.txtHandWrite.Focus();
            }
        }

        private void DishCards_Click(object sender, System.EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                int mo_count = 0;
                Label lbl = (Label)sender;
                DishCard dc = (DishCard)lbl.Parent.Parent;

                if (!dc.DishName.Equals(""))
                {
                    string pos = "";
                    string mydishname = dc.DishName;
                    if (mydishname.Split(']').Length > 1)
                    {
                        mydishname = dc.DishName.Split(']')[1].Trim();
                    }
                    int orderId;
                    //if (new OrdersManage().ExistsMenuInDgv(dc.DishId, this.tableOrders.Id, out orderId))
                    //{

                    //    OrdersEntity orderDish = new SqlServerDbMapper<OrdersEntity>().GetSingleObj(new OrdersEntity { Id = orderId });

                    //    new OrdersManage().ChangeAmount(0, "++", orderDish);
                    //    timer1.Enabled = true;
                    //    return;

                    //    //new OrdersManage().ChangeAmount(amount, psType, this.m_selectOrderDish);
                    //    //return;
                    //}
                    if (dc.dispType.Equals(""))
                    {
                        if (dc.isgq == 1)
                        {
                            return;
                        }

                        if (this.dgvOrderDish.SelectedRows.Count > 0)
                        {
                            //selectedOrderdish = (DataRow)dgvOrderDish.SelectedRows[0].Tag;

                            //OrdersEntity orderDish = new OrdersEntity();
                            //m_selectOrderDish = new OrdersManage().GetOrdersEntitiyById(Convert.ToInt32(selectedOrderdish["Id"]));
                            //if ((DataRow)dgvOrderDish.SelectedRows[0].Tag != null)
                            //{
                            //    if (dc.DishId == m_selectOrderDish.Menu_Id)
                            //    {
                            //        this.ChangeAmount(0, "++");
                            //        timer1.Enabled = true;
                            //        return;
                            //    }
                            //}
                        }

                        OrdersCls orderdish = new OrdersCls();
                        orderdish.MenuName = mydishname;
                        orderdish.Amount = 1;
                        orderdish.Menu_Id = dc.DishId;

                        orderdish.Price = Convert.ToSingle(dc.Price.Split('/')[0]);
                        orderdish.Status = 0;     // "即上";
                        orderdish.TableOrders_Id = this.tableOrders.Table_Id;
                        orderdish.UnitName = Convert.ToString(dc.Price.Split('/')[1]);

                        //this.AddNewDish(orderdish, 0);
                        //this.updateOrdersPages();

                        //mo_count = new PriceManage().GetDishPriceCountByMenuId(dc.DishId);

                        //SetCCOrderDishInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox2.Show(ex.ToString());
            }
        }

        //private void AddNewDish(OrdersEntity orderDish, int insertSort)
        //{
        //    if (insertSort != 0)
        //    {
        //        orderDish.Orders = insertSort + 1;
        //    }
        //    else
        //    {
        //        orderDish.Orders = 0;
        //    }
        //    orderDish.Id = this.AddNewDishInDB(orderDish);
        //    this.BindData();
        //}

        //private int AddNewDishInDB(OrdersEntity orderDish)
        //{
        //    int return_int = 0;

        //    try
        //    {
        //        OrdersManage ordersManage = new OrdersManage();
        //        ordersManage.UpdateDishOrdersSort(orderDish);

        //        int outId = 0;

        //        ordersManage.AddNewOrderDish(orderDish, Program.userInfo.Name, ref outId);

        //        return_int = orderDish.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox2.Show(ex.ToString());
        //    }

        //    return return_int;
        //}

        //private void ChangeAmount(decimal amount, string psType)
        //{
        //    m_selectOrderDish.OrderMan = Program.userInfo.Name;
        //    new OrdersManage().ChangeAmount(amount, psType, this.m_selectOrderDish);
        //}

        //private void btnTopCategory_ClickEvent(object sender, EventArgs e)
        //{
        //    this.currentCatPage++;
        //    if (currentCatPage > maxCatPageCount)
        //    {
        //        currentCatPage = 1;
        //    }

        //    BindRootCat();
        //}

        //public void SetCCOrderDishInfo()
        //{
        //    SetCCOrderDishInfos();
        //}

        //private void SetCCOrderDishInfos()
        //{
        //    OrdersManage.OrderDishInfo dishInfo = new OrdersManage().SetCCOrderDishInfo(this.tableOrders, this.dishTable);

        //    this.ccOrderDishInfo1.TableNo = dishInfo.TableNo;
        //    this.ccOrderDishInfo1.TableName = dishInfo.TableName;
        //    this.ccOrderDishInfo1.TotalMoney = dishInfo.TotalMoney;
        //    this.ccOrderDishInfo1.DishCount = dishInfo.DishCount;
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    SetCCOrderDishInfo();
        //}

        //private void btnCategory_Click(object sender, EventArgs e)
        //{
        //    this.currentCat2Page++;
        //    if (currentCat2Page > maxCat2PageCount)
        //    {
        //        currentCat2Page = 1;
        //    }

        //    BindSubCategories();
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ChangeOrderDishAmount(0, "++");
        }

        //private void ChangeOrderDishAmount(decimal amount, string operationType)
        //{
        //    if (this.dgvOrderDish.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("请选中要操作的行!", Application.ProductName, MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (clickCount < 1)
        //    {
        //        currRowIndex = dgvOrderDish.CurrentRow.Index;
        //    }
        //    else
        //    {
        //        if (currRowIndex != dgvOrderDish.SelectedRows[0].Index)
        //        {
        //            currRowIndex = dgvOrderDish.SelectedRows[0].Index;
        //        }
        //    }
        //    clickCount++;

        //    this.timer2.Enabled = false;
        //    selectedOrderdish = (DataRow)dgvOrderDish.SelectedRows[0].Tag;

        //    m_selectOrderDish = new OrdersManage().GetOrdersEntitiyById(Convert.ToInt32(selectedOrderdish["Id"]));
        //    ChangeAmount(amount, operationType);

        //    this.timer2.Enabled = true;
        //    this.timer1.Enabled = true;
        //}

        private void dgvOrderDish_MouseClick(object sender, MouseEventArgs e)
        {
            this.timer2.Enabled = false;
        }

        private void Restore(object sender, EventArgs e)
        {
            if (currRowIndex > 0)
            {
                if (currRowIndex < this.dgvOrderDish.Rows.Count)
                {
                    this.dgvOrderDish.Rows[currRowIndex].Selected = true;
                }
                else
                {
                    this.dgvOrderDish.Rows[--currRowIndex].Selected = true;
                }
            }
        }

        //private void btnDel_Click(object sender, EventArgs e)
        //{
        //    if (this.dgvOrderDish.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("请选中要操作的行!", Application.ProductName, MessageBoxButtons.OK);
        //        return;
        //    }
        //    else
        //    {
        //        if (DialogResult.OK == MessageBox.Show("你确定要删除选的中菜名吗?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
        //        {
        //            selectedOrderdish = (DataRow)dgvOrderDish.SelectedRows[0].Tag;
        //            m_selectOrderDish = new OrdersManage().GetOrdersEntitiyById(Convert.ToInt32(selectedOrderdish["Id"]));
        //            new OrdersManage().DeleteOrderDish(m_selectOrderDish);

        //            this.timer2.Enabled = true;
        //            this.timer1.Enabled = true;
        //        }
        //    }
        //}

        //private void btnSub_Click(object sender, EventArgs e)
        //{
        //    ChangeOrderDishAmount(0, "--");
        //}

        //private void btnCal_Click(object sender, EventArgs e)
        //{
        //    frmSimpleCalc frmSimpleCalc = new frmSimpleCalc();
        //    frmSimpleCalc.textBox1.Text = "";
        //    frmSimpleCalc.ShowDialog();
        //    if (!frmSimpleCalc.isNotChange)
        //    {
        //        this.ChangeOrderDishAmount(Convert.ToDecimal(frmSimpleCalc.textBox1.Text), "");
        //    }
        //}

        //private void btnStatus_Click(object sender, EventArgs e)
        //{
        //    DishUpMode();
        //}

        //private void DishUpMode()
        //{
        //    frmOrderDishMode frmOrderDishMode = new frmOrderDishMode();
        //    frmOrderDishMode.Left = btnStatus.Left;
        //    frmOrderDishMode.Top = btnStatus.Top;
        //    frmOrderDishMode.TopMost = true;
        //    frmOrderDishMode.ShowDialog();
        //    if (!frmOrderDishMode.orderDishMode.Equals(""))
        //    {
              
        //        if (frmOrderDishMode.orderDishMode.Substring(0, 2).Equals("全部"))
        //        {
        //            for (int i = 0; i < this.dgvOrderDish.Rows.Count; i++)
        //            {
        //                selectedOrderdish = (DataRow)dgvOrderDish.Rows[i].Tag;
        //                m_selectOrderDish = new OrdersManage().GetOrdersEntitiyById(Convert.ToInt32(selectedOrderdish["Id"]));
        //                m_selectOrderDish.Status = GetDishMode(frmOrderDishMode.orderDishMode.Substring(2,2));
        //                //this.updateOrderDishStatus(m_selectOrderDish.Status);
        //                new OrdersManage().ModifyOrderDishStatus(m_selectOrderDish);
        //            }
        //            timer2.Enabled = true;
        //        }
        //        else
        //        {
        //            selectedOrderdish = (DataRow)dgvOrderDish.SelectedRows[0].Tag;
        //            m_selectOrderDish = new OrdersManage().GetOrdersEntitiyById(Convert.ToInt32(selectedOrderdish["Id"]));

        //            if (this.selectedOrderdish != null)
        //            {
        //                //this.selectedOrderdish.status = frmOrderDishMode.orderDishMode;
        //                m_selectOrderDish.Status = GetDishMode(frmOrderDishMode.orderDishMode);
        //                new OrdersManage().ModifyOrderDishStatus(m_selectOrderDish);
        //                //this.refreshFlexRow(this.currentFlexSel);
        //            }
        //        }
        //    }

        //    timer2.Enabled = true;
        //}

        private int GetDishMode(string mode)
        {
            int status;
            switch (mode)
            {
                case "即起":
                    status = 0;
                    break;
                case "外卖":
                    status = 1;
                    break;
                case "叫起":
                    status = 2;
                    break;
                case "免做":
                    status = 3;
                    break;
                default:
                    status = 0;
                    break;
            }

            return status;
        }

        private void rbtnHand_Click(object sender, CCButtonGrid.MyClickEventArgs e)
        {
            this.pnlHandWritten.Visible = !this.pnlHandWritten.Visible;
            if (this.frmPinyinAndCode.Visible)
            {
                this.frmPinyinAndCode.Visible = false;
            }
            if (this.pnlHandWritten.Visible)
            {
                this.txtHandWrite.Focus();
            }
        }

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    OrdersManage ordersManage = new OrdersManage();
        //    ordersManage.SendOrderDish(0, 1, this.tableOrders, Program.userInfo.Name);

        //    timer2.Enabled = true;

        //    SysConfigInfo.frmOrderDish.Hide();

        //}
    }
}
