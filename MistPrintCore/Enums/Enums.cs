using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Enums
{
    public class Enums
    {
        public enum DeviceJobStatus
        {
            Offline, 
            Idle,
            Ready,
            Starting,
            Printing,
            Stopping,
            Finishing,
            ERROR,
            ABORT
        }
    }
}
