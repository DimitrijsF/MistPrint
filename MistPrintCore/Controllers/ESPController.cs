using MistPrintCore.Helpers;
using MistPrintCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using static MistPrintCore.Locals;

namespace MistPrintCore.Controllers
{
    [RoutePrefix("api/esp")]
    public class ESPController : ApiController
    {
        [HttpPost]
        [Route("status")]
        public IHttpActionResult ProcessStatus([FromBody] PrinterStatus data)
        {
            try
            {
                StatusHelper.UpdateStatusFromESP(data);
                PrintLogger.WriteLog("ESP Status received.", LoggerForServices.Logger.LogType.INFO);
                return Ok();
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("ESP Status parse error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("report_error")]
        public IHttpActionResult ReportError([FromBody] PrinterError data)
        {
            try
            {
                PrintLogger.WriteLog("Received printer error: " + data.Message, LoggerForServices.Logger.LogType.WARNING);
                PrintHelper.HandlePrinterError(data.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("ESP error parsing printer error :) : " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("get_job")]
        public IHttpActionResult GetJob()
        {
            try
            {
                if (CurrentStatus.Status == Enums.Enums.DeviceStatus.Starting && !string.IsNullOrEmpty(CurrentStatus.CurrentJob))
                {
                    if(Joblines != null && Joblines.Count > 0)
                    {
                        return Ok(JsonConvert.SerializeObject(PrintHelper.GetJoblines(StartLineCount)));
                    }
                    else
                    {
                        PrintLogger.WriteLog("Incorrect status and job lines!", LoggerForServices.Logger.LogType.WARNING);
                        return StatusCode(System.Net.HttpStatusCode.NoContent);
                    }
                }
                else
                {
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error sending job to ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("get_lines")]
        public IHttpActionResult GetLines()
        {
            try
            {
                if (CurrentStatus.Status == Enums.Enums.DeviceStatus.Printing)
                    return Ok(JsonConvert.SerializeObject(PrintHelper.GetJoblines(LinePullCount)));
                else
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error sending lines to ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
    }
}
