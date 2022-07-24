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
            Tuple<Flight, Hotel> actual  = test1.GetBestValueHoliday();

            //Assert
            actual.Should().NotBeNull();
        }
    }
}
