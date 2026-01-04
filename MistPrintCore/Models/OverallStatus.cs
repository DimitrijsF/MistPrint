using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MistPrintCore.Enums.Enums;

namespace MistPrintCore.Models
{
    [Serializable]
    public class OverallStatus
    {
        [JsonProperty("nozzle_temp")]
        public decimal NozzleTemp { get; set; }
        [JsonProperty("bed_temp")]
        public decimal BedTemp { get; set; }
        [JsonProperty("target_nozzle_temp")]
        public decimal TargetNozzleTemp { get; set; }
        [JsonProperty("target_bed_temp")]
        public decimal TargetBedTemp { get; set; }
        [JsonIgnore]
        public DeviceStatus Status { get; set; }
        [JsonProperty("status")]
        public string _status
        {
            get
            {
                return Status.ToString();
            }
        }
        [JsonIgnore]
        public DateTime? LastBeat { get; set; }
        [JsonProperty("last_active")]
        public int LastResponse
        {
            get
            {
                return LastBeat.HasValue ? Convert.ToInt32((DateTime.Now - LastBeat.Value).TotalSeconds) : 0;
            }
        }
        [JsonProperty("current_layer")]
        public int CurrentLayer { get; set; }
        [JsonProperty("total_layers")]
        public int TotalLayers { get; set; }
        }
}
