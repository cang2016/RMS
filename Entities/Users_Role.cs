namespace RMS.Entities
{
    using RMS.Utility;

    [DataTableName("users_role", ContainsIdentification = false)]
    public class Users_Role : EntitiesBase
    {
        [TableColumn("id", IsPrimaryKey = true, IsIdentification = false)]
        public System.Int32 Id
        {
            get;
            set;
        }
        public System.Int32 User_Id
        {
            get;
            set;
        }
        public System.Int32 Role_Id
        {
            get;
            set;
        }
    }
}
