namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("restauranttype", ContainsIdentification = false)]
    public class RestaurantType : EntitiesBase
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
    }
}
