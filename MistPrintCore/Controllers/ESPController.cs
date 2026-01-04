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
        public IHttpActionResult Beat([FromBody] PrinterStatus data)
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
                return Ok();
            }
            catch (Exception ex)
            {
                PrintLogger.WriteLog("ESP error parsing printer error :) : " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }
        }
    }
}
