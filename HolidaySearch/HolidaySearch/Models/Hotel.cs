using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidaySearch.Models
{
    public class Hotel
    {
        /* SAMPLE Hotel Object
        "id": 1,
        "name": "Iberostar Grand Portals Nous",
        "arrival_date": "2022-11-05",
        "price_per_night": 100,
        "local_airports": ["TFS"],
        "nights": 7
        */

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "arrival_date")]
        public string ArrivalDate { get; set; }

        [JsonProperty(PropertyName = "price_per_night")]
        public decimal PricePerNight { get; set; }

        [JsonProperty(PropertyName = "local_airports")]
        public List<string> LocalAirports { get; set; }

        [JsonProperty(PropertyName = "nights")]
        public int NumberOfNights { get; set; }

    }
}
