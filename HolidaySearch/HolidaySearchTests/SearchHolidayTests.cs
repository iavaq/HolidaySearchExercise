using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class SearchHolidayTests
    {
        private SearchHoliday test1;

        [SetUp]
        public void Setup()
        {
            test1 = new SearchHoliday(Airports.MAN.ToString(), Airports.AGP.ToString(), "2023-07-01", 7);
        }

        [Test]
        public void GetBestValueShouldNotBeNull()
        {
            //Arrange


            //Act
            Tuple<Flight, Hotel> actual = test1.GetBestValueHoliday();

            //Assert
            actual.Should().NotBeNull();
        }

        [Test]
        public void Test1ShouldReturnFlight2AndHotel9()
        {
            //Arrange
            Flight flight = new()
            {
                Id = 2,
                Airline = "Oceanic Airlines",
                DepartureID = "MAN",
                DestinationID = "AGP",
                Price = 245,
                DepartureDate = "2023-07-01"
            };

            Hotel hotel = new()
            {
                Id = 9,
                Name = "Nh Malaga",
                ArrivalDate = "2023-07-01",
                PricePerNight = 83,
                LocalAirports = new List<string> { "AGP" },
                NumberOfNights = 7
            };

            (Flight, Hotel) expected = (flight, hotel);


            //Act
            Tuple<Flight, Hotel> actual = test1.GetBestValueHoliday();

            //Assert
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }
    }
}
