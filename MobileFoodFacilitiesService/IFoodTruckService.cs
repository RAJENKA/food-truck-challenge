using MobileFoodFacilitiesService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFoodFacilitiesService
{
    public interface IFoodTruckService : IFacilitiesService
    {
        IEnumerable<MobileFacility> GetFoodTruckFacilities();
    }
}
