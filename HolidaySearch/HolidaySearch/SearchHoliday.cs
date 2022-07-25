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
            //returns ordered list from lowest price 
            Tuple<List<Flight>, List<Hotel>> options = GetBestValueOptions();

            //select first items from list
            Tuple<Flight, Hotel> bestValueHoliday = Tuple.Create(options.Item1.First(), options.Item2.First()); 

            return bestValueHoliday;
        }

        public Tuple<List<Flight>, List<Hotel>> GetBestValueOptions()
        {
            List<Flight> bestValueFlights = Flight.GetBestValueFlights(DepartingFrom, TravellingTo, DepartureDate);
            List<Hotel> bestValueHotels = Hotel.GetBestValueHotels(TravellingTo, DepartureDate, Duration);

            Tuple<List<Flight>, List<Hotel>> bestValueOptions = Tuple.Create(bestValueFlights, bestValueHotels);

            return bestValueOptions;
        }
    }
}
