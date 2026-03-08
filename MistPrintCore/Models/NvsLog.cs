using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Models
{
    [Serializable]
    public class NvsLog
    {
        [JsonProperty("time")]
        public long EspTime { get; set; }
        [JsonProperty("err")]
        public int EspErr { get; set; }
        [JsonProperty("heap")]
        public int Heap { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }
        [JsonProperty("wifi")]
        public int WifiStatus { get; set; }
    }
}
