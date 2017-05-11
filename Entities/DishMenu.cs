namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("dishmenu", ContainsIdentification = false)]
    public class DishMenu : EntitiesBase
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
        public System.Int32 Category_Id
        {
            get;
            set;
        }
        public System.Int32 Status
        {
            get;
            set;
        }
        public System.Int32 PrintRule_Id
        {
            get;
            set;
        }
        public System.Int32 AutoGq
        {
            get;
            set;
        }
        public System.Int32 IsGq
        {
            get;
            set;
        }
        public System.Int32 AutoPresent
        {
            get;
            set;
        }
        public System.Int32 CanPresent
        {
            get;
            set;
        }
        public System.Int32 IsNewDish
        {
            get;
            set;
        }
        public System.Int32 IsRecommendDish
        {
            get;
            set;
        }
        public System.Int32 CanModifyWeight
        {
            get;
            set;
        }
        public System.Int32 CanDiscount
        {
            get;
            set;
        }
        public System.Int32 Enabled
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
