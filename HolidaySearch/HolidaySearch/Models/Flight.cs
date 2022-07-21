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

        public int Id { get; private set; }
        public string Airline { get; private set; }
        public string DepartureID { get; private set; }
        public string ArrivalID  { get; private set; }
        public decimal Price   { get; private set; }
        public DateOnly DepartureDate   { get; private set; }

     }
}
