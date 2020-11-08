using Newtonsoft.Json;
using System;

namespace SmartGardenMobile.Models
{
    public class SmartPotModel
    {
        [JsonProperty(PropertyName = "temperature")]
        public decimal? Temperature { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public decimal? Humidity { get; set; }
        [JsonProperty(PropertyName = "soil_moisture")]
        public decimal? SoilMoisture { get; set; }
        [JsonProperty(PropertyName = "light")]
        public decimal? Light { get; set; }
        [JsonProperty(PropertyName = "is_raining")]
        public bool? IsRaining { get; set; }
        [JsonProperty(PropertyName = "measured_at_time")]
        public DateTime MeasuredAtTime { get; set; }
    }
}
