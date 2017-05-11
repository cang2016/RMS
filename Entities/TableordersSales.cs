namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tableorderssales", ContainsIdentification = false)]
    public class TableordersSales : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 TableOrders_Id
        {
            get;
            set;
        }
        public System.Int32 Sales_Id
        {
            get;
            set;
        }
    }
}
