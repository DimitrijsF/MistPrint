using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MistPrintCore.Helpers
{
    public static class StatusHelper
    {
        private static Timer RealTimer { get; set; } = null;
        public static void UpdateStatusFromESP(PrinterStatus data)
        {
            Locals.CurrentStatus.NozzleTemp = data.NozzleTemp;
            Locals.CurrentStatus.BedTemp = data.BedTemp;
            Locals.CurrentStatus.TargetNozzleTemp = data.TargetNozzleTemp;
            Locals.CurrentStatus.TargetBedTemp = data.TargetBedTemp;
            Locals.CurrentStatus.LastBeat = DateTime.Now;
            Locals.CurrentStatus.CurrentLayer = data.CurrentLayer;
            Locals.CurrentStatus.EspTemp = data.EspTemp;
            Locals.CurrentStatus.SpentSecondsGc = data.Time;
            if (Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Offline)
            {
                Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
            }
            CalculateCoeficient();
        }

        public static void StartRealTimer()
        {
            RealTimer = new Timer() { Interval = 1000 };
            RealTimer.Elapsed += (s, e) =>
            {
                Locals.CurrentStatus.SpentSecondsReal++;
            };
            RealTimer.Start();
        }

        public static void StopRealTimer()
        {
            if(RealTimer == null)
                return;
            RealTimer.Stop();
            RealTimer.Dispose();
        }
        public static void CalculateCoeficient()
        {
            decimal coef = 1;
            if (Locals.CurrentStatus.TotalLayers > 0 && Locals.CurrentStatus.SpentSecondsGc > 0 && Locals.CurrentStatus.SpentSecondsReal > 0)
            {
                decimal spentGc = Convert.ToDecimal(Locals.CurrentStatus.SpentSecondsGc);
                decimal spentReal = Convert.ToDecimal(Locals.CurrentStatus.SpentSecondsReal);

                coef = Math.Round(spentReal / spentGc);
            }
            Locals.CurrentStatus.TimeCoeficient = coef;
        }
    }
}
