using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return Ok(JsonConvert.SerializeObject(Locals.CurrentStatus));
            }
            catch (Exception ex)
            {
                Locals.MainLogger.WriteLog("Client Status error: " + ex.Message, LoggerForServices.Logger.LogType.ERROR);
                return InternalServerError(ex);
            }   
        }
    }
}
