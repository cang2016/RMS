namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("discount", ContainsIdentification = false)]
    public class DiscountCls : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Discount
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
