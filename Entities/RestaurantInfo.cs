namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("restaurantinfo", ContainsIdentification = false)]
    public class RestaurantInfo : EntitiesBase
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
        public System.String Phone
        {
            get;
            set;
        }
        public System.String Fax
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
