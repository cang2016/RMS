namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("waiters", ContainsIdentification = false)]
    public class Waiters : EntitiesBase
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
    }
}
