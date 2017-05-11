namespace RMS.Utility
{
    using System.Management;
    using System.Net;

    public class NetHelper
    {
        /// <summary>
        /// 取得本机IP.
        /// </summary>
        public static string GetIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (var item in addr)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    continue;
                }

                return item.ToString();
            }

            return null;
        }

        /// <summary>
        /// 获取本机MAC地址.
        /// </summary>
        /// <returns></returns>
        public static string GetLocalMACAddress()
        {
            string mac = string.Empty;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
                if(mo["IPEnabled"].ToString() == "True")
                {
                    mac = mo["MacAddress"].ToString();
                }
            }

            return mac;
        }


        /// <summary>
        /// 获取本机名
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            string hostName = Dns.GetHostName();

            return hostName;
        }

    }
}
