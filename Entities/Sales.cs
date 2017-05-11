namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("sales", ContainsIdentification = false)]
    public class Sales : EntitiesBase
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
