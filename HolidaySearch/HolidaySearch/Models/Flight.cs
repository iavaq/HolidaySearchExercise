using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get; set; }
        public string? Airline { get; set; }
        public string? DepartureID { get; set; }
        public string? DestinationID  { get; set; }
        public decimal Price   { get; set; }
        public DateOnly DepartureDate   { get; set; }

     }
}
