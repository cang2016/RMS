namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("paymethod", ContainsIdentification = false)]
    public class PayMethod : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.String Name
        {
            get;
            set;
        }
        public System.String Code
        {
            get;
            set;
        }
        public System.String Detail
        {
            get;
            set;
        }
        public System.Int32 Discount
        {
            get;
            set;
        }
        public System.Int32 Enabled
        {
            get;
            set;
        }
        public System.Int32 Orders
        {
            get;
            set;
        }
    }
}
