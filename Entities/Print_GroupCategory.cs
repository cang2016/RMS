namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("print_groupcategory", ContainsIdentification = false)]
    public class Print_GroupCategory : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Printer_Id
        {
            get;
            set;
        }
        public System.Int32 Category_Id
        {
            get;
            set;
        }
    }
}
