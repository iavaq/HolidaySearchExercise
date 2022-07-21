using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly Arrival { get; private set; }
        public decimal PricePerNight { get; private set; }
        public List<string> LocalAirports { get; private set; }
        public int NumberOfNights { get; private set; }

    }
}
