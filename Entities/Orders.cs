namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("orders", ContainsIdentification = false)]
    public class OrdersCls : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Menu_Id
        {
            get;
            set;
        }
        public System.String MenuName
        {
            get;
            set;
        }
        public System.Single Amount
        {
            get;
            set;
        }
        public System.Int32 DishPriceId
        {
            get;
            set;
        }
        public System.Single Price
        {
            get;
            set;
        }
        public System.Int32 Status
        {
            get;
            set;
        }
        public System.String UnitName
        {
            get;
            set;
        }
        public System.Int32 IsSetMeal
        {
            get;
            set;
        }
        public System.Int32 IsTwoeat
        {
            get;
            set;
        }
        public System.Int32 IsSend
        {
            get;
            set;
        }
        public System.Int32 IsSelfPrice
        {
            get;
            set;
        }
        public System.Single SelfPrice
        {
            get;
            set;
        }
        public System.DateTime OrderDate
        {
            get;
            set;
        }
        public System.String OrderMan
        {
            get;
            set;
        }
        public System.Single ExMoney
        {
            get;
            set;
        }
        public System.Single AR
        {
            get;
            set;
        }
        public System.Int32 Discount_Id
        {
            get;
            set;
        }
        public System.Int32 Discount
        {
            get;
            set;
        }
        public System.Single DiscountAmount
        {
            get;
            set;
        }
        public System.Int32 IsPresent
        {
            get;
            set;
        }
        public System.Int32 IsReturn
        {
            get;
            set;
        }
        public System.Int32 CanDiscount
        {
            get;
            set;
        }
        public System.Int32 IsMember
        {
            get;
            set;
        }
        public System.Int32 CanMember
        {
            get;
            set;
        }
        public System.Int32 MemberPoint
        {
            get;
            set;
        }
        public System.Int32 IsPrint
        {
            get;
            set;
        }
        public System.Int32 IsBillPrint
        {
            get;
            set;
        }
        public System.Int32 SentTime
        {
            get;
            set;
        }
        public System.Int32 MenuCategory_Id
        {
            get;
            set;
        }
        public System.String CategoryName
        {
            get;
            set;
        }
        public System.Int32 PrintCount
        {
            get;
            set;
        }
        public System.Int32 TableOrders_Id
        {
            get;
            set;
        }
        public System.Int32 Orders
        {
            get;
            set;
        }
        public System.String Memo
        {
            get;
            set;
        }
    }
}
