namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("tastes", ContainsIdentification = false)]
    public class Tastes : EntitiesBase
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
        public System.Int32 Class_Id
        {
            get;
            set;
        }
        public System.Single TastePrice
        {
            get;
            set;
        }
    }
}
