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
            long iRes;

            int iMAChash;
            int iProcessorID;
            int iMotherBoardNumber;
            DeviceIdBuilder dIDb = new DeviceIdBuilder();
            _deviceId = dIDb.AddMacAddress().AddProcessorId().AddMotherboardSerialNumber().ToString();
            iMAChash = dIDb.AddMacAddress().GetHashCode();
            DeviceIdBuilder MACAddr = dIDb.AddMacAddress();
            iProcessorID = dIDb.AddProcessorId().GetHashCode();
            DeviceIdBuilder ProcessorID = dIDb.AddProcessorId();
            iMotherBoardNumber = dIDb.AddMotherboardSerialNumber().GetHashCode();
            DeviceIdBuilder MotheBoardNumber = dIDb.AddMotherboardSerialNumber();
            iRes = 0xFF << 8;
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
