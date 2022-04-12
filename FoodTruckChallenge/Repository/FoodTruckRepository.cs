using FoodTruckChallenge.Extensions;
using FoodTruckChallenge.Models;
using Microsoft.Extensions.Logging;
using MobileFoodFacilitiesService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTruckChallenge
{
    public class FoodTruckRepository : IFoodTruckRepository
    {
        private const string FoodTruckCacheKey = "FoodTruckKey";
        //TBD Set this as Config
        private const int CacheExpirationInMin = 30;

        private ICacheService _cacheService;
        private IFoodTruckService _foodTruckService;
        private ILogger<FoodTruckRepository> _logger;

        public FoodTruckRepository(ICacheService cacheService, IFoodTruckService foodTruckService, ILogger<FoodTruckRepository> logger)
        {
            _cacheService = cacheService;
            _foodTruckService = foodTruckService;
            _logger = logger;
        }

        public IEnumerable<FoodTruck> GetFoodTruckFacilities()
        {
            return GetFoodTruckData().Where(ft => ft.Status.Equals("approved", StringComparison.CurrentCultureIgnoreCase));
        }

        private IEnumerable<FoodTruck> GetFoodTruckData()
        {
            try
            {
                return _cacheService.GetOrSet(FoodTruckCacheKey, GetDataFromPersistentStore, TimeSpan.FromMinutes(CacheExpirationInMin));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to retrieve the data for mobile facilities.", ex);

                throw;
            }
        }

        private IEnumerable<FoodTruck> GetDataFromPersistentStore()
        {
            return _foodTruckService.GetFoodTruckFacilities().Select(m => m.ToFoodTruck());
        }
    }
}
