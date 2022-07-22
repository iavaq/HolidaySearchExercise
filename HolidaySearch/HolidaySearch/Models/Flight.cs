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

        //TO DO: CREATE LIST OF FLIGHTS FOR AnyAirport and AllLondonAirports

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


        public static List<Flight> GetAllFlights()
        {
            //returns all flights from FlightData
            string filePathFlights = @".\Data\FlightData.json";

            List<Flight> allFlights = JSONParser.LoadFlights(filePathFlights);
            return allFlights;

        }
        public static List<Flight> GetMatchingFlights(string departingFrom, string travellingTo, string departureDate)
        {
            //call each method below
            //find intersections 
            //return list of flights

            List<Flight> matchingDeparture = GetMatchingDeparture(departingFrom);
            List<Flight> matchingDestination = GetMatchingDestination(travellingTo);
            List<Flight> matchingDate = GetMatchingDate(departureDate);

            List<Flight> matchingFlights = matchingDeparture.Intersect(matchingDestination).Intersect(matchingDate).ToList();

            //send list to method to find cheapest
            return matchingFlights;
        }

        
        public static List<Flight> GetMatchingDeparture(string departingFrom)
        {
            //return flights matching: DepartureID, DestinationID, DepartureDate
            List<Flight> allFlights = GetAllFlights();
            List<Flight> matchingFlights = allFlights.Where(flight =>
                flight.DepartureID.Equals(departingFrom)).ToList();

            return matchingFlights;
        }

        public static List<Flight> GetMatchingDestination(string travellingTo)
        {
            //return flights matching: DepartureID, DestinationID, DepartureDate
            List<Flight> allFlights = GetAllFlights();
            List<Flight> matchingFlights = allFlights.Where(flight =>
                flight.DestinationID.Equals(travellingTo)).ToList();

            return matchingFlights;
        }

        public static List<Flight> GetMatchingDate(string date)
        {
            //return flights matching: DepartureID, DestinationID, DepartureDate
            List<Flight> allFlights = GetAllFlights();
            List<Flight> matchingFlights = allFlights.Where(flight =>
                flight.DepartureDate.Equals(date)).ToList();

            return matchingFlights;
        }

        private bool Equals(Flight other)
        {
            if (other is null)
                return false;

            return this.DepartureID == other.DepartureID;
        }

        public override bool Equals(Object obj) => Equals(obj as Flight);
        public override int GetHashCode() => (Id).GetHashCode();
        
    }
}
