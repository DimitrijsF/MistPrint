using MistPrintCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MistPrintCore.Enums.Enums;

namespace ApiForms
{
    public class ClientStatus
    {
        [JsonProperty("nozzle_temp")]
        public decimal NozzleTemp { get; set; }
        [JsonProperty("bed_temp")]
        public decimal BedTemp { get; set; }
        [JsonProperty("target_nozzle_temp")]
        public decimal TargetNozzleTemp { get; set; }
        [JsonProperty("target_bed_temp")]
        public decimal TargetBedTemp { get; set; }
        [JsonProperty("esp_temp")]
        public decimal EspTemp { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("last_active")]
        public int LastResponse { get; set; }
        [JsonProperty("current_layer")]
        public int CurrentLayer { get; set; }
        [JsonProperty("total_layers")]
        public int TotalLayers { get; set; }
        [JsonProperty("current_job")]
        public string CurrentJobName { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonProperty("time_spent_gc")]
        public string SpentTimeGc{ get; set; }
        [JsonProperty("time_spent_real")]
        public string SpentTimeReal { get; set; }
        [JsonProperty("remaining_time")]
        public string RemainingTimeString { get; set; }
    }
}
