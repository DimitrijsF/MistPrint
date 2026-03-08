using MistPrintCore.Helpers;
using MistPrintCore.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using static MistPrintCore.Locals;

namespace MistPrintCore.Controllers
{
    [RoutePrefix("api/esp")]
    public class ESPController : ApiController
    {
        [HttpPost]
        [Route("status")]
        public HttpResponseMessage ProcessStatus([FromBody] PrinterStatus data)
        {
            try
            {
                StatusHelper.UpdateStatusFromESP(data);
                switch (CurrentStatus.Status)
                {
                    case Enums.Enums.DeviceJobStatus.Stopping:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "STOP";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("STOP", Encoding.UTF8, "text/plain")
                        };
                    case Enums.Enums.DeviceJobStatus.Starting:
                        if (LastCommand != "START")
                        {
                            LastCommand = "START";
                            return new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent("START", Encoding.UTF8, "text/plain")
                            };
                        }
                        break;
                    case Enums.Enums.DeviceJobStatus.Finishing:
                        if (LastCommand != "FINISH")
                        {
                            LastCommand = "FINISH";
                            return new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent("FINISH", Encoding.UTF8, "text/plain")
                            };
                        }
                        break;
                    case Enums.Enums.DeviceJobStatus.UPDATE:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "UPDATE";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("UPDATE", Encoding.UTF8, "text /plain")
                        };
                    case Enums.Enums.DeviceJobStatus.BED:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "BED";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("BED=" + BedToSet, Encoding.UTF8, "text/plain")
                        };
                    case Enums.Enums.DeviceJobStatus.NOZZLE:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "NOZZLE";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("NOZZLE=" + NozzleToSet, Encoding.UTF8, "text/plain")
                        };
                    case Enums.Enums.DeviceJobStatus.FAN:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "FAN";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("FAN=" + FanToSet, Encoding.UTF8, "text/plain")
                        };
                    case Enums.Enums.DeviceJobStatus.ZERO:
                        CurrentStatus.Status = Enums.Enums.DeviceJobStatus.Idle;
                        LastCommand = "ZERO";
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent("ZERO", Encoding.UTF8, "text/plain")
                        };
                    case Enums.Enums.DeviceJobStatus.DEBUG:
                        if (LastCommand != "DEBUG")
                        {
                            LastCommand = "DEBUG";
                            return new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent("DEBUG", Encoding.UTF8, "text/plain")
                            };
                        }
                        break;
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("ESP Status parse error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
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
                    return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error sending lines to ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
        [HttpPost]
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
        [HttpPost]
        [Route("err_logs")]
        public IHttpActionResult SaveErrorLogs([FromBody] NvsLog[] data)
        {
            try
            {
                if (data != null && data.Length > 0)
                {
                    FileSystemHelper.SaveCriticalLogs(data.ToList());
                    return Ok();
                }
                else {                     
                    PrintLogger.WriteLog("No critical logs received from ESP", LoggerForServices.Logger.LogType.WARNING);
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("Error saving criticals logs from ESP: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
    }
}
