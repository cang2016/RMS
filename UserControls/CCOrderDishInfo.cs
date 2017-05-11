using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RMS.UserControls
{
    public partial class CCOrderDishInfo : UserControl
    {
        public CCOrderDishInfo()
        {
            InitializeComponent();
        }

        private string tableNo = string.Empty;

        [DisplayName("NO")]
        [Category("DisPlay")]
        [Description("台单号")]
        public string TableNo
        {
            get
            {
                return tableNo;
            }
            set
            {
                this.lblTableNo.Text = value;

            }
        }

        private decimal totalMoney = 0.0m;

        [DisplayName("TotalMoney")]
        [Category("DisPlay")]
        [Description("总金额")]
        public decimal TotalMoney
        {
            get
            {
                return totalMoney;
            }
            set
            {
                this.lblTotalMoney.Text = Convert.ToString(value);

            }
        }

        private decimal dishCount = 0.0m;

        [DisplayName("DishCount")]
        [Category("DisPlay")]
        [Description("点菜数量")]
        public decimal DishCount
        {
            get
            {
                return dishCount;
            }
            set
            {
                this.lblDishCount.Text = Convert.ToString(value);

            }
        }

        private string tableName = string.Empty;

        [DisplayName("TableName")]
        [Category("DisPlay")]
        [Description("台号")]
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                this.lblTableName.Text = value;

            }
        }
    }
}
