using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class JSONParserTests
    {
        private string filePathFlights;
        private string filePathHotels;

        [SetUp]
        public void Setup()
        {
            filePathFlights = @".\Data\FlightData.json";
            filePathHotels = @".\Data\HotelData.json";

            /* A Flight object
            "id": 12,
            "airline": "Trans American Airlines",
            "from": "MAN",
            "to": "AGP",
            "price": 202,
            "departure_date": "2023-10-25"
            

            /* A Hotel object
            "id": 13,
            "name": "Jumeirah Port Soller",
            "arrival_date": "2023-06-15",
            "price_per_night": 295,
            "local_airports": ["PMI"],
            "nights": 10
            */
        }

        [Test]
        public void ShouldReturnAListOfFlightObjects()
        {
            //Arrange
            int expected = 12;
            
            //Act
            List<Flight> actual = JSONParser.LoadFlights(filePathFlights);


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ShouldReturnAFlightInfo()
        {
            //Arrange
            Flight expected = new()
            {
                Id = 12,
                Airline = "Trans American Airlines",
                DepartureID = "MAN",
                DestinationID = "AGP",
                Price = 202,
                DepartureDate = "2023-10-25"
            };

            //Act
            List<Flight> actual = JSONParser.LoadFlights(filePathFlights);


            //Assert
            actual[11].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }

        [Test]
        public void ShouldReturnAListOfHotelObjects()
        {
            //Arrange
            int expected = 13;

            //Act
            List<Hotel> actual = JSONParser.LoadHotels(filePathHotels);


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ShouldReturnHotelInfo()
        {
            //Arrange
            Hotel expected = new()
            {
                Id = 13,
                Name = "Jumeirah Port Soller",
                ArrivalDate = "2023-06-15",
                PricePerNight = 295,
                LocalAirports = new List<string> {"PMI"},
                NumberOfNights = 10
                 
            };

            //Act
            List<Hotel> actual = JSONParser.LoadHotels(filePathHotels);


            //Assert
            actual[12].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Hotel>());
        }
    }
}