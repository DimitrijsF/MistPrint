using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Helpers
{
    public class PrintHelper
    {
        public static void HandlePrinterError(string message)
        {
            Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.ERROR;
            Locals.CurrentStatus.ErrorMessage = message;
            StopJob();
        }
        public static void HandleInternalError(string message)
        {
            Locals.MainLogger.WriteLog("Internal print error: " + message, LoggerForServices.Logger.LogType.ERROR);
            Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.ERROR;
            Locals.Joblines = null;
            Locals.CurrentStatus.CurrentJob = null;
            Locals.NextLine = 0;
        }
        public static void StopJob()
        {
            StatusHelper.StopRealTimer();
            if (Locals.CurrentStatus.Status != Enums.Enums.DeviceJobStatus.ERROR && Locals.CurrentStatus.Status != Enums.Enums.DeviceJobStatus.ABORT)
                Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Stopping;
            Locals.Joblines = null;
            Locals.CurrentStatus.CurrentJob = null;
            Locals.NextLine = 0;
            Locals.CurrentStatus.CurrentLayer = 0;
            Locals.CurrentStatus.TotalLayers = 0;
            Locals.CurrentStatus.SpentSecondsGc = 0;
            Locals.CurrentStatus.SpentSecondsReal = 0;
            Locals.CurrentStatus.TotalSecondsGc = 0;
            Locals.MainLogger.WriteLog("Print job stopped by user.", LoggerForServices.Logger.LogType.INFO);
        }
        public static void StartJob()
        {
            try
            {
                Locals.Joblines = FileSystemHelper.ReadFileLines(Locals.FileDir + Locals.CurrentStatus.CurrentJob.Path.Replace("/", "\\"));
                Locals.NextLine = 0;
                Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Starting;
                StatusHelper.StartRealTimer();
                Locals.MainLogger.WriteLog("Starting print job: " + Locals.CurrentStatus.CurrentJob.Name, LoggerForServices.Logger.LogType.INFO);
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Failed to start job: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                HandleInternalError(ex.Message);
            }
        }
        public static List<string> GetJoblines(int count)
        {
            try
            {
                List<string> lines = new List<string>();
                if (Locals.Joblines.Count >= Locals.NextLine + count)
                {
                    lines = Locals.Joblines.GetRange(Locals.NextLine, count);
                    Locals.NextLine += count;
                }
                else
                {
                    lines = Locals.Joblines.GetRange(Locals.NextLine, Locals.Joblines.Count - Locals.NextLine);
                    Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Finishing;
                }
                if(Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Starting)
                    Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Printing;
                return lines;
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Failed to get job lines: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                HandleInternalError(ex.Message);
                return null;
            }
        }
        public static void AbortPrint()
        {
            Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.ABORT;
            StopJob();
        }
    }
}
