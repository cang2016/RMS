namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("mealtimes", ContainsIdentification = false)]
    public class Mealtimes : EntitiesBase
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
        public System.TimeSpan BeginTime
        {
            get;
            set;
        }
        public System.TimeSpan EndTime
        {
            get;
            set;
        }
        public System.Int32 StarttimeIsNextDay
        {
            get;
            set;
        }
        public System.Int32 EndtimeIsNextDay
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
