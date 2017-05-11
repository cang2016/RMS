namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tables", ContainsIdentification = false)]
    public class Tables : EntitiesBase
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
        public System.Int32 Status
        {
            get;
            set;
        }
        public System.Int32 Area_Id
        {
            get;
            set;
        }
        public System.Single MinConsumption
        {
            get;
            set;
        }
        public System.Single ServiceFee
        {
            get;
            set;
        }
        public System.Int32 Printer_Id
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
