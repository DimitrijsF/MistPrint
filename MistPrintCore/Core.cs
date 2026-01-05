using LoggerForServices;
using Microsoft.Owin.Hosting;
using MistPrintCore.Helpers;
using MistPrintCore.Models;
using MistPrintCore.Timers;
using System;
using static MistPrintCore.Locals;

namespace MistPrintCore
{
    public class Core
    {
        public IDisposable _webApp;
        public void Initialize()
        {
            try
            {
                MainLogger.WriteLog("Starting...", Logger.LogType.INFO);
                FileSystemHelper.RefreshFileList();
                _webApp = WebApp.Start<ApiConfig>("http://+:8089/");
                MainLogger.WriteLog("PrintServer API started on port 8089", Logger.LogType.INFO);
                BeatTimer.ProcessDelay();
            }
            catch (Exception ex)
            {
                MainLogger.WriteLog("Failed to start PrintServer API: " + ex.Message, Logger.LogType.FATAL);
                throw;
            }
        }
        public void StartPrint()
        {
            PrintHelper.StartJob();
        }
        public void StopPrint()
        {
            PrintHelper.StopJob();
        }
        public void ProcessDeviceDisconnect()
        {
            CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Offline;
            CurrentStatus.BedTemp = 0;
            CurrentStatus.NozzleTemp = 0;
            CurrentStatus.TargetNozzleTemp = 0;
            CurrentStatus.TargetBedTemp = 0;
            CurrentStatus.CurrentLayer = 0;
        }
    }
}
