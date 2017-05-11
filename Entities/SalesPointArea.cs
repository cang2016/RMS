namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("salespointarea", ContainsIdentification = false)]
    public class SalesPointArea : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 SalesPoint_Id
        {
            get;
            set;
        }
        public System.Int32 Area_Id
        {
            get;
            set;
        }
    }
}
