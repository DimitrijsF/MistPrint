using Newtonsoft.Json;
using System;

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
        [JsonProperty("layer_time")]
        public decimal LayerTime { get; set; }
        [JsonProperty("esp_temp")]
        public decimal EspTemp { get; set; }
    }
}
