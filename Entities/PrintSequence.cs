namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("printsequence", ContainsIdentification = false)]
    public class PrintSequence : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 Order_Id
        {
            get;
            set;
        }
        public System.DateTime CreateTime
        {
            get;
            set;
        }
        public System.DateTime PrintDate
        {
            get;
            set;
        }
        public System.String PrintNo
        {
            get;
            set;
        }
        public System.String Status
        {
            get;
            set;
        }
        public System.Int32 Flag
        {
            get;
            set;
        }
    }
}
