using System;

using Newtonsoft.Json;

namespace Odorik.Models.Sms
{
    /// <summary>
    /// Class represents already sent SMS.
    /// </summary>
    public class SentSMS
    {
        public int Id { get; set; }


        public DateTime Date { get; set; }


        public string Direction { get; set; }


        [JsonProperty(PropertyName = "source_number")]
        public string SourceNumber { get; set; }


        [JsonProperty(PropertyName = "destination_number")]
        public string DestinationNumber { get; set; }


        public string Type { get; set; }


        [JsonProperty(PropertyName = "roaming_zone")]
        public string RoamingZone { get; set; }

        
        public string Status { get; set; }


        public double Price { get; set; }

        
        [JsonProperty(PropertyName = "balance_after")]
        public double BalanceAfter { get; set; }


        public int Line { get; set; }
    }
}