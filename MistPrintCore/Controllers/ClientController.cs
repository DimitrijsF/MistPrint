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
        public IHttpActionResult SelectFile([FromBody] RequestData data)
        {
            try
            {
                if (data.Data.ToLower().EndsWith(".gcode"))
                {
                    FileSystem.Directory dir = Locals.FileRoot;

                    foreach (string part in data.Data.Split('/').Where(x => !x.ToLower().EndsWith(".gcode")))
                        if (!string.IsNullOrEmpty(part))
                            dir = dir.Directories.Find(x => x.Name == part);

                    if (dir == null)
                        throw new Exception("Directory not found.");
                    var file = dir.Files.Find(x => x.Path == data.Data.Remove(0, 1));
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
                    Locals.MainLogger.WriteLog("Print job stopped by user.", LoggerForServices.Logger.LogType.INFO);
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
        [Route("set_bed")]
        public IHttpActionResult SetBedTemp([FromBody] RequestData data)
        {
            try
            {
                if (int.TryParse(data.Data, out int temp))
                {
                    Locals.Core.SetPrinterValue("BED", temp);
                    return Ok();
                }
                else
                    return BadRequest("Invalid temperature value.");
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client set bed temp error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("set_nozzle")]
        public IHttpActionResult SetNozzleTemp([FromBody] RequestData data)
        {
            try
            {
                if (int.TryParse(data.Data, out int temp))
                {
                    Locals.Core.SetPrinterValue("NOZZLE", temp);
                    return Ok();
                }
                else
                    return BadRequest("Invalid temperature value.");
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client set nozzle temp error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("set_fan")]
        public IHttpActionResult SetFanTemp([FromBody] RequestData data)
        {
            try
            {
                if (int.TryParse(data.Data, out int temp))
                {
                    Locals.Core.SetPrinterValue("FAN", temp);
                    return Ok();
                }
                else
                    return BadRequest("Invalid speed value.");
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client set fan speed error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("set_zeros")]
        public IHttpActionResult SetZeros()
        {
            try
            {
                Locals.Core.SetZero();
                return Ok();
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client set all zeros error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("set_debug")]
        public IHttpActionResult SetDebug()
        {
            try
            {
                Locals.Core.SetDebug();
                return Ok();
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client set all zeros error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
    }
}
