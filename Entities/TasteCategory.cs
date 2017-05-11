namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tastecategory", ContainsIdentification = false)]
    public class TasteCategory : EntitiesBase
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
        public System.Int32 Dishtype_Id
        {
            get;
            set;
        }
    }
}
