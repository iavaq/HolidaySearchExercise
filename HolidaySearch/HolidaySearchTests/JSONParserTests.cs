using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class JSONParserTests
    {
        private string filePath;

        [SetUp]
        public void Setup()
        {

            filePath = @".\Data\FlightData.json";

            /* A Flight object
            "id": 12,
            "airline": "Trans American Airlines",
            "from": "MAN",
            "to": "AGP",
            "price": 202,
            "departure_date": "2023-10-25"
            */

        }

        [Test]
        public void ShouldReturnAListOfFlightObjects()
        {
            //Arrange

            
            
            //Act
            List<Flight> flights = JSONParser.LoadFlights(filePath);

            //Assert
            flights.Should().NotBeEmpty()
                .And.HaveCount(12);
        }

        [Test]
        public void ShouldReturnFlightInfo()
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
            List<Flight> flights = JSONParser.LoadFlights(filePath);


            //Assert
            flights[11].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }
    }
}