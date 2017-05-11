namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("modulecategory", ContainsIdentification = false)]
    public class ModuleCategory : EntitiesBase
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
    }
}
