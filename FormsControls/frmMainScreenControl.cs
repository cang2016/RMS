using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMS.Business;
using RMS.UserControls;
using RMS.Utility;
using RMS.Entities;
using RMS.UICommon;
using System.Data;
using System.Data.SqlClient;
using RMS.DataAccess;

namespace RMS.FormsControls
{
    public class frmMainScreenControl
    {
        public DishTableStatus Status
        {
            get;
            set;
        }


        private DataTable m_dishTableDataTable = null;
        public DataTable DishTableDataTable
        {
            get
            {
                return m_dishTableDataTable;
            }
            set
            {
                m_dishTableDataTable = value;
            }
        }

        public static DataTable DishTableDataTableClone;

        private void BindDishTableDisplaylInfo(GroupBox grpDishTableInfo, Dictionary<string, Dictionary<string, int>> dishTableDic)
        {
            foreach(Control ctrl in grpDishTableInfo.Controls)
            {
                if(ctrl is CustomLabel)
                {
                    foreach(KeyValuePair<string, Dictionary<string, int>> item in dishTableDic)
                    {
                        if(item.Key == (ctrl as CustomLabel).Name)
                        {
                            (ctrl as CustomLabel).Text = Convert.ToString(item.Value.FirstOrDefault().Key + item.Value.FirstOrDefault().Value.ToString());
                        }
                    }
                }
            }
        }




        public System.Data.DataTable GetDishTableInfo(string sql)
        {
            SqlServerExecute SqlExe = new SqlServerExecute();
            
            return SqlExe.FillDataTable(CommandType.Text, sql);
        }

        public string GetExeSql(int CurrentAreaId, int salesPointId, string tableName = "")
        {
            if(tableName == "搜索台桌名称")
            {
                tableName = string.Empty;
            }


            string subSql = string.Empty;
            string subSql2 = string.Empty;
            bool isAllCheck = false;

            if((DishTableStatus.Empty & Status) == DishTableStatus.Empty)
            {
                subSql += "0,";
            }
            if((DishTableStatus.Opened & Status) == DishTableStatus.Opened)
            {
                subSql += "1,";
            }
            if((DishTableStatus.HasServed & Status) == DishTableStatus.HasServed)
            {
                subSql += "2,";
            }
            if((DishTableStatus.Checkout & Status) == DishTableStatus.Checkout)
            {
                subSql += "3,";
            }
            if((DishTableStatus.MultiUnit & Status) == DishTableStatus.MultiUnit)
            {
                subSql += "4,";
            }
            if((DishTableStatus.Reservation & Status) == DishTableStatus.Reservation)
            {
                subSql += "5,";
            }
            if((DishTableStatus.All & Status) == DishTableStatus.All)
            {
                isAllCheck = true;
            }

            if(isAllCheck)
            {
                subSql = string.Empty;
            }
            if(subSql.Length > 0)
            {
                subSql = " and a.Status in (" + subSql.Substring(0, subSql.Length - 1) + ")";
            }
            if(!string.IsNullOrEmpty(tableName))
            {
                subSql2 = " and (Name like '%" + @tableName + "%' or dbo.GetPinYin(Name) like '%" + @tableName + "%')";
            }

            //isRefreshing = true;
            string sql = string.Empty;
            if(CurrentAreaId == 0)
            {
                sql = "select  a.Id,a.Name,a.Name,a.Status,(select isnull(sum(GuestCount),0)  from Tableorders where tableorders.Table_Id = a.Id and tableorders.State <>0 ) as GuestCount from  tables a,salespointarea s "
                 + " where A.Area_Id = S.Area_Id and s.SalesPoint_Id =  " + @salesPointId + subSql + subSql2 + " order by a.Id";

            }
            else
            {
                sql = "select A.ID,a.Name,a.Name,a.Status,a.Style,(select isnull(sum(GuestCount),0)  from Tableorders where Tableorders.Table_Id = a.Id and Tableorders.State <>0 ) as GuestCount from Tables A where A.Area_Id = " + CurrentAreaId + subSql + subSql2 + " order by a.Id";
            }

            SqlParameter NameParam = new SqlParameter("@tableName", SqlDbType.VarChar, 20);
            NameParam.Value = tableName;


            SqlParameter salesPointParam = new SqlParameter(" @salesPointId", SqlDbType.VarChar, 20);
            salesPointParam.Value = salesPointId;

            SqlParameter currAreaIdParam = new SqlParameter("@currentAreaId", SqlDbType.VarChar, 20);
            currAreaIdParam.Value = CurrentAreaId;

            SqlParameter[] allparams = new SqlParameter[] { NameParam, salesPointParam, currAreaIdParam };

            return sql;
        }

        public void SetStatusStripInfo(System.Windows.Forms.StatusStrip stsStrip)
        {
            stsStrip.Items[0].Text = string.Format("当前用户:{0}", UserInfo.LoginName);
            stsStrip.Items[0].Width = 200;
            stsStrip.Items[1].Text = string.Format("当前时间:{0:yyyy-MM-dd HH:mm:ss}", GetDbDateTime.GetSystemDateTime());
            stsStrip.Items[1].Width = 200;
            stsStrip.Items[2].Text = string.Format("当前主机名与IP:{0}", NetHelper.GetHostName() + "(" + NetHelper.GetIPAddress() + ")");
            stsStrip.Items[2].Width = 200;
            //stsStrip.Items[3].Text = string.Format("餐段:{0}", CurrentSystemInfo.WorkShift.Name);
            stsStrip.Items[3].Width = 200;
            stsStrip.Items[4].Text = string.Format("餐牌:{0}", CurrentSystemInfo.RestaurantType.Name);
            stsStrip.Items[4].Width = 200;
            stsStrip.Items[5].Text = string.Format("销售点:{0}", CurrentSystemInfo.SalesPoint.Name);
            stsStrip.Items[5].Width = 200;
            stsStrip.Items[6].Text = string.Format("版权所有：{0}", "CC");
            stsStrip.Items[6].Width = 200;
        }

        public int CurrentAreaId
        {
            get;
            set;
        }
    }
}
