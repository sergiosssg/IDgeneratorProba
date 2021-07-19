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
        private byte[] _MACaddres_as_byteArray;

        public IDgenerator()
        {
            string sMACaddr = GetSystemMACID(); //GetSystemMACID("opkisup12.frunze.local");


            _MACaddres_as_stringArray = GetSystemMACID_asStringArray();
            _MACaddres_as_byteArray = GetSystemMACID_asByteArray(_MACaddres_as_stringArray);

            _deviceId = sMACaddr;


            _MACaddres_as_byteArray = StringToByteArray(  sMACaddr);

            long lMACaddrHash = ByteArrayToLong(_MACaddres_as_byteArray);

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


        private static string[] GetSystemMACID_asStringArray() //( string systemName )
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


        private static byte[] GetSystemMACID_asByteArray()
        {
            byte[] arrayReturnedMAC = new byte[6];

            var arr = GetSystemMACID_asStringArray();

            arrayReturnedMAC = arr.Select(byte.Parse).ToArray();


            return arrayReturnedMAC;
        }

        private static byte[] GetSystemMACID_asByteArray(string[] asMACaddress)
        {
            byte[] arrayReturnedMAC = new byte[6];

            arrayReturnedMAC = asMACaddress.Select(byte.Parse).ToArray();

            return arrayReturnedMAC;
        }



        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }


        private static long ByteArrayToLong(byte[] hexArray)
        {
            var lLnnn = Enumerable.Range(0, hexArray.Length).Select((n) => hexArray[n]).ToArray();
            var lN0 = Enumerable.Range(0, hexArray.Length).Select((n) => (hexArray.Length - n)).ToArray();
            var lLl = Enumerable.Range(0, hexArray.Length).Select((n) => hexArray[n] <<  ((hexArray.Length - n) * 8)).ToArray();
            return Enumerable.Range(0, hexArray.Length).Select((n) => hexArray[n] << ((hexArray.Length - n) * 8)).Sum();
        }

    }
}
