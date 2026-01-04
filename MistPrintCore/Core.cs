using LoggerForServices;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                _webApp = WebApp.Start<ApiConfig>("http://+:8089/");
                MainLogger.WriteLog("PrintServer API started on port 8089", Logger.LogType.INFO);
            }
            catch (Exception ex)
            {
                MainLogger.WriteLog("Failed to start PrintServer API: " + ex.Message, Logger.LogType.FATAL);
                throw;
            }
        }

        public void StartPrint()
        {

        }

        public void AbortPrint()
        {
            CurrentStatus.Status = Enums.Enums.DeviceStatus.ABORT;
        }
    }
}
