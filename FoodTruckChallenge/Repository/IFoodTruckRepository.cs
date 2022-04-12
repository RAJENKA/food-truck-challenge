using FoodTruckChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTruckChallenge
{
    public interface IFoodTruckRepository
    {
        IEnumerable<FoodTruck> GetFoodTruckFacilities();
    }
}
