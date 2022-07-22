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
            //should really mock data from GetAllFlights
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
                options => options.ComparingByMembers<Flight>());
        }

        [Test]
        public void ReturnsAFlightWithMatchingDestinationID()
        {
            //Arrange
            string travellingTo = Airports.AGP.ToString();
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
            List<Flight> actual = Flight.GetMatchingDestination(travellingTo);


            //Assert
            actual[4].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }

        [Test]
        public void ReturnsAFlightWithMatchingDepartureDate()
        {
            //Arrange
            string departureDate = "2023-07-01";
            Flight expected = new()
            {
                Id = 11,
                Airline = "First Class Air",
                DepartureID = "LGW",
                DestinationID = "AGP",
                Price = 155,
                DepartureDate = "2023-07-01"
            };

            //Act
            List<Flight> actual = Flight.GetMatchingDate(departureDate);


            //Assert
            actual[3].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }

        [Test]
        public void ReturnsAListOfMatchingFlights()
        {
            //Arrange
            string departingFrom = Airports.MAN.ToString();
            string travellingTo = Airports.AGP.ToString();
            string departingDate = "2023-07-01";
            int expected = 1;

            //Act
            List<Flight> actual = Flight.GetMatchingFlights(departingFrom, travellingTo, departingDate);

            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsMatchingIDOFIntersectingFlight()
        {
            //Arrange
            string departingFrom = Airports.MAN.ToString();
            string travellingTo = Airports.AGP.ToString();
            string departingDate = "2023-07-01";
            int expected = 2;

            //Act
            List<Flight> actual = Flight.GetMatchingFlights(departingFrom, travellingTo, departingDate);

            //Assert
            actual[0].Id.Should().Be(expected);
        }
    }
}
