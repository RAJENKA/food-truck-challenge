using FoodTruckChallenge.Extensions;
using FoodTruckChallenge.Models;
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

        public FoodTruckRepository(ICacheService cacheService, IFoodTruckService foodTruckService)
        {
            _cacheService = cacheService;
            _foodTruckService = foodTruckService;
        }

        public IEnumerable<FoodTruck> GetFoodTruckFacilities()
        {
            return GetFoodTruckData().Where(ft => ft.Status.Equals("approved", StringComparison.CurrentCultureIgnoreCase));
        }

        private IEnumerable<FoodTruck> GetFoodTruckData()
        {
            return _cacheService.GetOrSet(FoodTruckCacheKey, GetDataFromPersistentStore, TimeSpan.FromMinutes(CacheExpirationInMin));
        }

        private IEnumerable<FoodTruck> GetDataFromPersistentStore()
        {
            return _foodTruckService.GetFoodTruckFacilities().Select(m => m.ToFoodTruck());
        }
    }
}
