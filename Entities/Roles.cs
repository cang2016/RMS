namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("roles", ContainsIdentification = false)]
    public class Roles : EntitiesBase
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
