using MistPrintCore.Helpers;
using MistPrintCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MistPrintCore.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("status")]
        public IHttpActionResult GetPrinterStatus()
        {
            try
            {
                return Ok(Locals.CurrentStatus);
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Status error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("get_files")]
        public IHttpActionResult GetFiles(string path)
        {
            try
            {
                if(path == "/")
                    return Ok(Locals.FileRoot);
                else
                    return Ok(Locals.FileRoot.Directories.Find(x=> x.Path == path));
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Get Files error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("refresh_files")]
        public IHttpActionResult RefreshFileList()
        {
            try
            {
                FileSystemHelper.RefreshFileList();
                return Ok(Locals.FileRoot);
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Get All Files error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("get_all_files")]
        public IHttpActionResult GetAllFiles()
        {
            try
            {
                return Ok(Locals.FileRoot);
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Get All Files error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("select_file")]
        public IHttpActionResult SelectFile([FromBody] FileRequest data)
        {
            try
            {
                if (data.Path.ToLower().EndsWith(".gcode"))
                {
                    FileSystem.Directory dir = Locals.FileRoot;

                    foreach (string part in data.Path.Split('/').Where(x => !x.ToLower().EndsWith(".gcode")))
                        if (!string.IsNullOrEmpty(part))
                            dir = dir.Directories.Find(x => x.Name == part);

                    if (dir == null)
                        throw new Exception("Directory not found.");
                    var file = dir.Files.Find(x => x.Path == data.Path.Remove(0, 1));
                    if (file == null)
                        throw new Exception("File not found.");
                    FileSystemHelper.SetJobFile((FileSystem.File)file);
                    return Ok();
                }
                else
                    return Ok("incorrect file format");
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Start Print error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("start_print")]
        public IHttpActionResult StartPrint()
        {
            try
            {
                Locals.Core.StartPrint();
                return Ok();
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Start Print error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("stop_print")]
        public IHttpActionResult StopPrint()
        {
            try
            {
                if (Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Starting ||
                    Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Printing ||
                    Locals.CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Finishing)
                {
                    Locals.Core.StopPrint();
                    return Ok();
                }
                else
                    return BadRequest("No active print job to stop.");
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client stop ptint error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("delete_file")]
        public IHttpActionResult DeleteFile([FromBody] FileRequest data)
        {
            try
            {
                FileSystemHelper.ProcessDeleteFile(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Delete File error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("upload_file")]
        public async Task<IHttpActionResult> UploadFile()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    return BadRequest("Unsupported media type");

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var pathPart = provider.Contents
                    .FirstOrDefault(c => c.Headers.ContentDisposition.Name.Trim('"') == "path");

                var path = pathPart != null
                    ? await pathPart.ReadAsStringAsync()
                    : "/";

                var filePart = provider.Contents
                    .FirstOrDefault(c => c.Headers.ContentDisposition.FileName != null);

                if (filePart == null)
                    return BadRequest("File missing");

                var fileName = filePart.Headers.ContentDisposition.FileName.Trim('"');
                var buffer = await filePart.ReadAsByteArrayAsync();

                var targetDir = Path.Combine(
                    Locals.FileDir,
                    path.TrimStart('/')
                );

                Directory.CreateDirectory(targetDir);

                var filePath = Path.Combine(targetDir, fileName);
                File.WriteAllBytes(filePath, buffer);
                FileSystemHelper.RefreshFileList();
                return Ok();
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Upload File error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
    }
}
