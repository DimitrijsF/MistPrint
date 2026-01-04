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
            Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.ERROR;
            Locals.CurrentStatus.ErrorMessage = message;
        }
        public static void HandleInternalError(string message)
        {
            Locals.MainLogger.WriteLog("Internal print error: " + message, LoggerForServices.Logger.LogType.ERROR);
            Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.ERROR;
            Locals.Joblines = null;
            Locals.CurrentStatus.CurrentJob = null;
            Locals.NextLine = 0;
        }
        public static void StartJob(FileSystem.File jobFile)
        {
            try
            {
                Locals.Joblines = FileSystemHelper.ReadFileLines(Locals.FileDir + jobFile.Path.Replace("/", "\\"));
                Locals.CurrentStatus.CurrentJob = jobFile.Name;
                Locals.NextLine = 0;
                Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.Starting;
                Locals.MainLogger.WriteLog("Starting print job: " + jobFile.Name, LoggerForServices.Logger.LogType.INFO);
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
                    Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.Finishing;
                }
                if(Locals.CurrentStatus.Status == Enums.Enums.DeviceStatus.Starting)
                    Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.Printing;
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
            Locals.CurrentStatus.Status = Enums.Enums.DeviceStatus.ABORT;
        }
    }
}
