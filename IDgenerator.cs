//using DeviceId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace IDgeneratorProba
{
    public class IDgenerator
    {
        private string _deviceId;
        private long _deviceHash;
        private string[] _MACaddres_as_stringArray;

        public IDgenerator()
        {
            string sMACaddr = GetSystemMACID(); //GetSystemMACID("opkisup12.frunze.local");


            _MACaddres_as_stringArray = GetSystemMACID_as_Array();


            _deviceId = sMACaddr;
            _deviceHash = Math.Abs(sMACaddr.GetHashCode());
        }

        public string getIDOnFluent()
        {
            return _deviceId;
        }

        public long getHashOnFluent()
        {
            return _deviceHash;
        }


        private static string GetSystemMACID () //( string systemName )
        {
            ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
            ManagementObjectCollection theCollectionOfResults = theSearcher.Get();
            try
            {
                foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                {
                    if (theCurrentObject["MACAddress"] != null)
                    {
                        string macAdd = theCurrentObject["MACAddress"].ToString();
                        return macAdd.Replace(":", "");
                    }
                }

            }
            catch (ManagementException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return string.Empty;
        }

        private static string[] GetSystemMACID_as_Array() //( string systemName )
        {
            string[] arrayReturnedMAC = new string[6];
            ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
            ManagementObjectCollection theCollectionOfResults = theSearcher.Get();
            try
            {
                foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                {
                    if (theCurrentObject["MACAddress"] != null)
                    {
                        string macAdd = theCurrentObject["MACAddress"].ToString();
                        arrayReturnedMAC = macAdd.Split(':');
                        return arrayReturnedMAC;
                    }
                }

            }
            catch (ManagementException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
    }
}
