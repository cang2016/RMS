namespace RMS.Utility
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// 加解密相关操作类
    /// </summary>
    /// <date>2012-02-20</date>
    /// <author>xucj</author>
    public class Cryptography
    {
        private const string DefaultKey = "OD";
     
		/// <summary>
		/// 构造方法
		/// </summary>
		public Cryptography()
		{
		}

		/// <summary>
		/// 使用缺省密钥字符串加密
		/// </summary>
		/// <param name="original">明文</param>
		/// <returns>密文</returns>
		public static string Encrypt(string original)
		{
			return Encrypt(original, DefaultKey);
		}

		/// <summary>
		/// 使用缺省密钥解密
		/// </summary>
		/// <param name="original">密文</param>
		/// <returns>明文</returns>
		public static string Decrypt(string original)
		{
			return Decrypt(original, DefaultKey, System.Text.Encoding.Default);
		}

		/// <summary>
		/// 使用给定密钥解密
		/// </summary>
		/// <param name="original">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
		public static string Decrypt(string original, string key)
		{
			return Decrypt(original, key, System.Text.Encoding.Default);
		}

		/// <summary>
		/// 使用缺省密钥解密,返回指定编码方式明文
		/// </summary>
		/// <param name="original">密文</param>
		/// <param name="encoding">编码方式</param>
		/// <returns>明文</returns>
		public static string Decrypt(string original, Encoding encoding)
		{
			return Decrypt(original, DefaultKey, encoding);
		}

		/// <summary>
		/// 使用给定密钥加密
		/// </summary>
		/// <param name="original">原始文字</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
		public static string Encrypt(string original, string key)
		{
			byte[] buff = System.Text.Encoding.Default.GetBytes(original);
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);

			return Convert.ToBase64String(Encrypt(buff, kb));
		}

		/// <summary>
		/// 使用给定密钥解密
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <param name="encoding">字符编码方案</param>
		/// <returns>明文</returns>
		public static string Decrypt(string encrypted, string key, Encoding encoding)
		{
			byte[] buff = Convert.FromBase64String(encrypted);
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);

			return encoding.GetString(Decrypt(buff, kb));
		}

		/// <summary>
		/// 生成MD摘要
		/// </summary>
		/// <param name="original">数据源</param>
		/// <returns>摘要</returns>
		private static byte[] MakeMD(byte[] original)
		{
			MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
			byte[] keyhash = hashmd.ComputeHash(original);
			hashmd = null;

			return keyhash;
		}

		/// <summary>
		/// 使用给定密钥加密
		/// </summary>
		/// <param name="original">明文</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
		private static byte[] Encrypt(byte[] original, byte[] key)
		{
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			des.Key = MakeMD(key);
			des.Mode = CipherMode.ECB;

			return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
		}

		/// <summary>
		/// 使用给定密钥解密数据
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
		private static byte[] Decrypt(byte[] encrypted, byte[] key)
		{
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			des.Key = MakeMD(key);
			des.Mode = CipherMode.ECB;

			return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
		}

		/// <summary>
		/// 使用给定密钥加密
		/// </summary>
		/// <param name="original">原始数据</param>
		/// <returns>密文</returns>
		private static byte[] Encrypt(byte[] original)
		{
			byte[] key = System.Text.Encoding.Default.GetBytes(DefaultKey);

			return Encrypt(original, key);
		}

		/// <summary>
		/// 使用缺省密钥解密数据
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <returns>明文</returns>
		private static byte[] Decrypt(byte[] encrypted)
		{
			byte[] key = System.Text.Encoding.Default.GetBytes(DefaultKey);

			return Decrypt(encrypted, key);
		}

        public static string SimpEncrypt(string str)
        {
            StringBuilder asc = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int b = char.Parse(str.Substring(i, 1)) + '\x0003';
                asc.Append((char)b);
            }
            return asc.ToString();
        }

        public static string SimpUnEncrypt(string str)
        {
            StringBuilder asc = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int b = char.Parse(str.Substring(i, 1)) - '\x0003';
                asc.Append((char)b);
            }
            return asc.ToString();
        }
    }
}
