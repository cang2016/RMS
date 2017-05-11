namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("printers", ContainsIdentification = false)]
    public class Printers : EntitiesBase
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
        public System.String Code
        {
            get;
            set;
        }
        public System.String Alias
        {
            get;
            set;
        }
        public System.String IPAddress
        {
            get;
            set;
        }
        public System.Int32 PrintGroup_Id
        {
            get;
            set;
        }
        public System.Int32 Status
        {
            get;
            set;
        }
    }
}
