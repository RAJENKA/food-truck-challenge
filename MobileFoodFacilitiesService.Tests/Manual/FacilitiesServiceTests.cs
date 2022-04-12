using System;
using Xunit;
using MobileFoodFacilitiesService;
using SODA;

namespace MobileFoodService.Tests
{
    public class FacilitiesServiceTests
    {
        [Fact]
        public void Test1()
        {
            var sodaClient = new SodaClient("data.sfgov.org", "");

            var mobileFoodService = new FacilitiesService(sodaClient);
            var result = mobileFoodService.GetFacilities();
        }
    }
}
