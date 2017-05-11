namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("users", ContainsIdentification = false)]
    public class Users : EntitiesBase
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
        public System.String LoginName
        {
            get;
            set;
        }
        public System.String Password
        {
            get;
            set;
        }
        public System.DateTime LastLoginName
        {
            get;
            set;
        }
        public System.DateTime LoginDataTime
        {
            get;
            set;
        }
        public System.Int32 Department_Id
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
