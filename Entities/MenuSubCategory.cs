namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("menusubcategory", ContainsIdentification = false)]
    public class MenuSubCategory : EntitiesBase
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
        public System.Int32 RootCategory_Id
        {
            get;
            set;
        }
        public System.Int32 Discount
        {
            get;
            set;
        }
        public System.Int32 IsselfPrice
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
