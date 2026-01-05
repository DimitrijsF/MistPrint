using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Helpers
{
    public static class StatusHelper
    {
        public static void UpdateStatusFromESP(PrinterStatus data)
        {
            Locals.CurrentStatus.NozzleTemp = data.NozzleTemp;
            Locals.CurrentStatus.BedTemp = data.BedTemp;
            Locals.CurrentStatus.TargetNozzleTemp = data.TargetNozzleTemp;
            Locals.CurrentStatus.TargetBedTemp = data.TargetBedTemp;
            Locals.CurrentStatus.LastBeat = DateTime.Now;
            Locals.CurrentStatus.CurrentLayer = data.CurrentLayer;
            if(Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Offline)
            {
                Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
            }
        }
    }
}
