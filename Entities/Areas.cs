namespace RMS.Entities
{
  
    using RMS.Utility;

    [DataTableName("areas", ContainsIdentification = false)]
    public class Areas : EntitiesBase
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
        public System.Int32 Room_Id
        {
            get;
            set;
        }
        public System.Int32 Orders
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
