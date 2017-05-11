namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("dishprice", ContainsIdentification = false)]
    public class DishPrice : EntitiesBase
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
        public System.Single Price
        {
            get;
            set;
        }
        public System.Int32 Menu_Id
        {
            get;
            set;
        }
        public System.Int32 Enabled
        {
            get;
            set;
        }
        public System.Single DefaultPrice
        {
            get;
            set;
        }
    }
}
