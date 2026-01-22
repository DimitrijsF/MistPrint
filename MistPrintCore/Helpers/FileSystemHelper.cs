using LoggerForServices;
using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Helpers
{
    public static class FileSystemHelper
    {
        public static void RefreshFileList()
        {
            try
            {
                Locals.MainLogger.WriteLog("Refreshing file list", Logger.LogType.INFO);
                Locals.FileRoot = new FileSystem.Directory()
                {
                    Name = "root",
                    Path = "/",
                    Directories = new List<FileSystem.Directory>()
                };
                ProcessDirectory(Locals.FileDir, Locals.FileRoot);                
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Error rescanning file list: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
            }
        }
        private static void ProcessFiles(string path, FileSystem.Directory directory)
        {
            List<FileSystem.File> files = new List<FileSystem.File>();
            foreach (var file in Directory.GetFiles(path))
            { 
                FileInfo fileInfo = new FileInfo(file); 
                files.Add(new FileSystem.File()
                {
                    Name = fileInfo.Name,
                    Size = Math.Round(Convert.ToDouble(fileInfo.Length) / 1024 / 1024, 2, MidpointRounding.AwayFromZero),
                    Modified = fileInfo.LastWriteTime,
                    Path = fileInfo.FullName.Replace(Locals.FileDir, "").Replace("\\", "/")
                });
            }
            directory.Files = files;
        }
        private static void ProcessDirectory(string path, FileSystem.Directory currentDir)
        {
            ProcessFiles(path, currentDir);
            foreach (var dir in Directory.GetDirectories(path))
            {
                var subDir = new FileSystem.Directory()
                {
                    Name = new DirectoryInfo(dir).Name,
                    Path = dir.Replace(Locals.FileDir, "/").Replace("\\", "/"),
                    Directories = new List<FileSystem.Directory>(),
                    Files = new List<FileSystem.File>()
                };
                currentDir.Directories.Add(subDir);
                ProcessDirectory(dir, subDir);
            }
        }
        public static List<string> ReadFileLines(string path)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith(";"))
                    {
                        if (line.StartsWith(";LAYER_COUNT")) // Process total layer count
                            Locals.CurrentStatus.TotalLayers = Convert.ToInt32(line.Split(':').Last());
                        else if (line.StartsWith(";LAYER:"))
                            lines.Add(line);
                        else
                            continue;
                    }
                    else if(line.Trim().Length > 0)
                        lines.Add(line);
                }
            }

            return lines;
        }
        public static void ProcessDeleteFile(FileRequest data)
        {
            File.Delete(Locals.FileDir + data.Path.Replace("/", "\\"));
            Locals.CurrentStatus.CurrentJob = null;
            RefreshFileList();
        }
        public static FileStream GetFirmwareStream()
        {
            if (string.IsNullOrEmpty(Locals.FirmawarePath))
                return null;
            return new FileStream(Locals.FirmawarePath, FileMode.Open, FileAccess.Read);
        }
        public static void SetJobFile(FileSystem.File file)
        {
            if (Locals.CurrentStatus.Status != Enums.Enums.DeviceJobStatus.Starting &&
               Locals.CurrentStatus.Status != Enums.Enums.DeviceJobStatus.Printing &&
               Locals.CurrentStatus.Status != Enums.Enums.DeviceJobStatus.Finishing)
            {
                Locals.CurrentStatus.CurrentJob = file;
                if (Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Idle)
                    Locals.CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Ready;
            }
        }
        public static void ProcessUploadFile(string activeDir, string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            string destination = Locals.FileDir + activeDir.TrimStart('/') + "\\" + filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
            File.WriteAllBytes(destination, buffer);
            RefreshFileList();
        }
    }
}
