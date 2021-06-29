using DeviceId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDgeneratorProba
{
    public class IDgenerator
    {
        private string _deviceId;
        private long _deviceHash;

        public IDgenerator()
        {
            DeviceIdBuilder dIDb = new DeviceIdBuilder();
            _deviceId = dIDb.AddMacAddress().AddProcessorId().AddMotherboardSerialNumber().ToString();
            _deviceHash = dIDb.AddMacAddress().GetHashCode();
        }

        public string getIDOnFluent()
        {
            return _deviceId;
        }

        public long getHashOnFluent()
        {
            return _deviceHash;
        }
    }
}
