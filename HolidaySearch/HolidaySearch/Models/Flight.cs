using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidaySearch.Models
{
    public class Flight
    {
        /* SAMPLE FLIGHT OBJECT
        "id": 1,
        "airline": "First Class Air",
        "from": "MAN",
        "to": "TFS",
        "price": 470,
        "departure_date": "2023-07-01"
        */

        /* Example input
        * Departing from: Manchester Airport (MAN)
        * Traveling to: Malaga Airport (AGP)
        * Departure Date: 2023/07/01
        * Duration: 7 nights
        ##### Expected result  
        * Flight 2 and Hotel 9
        */

        public int Id { get; set; }
        public string Airline { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string DepartureID { get; set; } //searchable

        [JsonProperty(PropertyName = "to")]
        public string DestinationID  { get; set; } //searchable
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "departure_date")]
        public string DepartureDate { get; set; } //searchable

        /*
        public Flight(string departingFrom, string travellingTo, string departureDate)
        {
            DepartureID = departingFrom;
            DestinationID = travellingTo;
            DepartureDate = departureDate;
        }
        */

        public List<Flight> GetAllFlights()
        {
            //returns all flights from FlightData
            string filePathFlights = @".\Data\FlightData.json";

            return JSONParser.LoadFlights(filePathFlights); 
        }
        public List<Flight> GetMatchingFlights(string departingFrom, string travellingTo, string departureDate)
        { 
            //return flights matching: DepartureID, DestinationID, DepartureDate

            return null;
        }

    }
}
