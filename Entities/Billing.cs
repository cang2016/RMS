namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("billing", ContainsIdentification = false)]
    public class Billing : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.String BillNo
        {
            get;
            set;
        }
        public System.Int32 TableOrders_Id
        {
            get;
            set;
        }
        public System.DateTime CreatDateTime
        {
            get;
            set;
        }
        public System.Int32 MealTime_Id
        {
            get;
            set;
        }
        public System.Int32 SalePoint_Id
        {
            get;
            set;
        }
        public System.Int32 GuestType_Id
        {
            get;
            set;
        }
        public System.Int32 Users_Id
        {
            get;
            set;
        }
        public System.String UsersName
        {
            get;
            set;
        }
        public System.Int32 Orders_Id
        {
            get;
            set;
        }
        public System.String OrdersName
        {
            get;
            set;
        }
        public System.Int32 WorkShift_Id
        {
            get;
            set;
        }
        public System.String WorkShiftName
        {
            get;
            set;
        }
        public System.Int32 PrintCount
        {
            get;
            set;
        }
        public System.DateTime LastPrintDateTime
        {
            get;
            set;
        }
        public System.Int32 IsInvoice
        {
            get;
            set;
        }
        public System.String InvoiceNo
        {
            get;
            set;
        }
        public System.Int32 DishType_Id
        {
            get;
            set;
        }
    }
}
