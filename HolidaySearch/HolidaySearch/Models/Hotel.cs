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

        /* Example input
        * Departing from: Manchester Airport (MAN)
        * Traveling to: Malaga Airport (AGP)
        * Departure Date: 2023/07/01
        * Duration: 7 nights
        ##### Expected result  
        * Flight 2 and Hotel 9
        */

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "arrival_date")]
        public string ArrivalDate { get; set; } //required

        [JsonProperty(PropertyName = "price_per_night")]
        public decimal PricePerNight { get; set; }

        [JsonProperty(PropertyName = "local_airports")] 
        public List<string> LocalAirports { get; set; } //required

        [JsonProperty(PropertyName = "nights")]
        public int NumberOfNights { get; set; } //required

        public static List<Hotel> GetAllHotels()
        {
            //returns all hotels from hotel data
            string filePathHotel = @".\Data\HotelData.json";
 
            return JSONParser.LoadHotels(filePathHotel);

        }
        
        public static Hotel GetBestValueFlight(string arrivalAirport, string date, int duration)
        {
            //call each get matches method below
            //find intersections 
            //return list of hotels

            List<Hotel> matchingAirports = GetLocalHotels(arrivalAirport);
            List<Hotel> matchingDate = GetMatchingDate(date);
            List<Hotel> matchingDuration = GetMatchingDuration(duration);

            List<Hotel> matchingHotels = matchingAirports.Intersect(matchingDate).Intersect(matchingDuration).ToList();

            //send list to method to find cheapest
            return OrderByLowestPrice(matchingHotels).First();
        }
       
        public static List<Hotel> OrderByLowestPrice(List<Hotel> matchingHotels)
        {
            List<Hotel> lowestPriceHotels = matchingHotels.OrderBy(hotel => hotel.PricePerNight).ToList();

            return lowestPriceHotels;
        }

        public static List<Hotel> GetLocalHotels(string arrivalAirport)
        {
            List<Hotel> allHotel = GetAllHotels();


            List<Hotel> matchingHotels = allHotel.Where(hotel =>
                hotel.LocalAirports.Contains(arrivalAirport)).ToList();

                return matchingHotels;
        }

        public static List<Hotel> GetMatchingDate(string date)
        {
            List<Hotel> allHotels = GetAllHotels();
            List<Hotel> matchingHotels = allHotels.Where(hotel =>
                hotel.ArrivalDate.Equals(date)).ToList();

            return matchingHotels;
        }

        public static List<Hotel> GetMatchingDuration(int duration)
        {
            List<Hotel> allHotels = GetAllHotels();
            List<Hotel> matchingHotels = allHotels.Where(hotel =>
                hotel.NumberOfNights.Equals(duration)).ToList();

            return matchingHotels;
        }

        //Helper methods for Hotel Flight instances equality 
        private bool Equals(Hotel other)
        {
            if (other is null)
                return false;

            return this.Id == other.Id;
        }

        public override bool Equals(Object obj) => Equals(obj as Hotel);
        public override int GetHashCode() => (Id).GetHashCode();
    }
}

