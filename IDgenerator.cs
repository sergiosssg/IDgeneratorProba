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

        public IDgenerator()
        {
            _deviceId = new DeviceIdBuilder().AddMacAddress().AddProcessorId().AddMotherboardSerialNumber().ToString();
        }

        public string getIDOnFluent()
        {
            return _deviceId;
        }
    }
}
