namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("printgroups", ContainsIdentification = false)]
    public class PrintGroups : EntitiesBase
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
        public System.Int32 IsGroupPrint
        {
            get;
            set;
        }
    }
}
