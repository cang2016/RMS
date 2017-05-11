using System.Data;
using System.Drawing;

namespace RMS.UserControls
{
    /// <summary>
    /// 自定义台桌类，为台桌提供数据
    /// </summary>
    public class CCustomDishTable
    {
        #region 字段
        /// <summary>
        /// 客人数量
        /// </summary>
        private int m_guestCount = 0;

        /// <summary>
        /// 状态
        /// </summary>
        private int m_status = 0;

        /// <summary>
        /// 台桌Id
        /// </summary>
        private int m_tableId = 0;


        /// <summary>
        /// 台桌名称
        /// </summary>
        private string m_tableName = string.Empty;

        /// <summary>
        /// 是否可见
        /// </summary>
        private bool m_visible = false;

        /// <summary>
        /// 几人桌
        /// </summary>
        private string m_style = string.Empty;

    
        #endregion

        #region 属性

        /// <summary>
        /// 人数
        /// </summary>
        public int GuestCount
        {
            get { return m_guestCount; }
            set { m_guestCount = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        /// <summary>
        /// 台桌ID
        /// </summary>
        public int TableId
        {
            get { return m_tableId; }
            set { m_tableId = value; }
        }

        /// <summary>
        /// 台桌名称
        /// </summary>
        public string TableName
        {
            get { return m_tableName; }
            set { m_tableName = value; }
        }

        /// <summary>
        /// 台桌可见性
        /// </summary>
        public bool Visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        /// <summary>
        /// 几人桌
        /// </summary>
        public string Style
        {
            get { return m_style; }
            set { m_style = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 取得显示文本
        /// </summary>
        /// <returns></returns>
        public string GetTableCaption()
        {
            string str = string.Empty;
            DataTable dataTable = new DataTable();
            str = this.TableName + "--";

            switch (this.Status)
            {
                case -1:
                    str = string.Empty;
                    break;
                case 0:
                    str += this.Style; 
                    break;
                case 1:
                case 2:
                    str += this.GuestCount.ToString() + "人";
                    break;
                case 6:
                    str += "清理中";
                    break;
                case 4:
                    str += "清理";
                    break;
                case 3:
                    str += this.GuestCount.ToString() + "人";

                    if (dataTable.Rows.Count > 0)
                    {
                        str = "合帐到:" + dataTable.DefaultView[0][0].ToString();
                    }
                    dataTable.Clear();
                    break;
                case 5:
                    str += "预定中";
                    break;
                default:
                    break;
            }
            dataTable.Dispose();

            return str;
        }

        public Color GetBtnBackColor()
        {
            switch (this.Status)
            {
                case -1:
                    return Color.FromArgb(0,0,0);    
                case 0:
                    return Color.FromArgb(184, 234, 120);    // 空台
                case 1:
                    return Color.FromArgb(0x12,0xad,0xb2);   // 已开台
                case 2:
                    return Color.FromArgb(0,0x93,0xdd);      // 已上菜
                case 3:
                    return Color.FromArgb(0xdb,0x45,0x29);   //  结帐
                case 4:
                    return Color.Azure;                      // 多单
                case 5:
                    return Color.FromArgb(0xff,0xf5,0);      // 预定
                case 6:
                    return Color.FromArgb(0,0x92,0x40);      // 清理中
                default:
                    return Color.Lime;
            }
        }

        #endregion

        
    }
}
