using HolidaySearch.Models;
using HolidaySearch;
using FluentAssertions;


namespace HolidaySearchTests
{
    public class HotelTests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new();
        }

        [Test]
        public void ReturnsAllHoteslFromData()
        {
            //DO MOCK

            //Arrange
            int expected = 13;

            //Act
            List<Hotel> actual = Hotel.GetAllHotels();


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsOrderedListofHotelsFromLowestPricePerNight()
        {
            //Arrange
            List<Hotel> hotels = Hotel.GetAllHotels();
            int expected = 45;

            //Act
            List<Hotel> actual = Hotel.OrderByLowestPrice(hotels);


            //Assert
            actual[0].PricePerNight.Should().Be(expected);
        }


        [Test]
        public void ReturnsAListofLocalHotels()
        {
            //Arrange
            string arrivalAirport = Airports.AGP.ToString();
            int expected = 4;

            //Act
            List<Hotel> actual = Hotel.GetLocalHotels(arrivalAirport);


            //Assert
            actual.Should().HaveCount(expected);
        }

        [Test]
        public void ReturnsHotelsInAGPAirport()
        {
            //Arrange
            string arrivalAirport = Airports.AGP.ToString();
            Hotel expected = new()
            {
                Id = 12,
                Name = "MS Maestranza Hotel",
                ArrivalDate = "2023-07-01",
                PricePerNight = 45,
                LocalAirports = new List<string> {"AGP"},
                NumberOfNights = 14
            };

            //Act
            List<Hotel> actual = Hotel.GetLocalHotels(arrivalAirport);


            //Assert
            actual[3].Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Hotel>());
        }

        [Test]
        public void ReturnsAListOfHotelsWithMatchingDate()
        {
            //Arrange
            string arrivalDate = "2023-07-01";
            int expected = 2;

            //Act
            List <Hotel> actual = Hotel.GetMatchingDate(arrivalDate);


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsAHotelWithMatchingDate()
        {
            //Arrange
            string arrivalDate = "2023-07-01";
            Hotel expected = new()
            {
                Id = 12,
                Name = "MS Maestranza Hotel",
                ArrivalDate = "2023-07-01",
                PricePerNight = 45,
                LocalAirports = new List<string> { "AGP" },
                NumberOfNights = 14
            };

            //Act
            List<Hotel> actual = Hotel.GetMatchingDate(arrivalDate);


            //Assert
            actual[1].Should().BeEquivalentTo(expected,
               options => options.ComparingByMembers<Hotel>());
        }

        [Test]
        public void ReturnsAListOfHotelsWithMatchingDuration()
        {
            //Arrange
            int duration = 7;
            int expected = 5;

            //Act
            List<Hotel> actual = Hotel.GetMatchingDuration(duration);


            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ReturnsAHotelWithMatchingDuration()
        {
            //Arrange
            int duration = 7;
            Hotel expected = new()
            {
                Id = 11,
                Name = "Parador De Malaga Gibralfaro",
                ArrivalDate = "2023-10-16",
                PricePerNight = 100,
                LocalAirports = new List<string> { "AGP" },
                NumberOfNights = 7
            };

            //Act
            List<Hotel> actual = Hotel.GetMatchingDuration(duration);


            //Assert
            actual[4].Should().BeEquivalentTo(expected,
               options => options.ComparingByMembers<Hotel>());
        }

        [Test]
        public void ReturnsBestValueHotel()
        {
            //Arrange
            string arrivalAirport = Airports.AGP.ToString();
            string arrivalDate = "2023-07-01";
            int duration = 7;
            int expected = 9;

            //Act
            Hotel actual = Hotel.GetBestValueHotel(arrivalAirport, arrivalDate, duration);


            //Assert
            actual.Id.Should().Be(9);
        }
    }
}