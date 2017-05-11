namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("modules", ContainsIdentification = false)]
    public class Modules : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Category_Id
        {
            get;
            set;
        }
        public System.String Name
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
