namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("print_grouparea", ContainsIdentification = false)]
    public class Print_GroupArea : EntitiesBase
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
        public System.Int32 Area_Id
        {
            get;
            set;
        }
    }
}
