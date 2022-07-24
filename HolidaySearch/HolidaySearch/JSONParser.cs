using HolidaySearch.Models;
using Newtonsoft.Json;
using System.Linq;

namespace HolidaySearch
{
    public static class JSONParser
    {
        //Accepts JSON file as input, returns list of objects

        public static List<Flight> LoadFlights(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var flights = JsonConvert.DeserializeObject<List<Flight>>(jsonData);

            return flights!;
        }

        public static List<Hotel> LoadHotels(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(jsonData);

            return hotels!;
        }

    }
}
