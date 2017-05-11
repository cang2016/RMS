namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("salespoint", ContainsIdentification = false)]
    public class SalesPoint : EntitiesBase
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
        public System.String Address
        {
            get;
            set;
        }
        public System.Int32 RestaurantType_Id
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
