using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;
using RMS.Utility;
using RMS.DataAccess;

namespace RMS.Business
{
    public class UsersBusinesscs : BusinessBase<Users>
    {
        public bool UserExists(string userName)
        {
            userName.NotNullOrEmptyOrSpaceWhite("userName");

            return GetInstanceList().Any(u => u.LoginName.ToUpper() == userName.ToUpper());
        }

        public bool PasswordExists(string password)
        {
            password.NotNullOrEmptyOrSpaceWhite("password");

            return GetInstanceList().Any(u => u.Password.ToUpper() == EncryptPwd(password).ToUpper());
        }

        public bool Exists(string userName, string password)
        {
            userName.NotNullOrEmptyOrSpaceWhite("userName");
            password.NotNullOrEmptyOrSpaceWhite("password");

            return GetInstanceList().Any(u => u.Password.ToUpper() == EncryptPwd(password).ToUpper() && u.LoginName.ToUpper() == userName.ToUpper());

        }


        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string EncryptPwd(string password)
        {
            return Cryptography.SimpEncrypt(password);
        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string DecryptPwd(string password)
        {
            return Cryptography.SimpUnEncrypt(password);
        }

    }
}
