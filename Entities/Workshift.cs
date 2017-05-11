namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("workshift", ContainsIdentification = true)]
    public class Workshift : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = true)]
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
