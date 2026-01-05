using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Models
{
    [Serializable]
    public class FileRequest
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
