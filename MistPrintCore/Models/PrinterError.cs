using Newtonsoft.Json;
using System;

namespace MistPrintCore.Models
{
    [Serializable]
    public class PrinterError
    {
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
