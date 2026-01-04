using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static MistPrintCore.Locals;
using static MistPrintCore.Enums.Enums;
using MistPrintCore.Helpers;

namespace MistPrintCore.Timers
{
    public class BeatTimer
    {
        const int BeatIntervalSeconds = 15;
        private static Timer timer;
        public static void ProcessDelay()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (BeatIntervalSeconds < CurrentStatus.LastResponse)
            {
                if (CurrentStatus.Status != DeviceStatus.Offline && CurrentStatus.Status != DeviceStatus.Printing)
                {
                    MainLogger.WriteLog("No heartbeat received from printer in " + BeatIntervalSeconds + " seconds. Accepting disconnect.", LoggerForServices.Logger.LogType.WARNING);
                    Locals.Core.ProcessDeviceDisconnect();
                }
                else if (CurrentStatus.Status == DeviceStatus.Printing)
                {
                    MainLogger.WriteLog("No heartbeat received from printer in " + BeatIntervalSeconds + " seconds. Aborting print.", LoggerForServices.Logger.LogType.ERROR);
                    PrintHelper.AbortPrint();
                }
            }
        }
    }
}
