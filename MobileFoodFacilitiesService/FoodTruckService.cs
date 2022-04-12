using MobileFoodFacilitiesService.Model;
using SODA;
using System;
using System.Collections.Generic;

namespace MobileFoodFacilitiesService
{
    public class FoodTruckService : FacilitiesService, IFoodTruckService
    {
        private const string FaciltyType = "Truck";

        public FoodTruckService(SodaClient sodaClient): base(sodaClient)
        {
        }

        public IEnumerable<MobileFacility> GetFoodTruckFacilities()
        {
            return this.GetFacilities(FaciltyType);
        }
    }
}
