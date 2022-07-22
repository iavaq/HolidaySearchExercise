using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class FlightTests
    {
        private Flight flight;

        [SetUp]
        public void Setup()
        {
            flight = new();
        }

        [Test]
        public void ReturnsAllFlightFromData()
        {
            //Arrange
            int expected = 12;

            //Act
            List<Flight> actual = flight.GetAllFlights();


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

    }
}
