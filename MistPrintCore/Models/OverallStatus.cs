using Newtonsoft.Json;
using System;
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
        [JsonProperty("esp_temp")]
        public decimal EspTempToClient { get { return Math.Round(EspTemp, 2, MidpointRounding.AwayFromZero); } } 
        [JsonIgnore]
        public decimal EspTemp { get; set; }
        [JsonIgnore]
        public DeviceJobStatus Status { get; set; }
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
        [JsonIgnore]
        public FileSystem.File CurrentJob { get; set; }
        [JsonProperty("current_job")]
        public string CurrentJobName
        {
            get
            {
                return CurrentJob != null ? CurrentJob.Name : "No job selected";
            }
        }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonIgnore]
        public double TotalSeconds { get; set; }
        [JsonProperty("total_time")]
        public string TotalTime { get { return TimeSpan.FromSeconds(TotalSeconds).ToString(); } }
    }
}
