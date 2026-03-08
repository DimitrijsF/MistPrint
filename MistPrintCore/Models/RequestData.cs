using Newtonsoft.Json;
using System;

namespace MistPrintCore.Models
{
    [Serializable]
    public class RequestData
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
