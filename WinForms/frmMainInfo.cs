using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMS.Business;
using RMS.UICommon;
using WeifenLuo.WinFormsUI.Docking;

namespace RMS.WinForms
{
    public partial class frmMainInfo : DockContent
    {

        Dictionary<string, Dictionary<string, int>> dishTableDic = new Dictionary<string, Dictionary<string, int>>();
        //public frmSelectArea frmSelectArea = new frmSelectArea();
        frmMainScreenControl mainScreenControl = new frmMainScreenControl();
        //internal frmMain frmMain;

        public frmMainInfo()
        {
            InitializeComponent();
        }

        public void BindDishTableInfo()
        {
            Dictionary<string, int> tempDic1 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic1["空 台   小计:"] = 0;
            Dictionary<string, int> tempDic2 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic2["已开台   小计:"] = 0;
            Dictionary<string, int> tempDic3 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic3["多 单   小计:"] = 0;
            Dictionary<string, int> tempDic4 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic4["结帐中   小计:"] = 0;
            Dictionary<string, int> tempDic5 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic5["已上菜   小计:"] = 0;
            Dictionary<string, int> tempDic6 = new System.Collections.Generic.Dictionary<string, int>();
            tempDic6["清理中   小计:"] = 0;
            //dishTableDic[clblEmpty.Name] = tempDic1;
            //dishTableDic[clblOpened.Name] = tempDic2;
            //dishTableDic[clblMultiUnit.Name] = tempDic3;
            //dishTableDic[clblCheckOut.Name] = tempDic4;
            //dishTableDic[clblHasServed.Name] = tempDic5;
            //dishTableDic[clblCleanup.Name] = tempDic6;
            for(int i = 0; i < frmMainScreenControl.DishTableDataTableClone.Rows.Count; i++)
            {

                switch(Convert.ToString(frmMainScreenControl.DishTableDataTableClone.Rows[i]["Status"]))
                {
                    case "0":
                        //this.dishTableDic[clblEmpty.Name]["空 台   小计:"]++;
                        break;
                    case "1":
                        //this.dishTableDic[clblOpened.Name]["已开台   小计:"]++;
                        break;
                    case "2":
                        //this.dishTableDic[clblHasServed.Name]["已上菜   小计:"]++;

                        break;
                    case "3":
                        //this.dishTableDic[clblCheckOut.Name]["结帐中   小计:"]++;
                        break;
                    case "4":
                        //this.dishTableDic[clblMultiUnit.Name]["多 单   小计:"]++;
                        break;
                    case "6":
                        //this.dishTableDic[clblCleanup.Name]["清理中   小计:"]++;
                        break;
                }
            }
        }

        public DishTableStatus GetCheckedStatus()
        {
            DishTableStatus status = DishTableStatus.None;

            if(this.chkEmpty.Checked)
            {
                status |= DishTableStatus.Empty;
            }
            if(this.chkOpened.Checked)
            {
                status |= DishTableStatus.Opened;
            }
            if(this.chkHasServed.Checked)
            {
                status |= DishTableStatus.HasServed;
            }
            //if (this.chkCheckOut.Checked)
            //{
            //    status |= DishTableStatus.Checkout;
            //}

            //if(this.chkMultiUnit.Checked)
            //{
            //    status |= DishTableStatus.MultiUnit;
            //}
            if (this.chkReservation.Checked)
            {
                status |= DishTableStatus.Reservation;
            }
            return status;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if(CurrentUIForms.mainForm == null)
            {
                CurrentUIForms.mainForm = new frmMain();
            }
            btnArea_Click(sender, e);
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            CurrentUIForms.mainForm.frmSelectArea.StartPosition = FormStartPosition.CenterScreen;
            CurrentUIForms.mainForm.frmSelectArea.Show();
            CurrentUIForms.mainForm.frmSelectArea.Focus();
        }


        private void chkEmpty_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void chkOpened_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void chkHasServed_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void chkCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void chkMultiUnit_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void chkReservation_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDishTable();
        }

        private void RefreshDishTable()
        {
            frmMainScreenControl.Status = GetCheckedStatus();

            string sql = mainScreenControl.GetExeSql(frmMain.CurrentAreaId, CurrentSystemInfo.SalesPoint.Id, txtSearchTable.Text);
            //frmMain = new WinForms.frmMain();
            CurrentUIForms.mainForm.FillDishTableData();
            //mainScreenControl.DishTableDataTable = mainScreenControl.GetDishTableInfo(sql);
            //frmMainScreenControl.DishTableDataTableClone = mainScreenControl.DishTableDataTable;

            //frmMain main = new frmMain();
            //main.MainScreenControl = mainScreenControl;
            //main.FillDishTable();
        }
    }
}
