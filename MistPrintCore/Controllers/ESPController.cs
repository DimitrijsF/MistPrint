using MistPrintCore.Helpers;
using MistPrintCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                //just set the printer status to send it to client apps
                StatusHelper.UpdateStatusFromESP(data);
                PrintLogger.WriteLog("ESP Status received.", LoggerForServices.Logger.LogType.INFO);
                if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Stopping)
                {
                    CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                    return Ok("STOP");
                }
                else if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Starting)
                    return Ok("START");
                else if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Finishing)
                    return Ok("FINISH");
                else if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.UPDATE)
                {
                    CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                    return Ok("UPDATE");
                }
                else
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
                if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Starting && CurrentStatus.CurrentJob != null)
                {
                    if(Joblines != null && Joblines.Count > 0)
                    {
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Printing;
                        return Ok(PrintHelper.GetJoblines(StartLineCount));
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
                if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Printing)
                    return Ok(PrintHelper.GetJoblines(LinePullCount));
                else
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error sending lines to ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("finish_job")]
        public IHttpActionResult SetJobFinished()
        {
            try
            {
                if (CurrentStatus.Status == Enums.Enums.DeviceJobStatus.Finishing)
                    Locals.Core.StopPrint();
                return Ok();
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error sending lines to ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("get_firmware")]
        public HttpResponseMessage GetFirmware()
        {
            var path = Locals.FirmawarePath;
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            byte[] data = File.ReadAllBytes(path);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(data);
            response.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = data.Length;

            return response;
        }
    }
}
