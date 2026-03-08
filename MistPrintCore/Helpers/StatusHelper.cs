using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static MistPrintCore.Locals;

namespace MistPrintCore.Helpers
{
    public static class StatusHelper
    {
        private static Timer RealTimer { get; set; } = null;
        public static void UpdateStatusFromESP(PrinterStatus data)
        {
            CurrentStatus.NozzleTemp = data.NozzleTemp;
            CurrentStatus.BedTemp = data.BedTemp;
            CurrentStatus.TargetNozzleTemp = data.TargetNozzleTemp;
            CurrentStatus.TargetBedTemp = data.TargetBedTemp;
            CurrentStatus.LastBeat = DateTime.Now;
            CurrentStatus.LayersDone = data.CurrentLayer;
            CurrentStatus.EspTemp = data.EspTemp;
            CurrentStatus.SpentSecondsGc = data.Time;
            
            if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Offline)
            {
                CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
            }
            if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Printing)
            {
                if (CurrentStatus.LastLayersTimes.Count >= 5)
                    CurrentStatus.LastLayersTimes.Remove(0);
                if (CurrentStatus.LastLayerDoneTime.HasValue)
                    CurrentStatus.LastLayersTimes.Add((DateTime.Now - CurrentStatus.LastLayerDoneTime.Value).TotalSeconds);
                CurrentStatus.LastLayerDoneTime = DateTime.Now;
                CalculateEstimateData();
            }
        }

        public static void StartRealTimer()
        {
            RealTimer = new Timer() { Interval = 1000 };
            RealTimer.Elapsed += (s, e) =>
            {
                CurrentStatus.SpentSecondsReal++;
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
        public static void CalculateEstimateData()
        {
            if (CurrentStatus.TotalLayers > 0 && CurrentStatus.SpentSecondsGc > 0 && CurrentStatus.SpentSecondsReal > 0)
            {
                decimal coef = 1;
                decimal spentGc = Convert.ToDecimal(CurrentStatus.SpentSecondsGc);
                decimal spentReal = Convert.ToDecimal(CurrentStatus.SpentSecondsReal);

                coef = Math.Round(spentReal / spentGc);
                CurrentStatus.TimeCoeficient = coef;
            }
        }
    }
}
