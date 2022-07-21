using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class JSONParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnAListOfFlightObjects()
        {
            //Arrange

            string filePath = @".\Data\FlightData.json";
            
            //Assert
            List<Flight> flights = JSONParser.LoadFlights(filePath);

            //Assert
            flights.Should().NotBeEmpty()
                .And.HaveCount(12);
        }
    }
}