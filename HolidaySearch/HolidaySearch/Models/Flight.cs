﻿using Newtonsoft.Json;

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
        public string DepartureID { get; set; } //required

        [JsonProperty(PropertyName = "to")]
        public string DestinationID  { get; set; } //required
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "departure_date")]
        public string DepartureDate { get; set; } //required


        public static List<Flight> GetAllFlights()
        {
            //returns all flights from FlightData
            string filePathFlights = @".\Data\FlightData.json";

            return JSONParser.LoadFlights(filePathFlights);
        }
        public static List<Flight> GetBestValueFlights(string departingFrom, string travellingTo, string departureDate)
        {
            //call each get matches method below
            //find intersections 
            //return list of flights

            List<Flight> matchingDeparture = GetMatchingDeparture(departingFrom);
            List<Flight> matchingDestination = GetMatchingDestination(travellingTo);
            List<Flight> matchingDate = GetMatchingDate(departureDate);

            List<Flight> matchingFlights = matchingDeparture.Intersect(matchingDestination).Intersect(matchingDate).ToList();

            //send list to method to find cheapest
            return OrderByLowestPrice(matchingFlights);
        }

        public static List<Flight> OrderByLowestPrice(List<Flight> matchingFlights)
        {
            List<Flight> lowestPriceFlights = matchingFlights.OrderBy(flight => flight.Price).ToList();
            // What about hotels with same price? how will they be sorted?

            return lowestPriceFlights;
        }
        
        public static List<Flight> GetMatchingDeparture(string departingFrom)
        { 
            if (departingFrom.Equals(Airports.AnyAirport.ToString()))
                return GetAllFlights();

            else if (departingFrom.Equals(Airports.AnyLondonAirport.ToString()))
            {
                List<string> londonAirports = new(){Airports.LTN.ToString(),
                                                    Airports.LGW.ToString()};

                List<Flight> matchingFlights = GetAllFlights().Where(flight =>
                    londonAirports.Contains(flight.DepartureID)).ToList();

                return matchingFlights;
            }

            else
            {
                List<Flight> matchingFlights = GetAllFlights().Where(flight =>
                    flight.DepartureID.Equals(departingFrom)).ToList();

                return matchingFlights;
            }

        }

        public static List<Flight> GetMatchingDestination(string travellingTo)
        {
            List<Flight> matchingFlights = GetAllFlights().Where(flight =>
                flight.DestinationID.Equals(travellingTo)).ToList();

            return matchingFlights;
        }

        public static List<Flight> GetMatchingDate(string date)
        {
            List<Flight> matchingFlights = GetAllFlights().Where(flight =>
                flight.DepartureDate.Equals(date)).ToList();

            return matchingFlights;
        }

        //Helper methods for Flight instances equality 
        private bool Equals(Flight other)
        {
            if (other is null)
                return false;

            return this.Id == other.Id;
        }

        public override bool Equals(Object obj) => Equals(obj as Flight);
        public override int GetHashCode() => (Id).GetHashCode();     
    }
}
