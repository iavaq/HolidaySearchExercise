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
            List<Flight> actual = Flight.GetAllFlights();


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsAListOfFlights()
        {
            //Arrange
            string departingFrom = Airports.MAN.ToString();

            //Act
            List<Flight> actual = Flight.GetMatchingDeparture(departingFrom);

            //Assert
            actual.Should().NotBeEmpty();
        }

         [Test]
        public void ReturnsAListOfFlightsWithMatchingDepartureID()
        {
            //Arrange
            string departingFrom = Airports.MAN.ToString();
            int expected = 8;

            //Act
            List<Flight> actual = Flight.GetMatchingDeparture(departingFrom);


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsAFlightWithMatchingDepartureID()
        {
            //Arrange
            string departingFrom = Airports.MAN.ToString();
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
            List<Flight> actual = Flight.GetMatchingDeparture(departingFrom);


            //Assert
            actual[7].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Hotel>());
        }
    }
}
