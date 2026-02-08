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
        public decimal TotalSecondsGc { get; set; }
        [JsonIgnore]
        public float SpentSecondsGc { get; set; }
        [JsonProperty("time_spent_gc")]
        public string SpentTimeGc
        {
            get
            {
                try
                {
                    if (SpentSecondsGc < 0)
                        return "00:00:00";
                    TimeSpan timeSpentgc = TimeSpan.FromSeconds(SpentSecondsGc);
                    return string.Format("{0:00}:{1:00}:{2:00}", timeSpentgc.Hours, timeSpentgc.Minutes, timeSpentgc.Seconds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error formatting total time: " + ex.Message + " time value = " + SpentSecondsGc.ToString());
                    return "00:00:00";
                }
            }
        }
        [JsonIgnore]
        public int SpentSecondsReal { get; set; }
        [JsonProperty("time_spent_real")]
        public string SpentTimeReal
        {
            get
            {
                try
                {
                    if(SpentSecondsReal < 0)
                        return "00:00:00";
                    TimeSpan timeSpent = TimeSpan.FromSeconds(SpentSecondsReal);
                    return string.Format("{0:00}:{1:00}:{2:00}", timeSpent.Hours, timeSpent.Minutes, timeSpent.Seconds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error formatting total time: " + ex.Message + " time value = " + SpentSecondsReal.ToString());
                    return "00:00:00";
                }
            }
        }
        [JsonIgnore]
        public decimal TimeCoeficient { get; set; } = 1;
        [JsonProperty("remaining_time")]
        public string RemainingTimeString
        {
            get
            {
                try
                {
                    if (SpentSecondsReal > 0 && SpentSecondsGc > 0 && CurrentLayer > 0)
                    {
                        decimal seconds = TotalSecondsGc * TimeCoeficient;
                        decimal layerSeconds = seconds - (seconds / TotalLayers * CurrentLayer);
                        TimeSpan remaining = TimeSpan.FromSeconds(Convert.ToDouble(layerSeconds));
                        if (remaining.TotalMinutes > 0)
                            return string.Format("{0:00}h {1:00}m", remaining.Hours, remaining.Minutes);
                        else
                            return "Less than a minute";
                    }
                    else
                        return "Unknown";
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error formatting remaining time: " + ex.Message);
                    return "Unknown";
                }
            }
        }
    }
}
