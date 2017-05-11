namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("menutaste", ContainsIdentification = false)]
    public class MenuTaste : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Menu_Id
        {
            get;
            set;
        }
        public System.Int32 Taste_Id
        {
            get;
            set;
        }
        public System.Single Price
        {
            get;
            set;
        }
    }
}
