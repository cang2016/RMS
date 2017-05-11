namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("department", ContainsIdentification = false)]
    public class Department : EntitiesBase
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
    }
}
