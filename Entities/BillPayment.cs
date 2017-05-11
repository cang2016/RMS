namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("billpayment", ContainsIdentification = false)]
    public class BillPayment : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Bill_Id
        {
            get;
            set;
        }
        public System.Int32 Paymethod_Id
        {
            get;
            set;
        }
        public System.Single PaywayMoney
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
