namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tablestyle", ContainsIdentification = false)]
    public class TableStyle : EntitiesBase
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
        public System.String Memo
        {
            get;
            set;
        }
    }
}
