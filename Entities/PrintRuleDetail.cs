namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("printruledetail", ContainsIdentification = false)]
    public class PrintRuleDetail : EntitiesBase
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
        public System.String PrintFormat
        {
            get;
            set;
        }
        public System.Int32 PrintRule_Id
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
