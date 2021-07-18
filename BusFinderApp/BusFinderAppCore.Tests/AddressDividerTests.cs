using BusFinderAppCore.Control;
using BusFinderAppCore.Models;
using System.Linq;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace BusFinderAppCore.Tests
{
    public class AddressDividerTests
    {
        [Fact]
        public void GivenSchedule_WhenAddressDivider_Divide_ThenStreetTownAndCountryIsReturned()
        {
            // ------------ ARRANGE 

            // var wierszZBazyDanych = "cos z bazy Danych"; 

            var scheduleWarszawa = new ScheduleForStation()
            {
                schedule = new Schedule(),
                station = new Station() { default_address = new DefaultAddress() { full_address = "Aleje Jerozolimskie 144, 02-303 Warszawa, Polska" } }
            };
            var testScheduleList = new List<ScheduleForStation>()
            {
                scheduleWarszawa
            };

            //dont do it - the test should be independent, not reading any data from file, or a database.
            //var schedule = JSON.LoadJsonFiles<ScheduleForStation>("Data");

            // ------------ ACT
            var result = AddressDivider.Divider(testScheduleList);

            // ------------ ASSERT
            Assert.NotNull(result); //xUNIT assertion
            result.Should().HaveCount(1); //Fluent assertion
            result.FirstOrDefault().station.default_address.Street.Should().Be("Aleje Jerozolimskie 144"); //Fluent assertion

            Assert.Equal("02-303 Warszawa", result.FirstOrDefault().station.default_address.Town); //xUNIT assertion
            Assert.Equal("Polska", result.FirstOrDefault().station.default_address.Country); //xUNIT assertion
            result.FirstOrDefault().station.default_address.Country.Should().Be("Polska"); //Fluent assertion
        }

        //Doesnt make sense to test substract operator (-), or any other Microsoft (.Net) provided function.
        [Fact]
        public void Adding3To5Gives8()
        {
            int x = 3;
            int y = 5;

            var sum = x - y;

            Assert.Equal(-2, sum);
        }
    }
}
