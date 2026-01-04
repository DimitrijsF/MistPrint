using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Enums
{
    public class Enums
    {
        public enum DeviceStatus
        {
            Offline, 
            Idle,
            Starting,
            Printing,
            Finishing,
            ERROR,
            ABORT
        }
    }
}
