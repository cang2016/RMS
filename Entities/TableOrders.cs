namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tableorders", ContainsIdentification = false)]
    public class TableOrders : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.String TableNo
        {
            get;
            set;
        }
        public System.DateTime OpenDateTime
        {
            get;
            set;
        }
        public System.Int32 Table_Id
        {
            get;
            set;
        }
        public System.Int32 GuestCount
        {
            get;
            set;
        }
        public System.DateTime CloseDateTime
        {
            get;
            set;
        }
        public System.Int32 State
        {
            get;
            set;
        }
        public System.Int32 IsPrint
        {
            get;
            set;
        }
        public System.Single ServiceFee
        {
            get;
            set;
        }
        public System.Int32 SalePoin_tId
        {
            get;
            set;
        }
        public System.Int32 IsSelfPrice
        {
            get;
            set;
        }
        public System.Single SelfMoney
        {
            get;
            set;
        }
        public System.Int32 MealTime_Id
        {
            get;
            set;
        }
        public System.Int32 IsApplyZero
        {
            get;
            set;
        }
        public System.Single ApplyZeroMoney
        {
            get;
            set;
        }
        public System.Int32 IsPrivilege
        {
            get;
            set;
        }
        public System.Single PrivilegeMoney
        {
            get;
            set;
        }
        public System.Int32 RoundType
        {
            get;
            set;
        }
        public System.Single MinConsumption
        {
            get;
            set;
        }
        public System.Int32 Discount_Id
        {
            get;
            set;
        }
        public System.Single DiscountMoney
        {
            get;
            set;
        }
        public System.Int32 DiscountType
        {
            get;
            set;
        }
        public System.Single ARMoney
        {
            get;
            set;
        }
        public System.Single ExMoney
        {
            get;
            set;
        }
        public System.Int32 SalesId
        {
            get;
            set;
        }
        public System.Int32 WaiterId
        {
            get;
            set;
        }
        public System.Int32 ServiceType
        {
            get;
            set;
        }
        public System.Single NewDishMoney
        {
            get;
            set;
        }
    }
}
