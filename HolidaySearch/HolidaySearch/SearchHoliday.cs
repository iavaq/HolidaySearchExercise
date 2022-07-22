using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearch.Models;

namespace HolidaySearch
{
    public class SearchHoliday
    {
        public string? DepartingFrom { get; set; }
        public string? TravellingTo { get; set; }
        public string? DepartureDate { get; set; }
        public int? Duration { get; set; }

        //search by given combination of fields
        //returns a tuple of best flight and hotel
        //???if no fields given, return tuple of cheapest flight and hotel

        public Tuple<Flight, Hotel> ByDepartureDestinationDate(string departingFrom, string travellingTo, string departureDate)
        {
            Flight bestFlight = new(departingFrom, travellingTo, departureDate);

            return null;
        }

        public Tuple<Flight, Hotel> ByDestinationDate(string travellingTo, string departureDate)
        {
            Flight bestFlight = new(travellingTo, departureDate);

            return null;
        }
    }
}
