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
        public string DepartingFrom { get; set; }
        public string TravellingTo { get; set; }
        public string DepartureDate { get; set; }
        public int Duration { get; set; }

        public Tuple<Flight?, Hotel?> BestValueHoliday { get; private set; }

        //TO RETURN OPTIONS
        public Tuple<List<Flight>?, List<Hotel>?> BestValueOptions { get; private set; }

        //search by given combination of fields
        //returns a tuple of best flight and hotel

        //OTB website defaults:
        //Desitnation: Anywhere
        //Departure: All Airports 
        //Date: current + 3 days
        //Duration: 7 
        //fields are always filled!!!

        /* Example input
        * Departing from: Manchester Airport (MAN)
        * Traveling to: Malaga Airport (AGP)
        * Departure Date: 2023/07/01
        * Duration: 7 nights
        ##### Expected result  
        * Flight 2 and Hotel 9
        */

        
        public SearchHoliday(string departingFrom, string travellingTo, string departureDate, int duration)
        {
            DepartingFrom = departingFrom;
            TravellingTo = travellingTo;
            DepartureDate = departureDate;  
            Duration = duration;
        }

        public Tuple<Flight, Hotel> GetBestValueHoliday()
        {
            Flight bestValueFlight = Flight.GetBestValueFlight(DepartingFrom, TravellingTo, DepartureDate);
            Hotel bestValueHotel = Hotel.GetBestValueHotel(TravellingTo, DepartureDate, Duration);

            return Tuple.Create(bestValueFlight!, bestValueHotel!);
        }

        public Tuple<List<Flight>, List<Hotel>> GetBestValueOptions()
        {
            return null;
        }
    }
}
