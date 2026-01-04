using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistPrintCore.Models
{
    [Serializable]
    public class PrinterStatus
    {
        [JsonProperty("nozzle_temp")]
        public decimal NozzleTemp { get; set; }
        [JsonProperty("bed_temp")]
        public decimal BedTemp { get; set; }
        [JsonProperty("target_nozzle_temp")]
        public decimal TargetNozzleTemp { get; set; }
        [JsonProperty("target_bed_temp")]
        public decimal TargetBedTemp { get; set; }
        [JsonProperty("layer")]
        public int CurrentLayer { get; set; }
    }
}
