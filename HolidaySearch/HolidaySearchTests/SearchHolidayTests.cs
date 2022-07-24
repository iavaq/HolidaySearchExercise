using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;

namespace HolidaySearchTests
{
    public class SearchHolidayTests
    {
        private SearchHoliday test1, test2, test3;

        [SetUp]
        public void Setup()
        {
            test1 = new SearchHoliday(Airports.MAN.ToString(), Airports.AGP.ToString(), "2023-07-01", 7);
            test2 = new SearchHoliday(Airports.AnyLondonAirport.ToString(), Airports.PMI.ToString(), "2023-06-15", 10);
            test3 = new SearchHoliday(Airports.AnyAirport.ToString(), Airports.LPA.ToString(), "2022-11-10", 14);
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

        [Test]
        public void Test2ShouldReturnFlight6AndHotel5()
        {
            //Arrange
            Flight flight = new()
            {
                Id = 6,
                Airline = "Fresh Airways",
                DepartureID = "LGW",
                DestinationID = "PMI",
                Price = 75,
                DepartureDate = "2023-06-15"
            };

            Hotel hotel = new()
            {
                Id = 5,
                Name = "Sol Katmandu Park & Resort",
                ArrivalDate = "2023-06-15",
                PricePerNight = 60,
                LocalAirports = new List<string> { "PMI" },
                NumberOfNights = 10
            };

            (Flight, Hotel) expected = (flight, hotel);


            //Act
            Tuple<Flight, Hotel> actual = test2.GetBestValueHoliday();

            //Assert
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }

        [Test]
        public void Test3ShouldReturnFlight7AndHotel6()
        {
            //Arrange
            Flight flight = new()
            {
                Id = 7,
                Airline = "Trans American Airlines",
                DepartureID = "MAN",
                DestinationID = "LPA",
                Price = 125,
                DepartureDate = "2022-11-10"
            };

            Hotel hotel = new()
            {
                Id = 6,
                Name = "Club Maspalomas Suites and Spa",
                ArrivalDate = "2022-11-10",
                PricePerNight = 75,
                LocalAirports = new List<string> { "LPA" },
                NumberOfNights = 14
            };

            (Flight, Hotel) expected = (flight, hotel);


            //Act
            Tuple<Flight, Hotel> actual = test3.GetBestValueHoliday();

            //Assert
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Flight>());
        }
    }
}
