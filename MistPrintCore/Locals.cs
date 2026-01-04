using LoggerForServices;
using MistPrintCore.Enums;
using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MistPrintCore.Enums.Enums;
using static MistPrintCore.Models.FileSystem;

namespace MistPrintCore
{
    public class Locals
    {
        public static Core Core { get; set; } = new Core();
        public static Logger MainLogger { get; set; } = new Logger() { LogDir = @"C:\MistPrint\Logs\", DefaultFileName = "ServiceLog" };
        public static Logger PrintLogger { get; set; } = new Logger() { LogDir = @"C:\MistPrint\Logs\", DefaultFileName = "PrintLog" };
        public const string FileDir = @"C:\MistPrint\Files\";
        public static OverallStatus CurrentStatus { get; set; } = new OverallStatus
        {
            NozzleTemp = 0,
            BedTemp = 0,
            TargetNozzleTemp = 0,
            TargetBedTemp = 0,
            Status = DeviceStatus.Offline,
            LastBeat = null,
            CurrentLayer = 0,
            TotalLayers = 0
        };

        public static Directory FileRoot = new Directory() 
        { 
            Name = "root",
            Directories = new List<Directory>(), 
            Files = new List<File>() 
        };
    }
}
