using System;
using Xunit;
using MobileFoodFacilitiesService;
using SODA;
using FoodTruckChallenge;
using Moq;
using System.Collections.Generic;
using FoodTruckChallenge.Models;
using System.Linq;

namespace MobileFoodService.Tests
{
    public class FoodTruckManagerTests
    {
        [Fact]
        public void FoodTruckManager_FiltersNearbyFoodTrucks()
        {
            //arrange
            var sampleData = new List<FoodTruck>()
            {
                new FoodTruck{ Latitude = 22.1, Longitude= 122.1, Status = "approved"},
                new FoodTruck{ Latitude = 22.111, Longitude= 122.111, Status = "approved"},
                new FoodTruck{ Latitude = 22.111222, Longitude= 122.111222, Status = "approved"},
                new FoodTruck{ Latitude = 22.5, Longitude= 122.5, Status = "approved"}
            };

            var foodTruckRepoMock = new Mock<IFoodTruckRepository>();
            foodTruckRepoMock.Setup(p => p.GetFoodTruckFacilities()).Returns(sampleData);

            //act
            var manager = new FoodTruckManager(foodTruckRepoMock.Object);
            
            var result = manager.GetFoodTrucksWithinArea(22.1, 122.1, 1);


            //assert
            Assert.NotEmpty(result);
            Assert.NotEqual(result.Count(), sampleData.Count());

        }
    }
}
