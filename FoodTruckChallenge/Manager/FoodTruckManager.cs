using FoodTruckChallenge.Models;
using Geolocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodTruckChallenge
{
    public class FoodTruckManager
    {
        private IFoodTruckRepository _foodTruckRepository;

        public FoodTruckManager(IFoodTruckRepository foodTruckRepository)
        {
            _foodTruckRepository = foodTruckRepository;
        }

        /// <summary>
        /// Find the food trucks withing a range defined by provided origin co-ordinates and defined radious
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public IEnumerable<PointBlockFoodTruck> GetFoodTrucksWithinArea(double lat, double lon, double radius = 0.1, int take =5)
        {
            CoordinateBoundaries boundaries = new CoordinateBoundaries(lat, lon, radius);

            var data = GetFoodTrucksWithDistanceFromOrigin(lat, lon, boundaries.MinLatitude, boundaries.MaxLatitude, boundaries.MinLongitude, boundaries.MaxLongitude);

            return data.Where(x => x.Distance <= radius)
              .OrderBy(x => x.Distance)
              .Take(take);
        }

        private IEnumerable<PointBlockFoodTruck> GetFoodTrucksWithDistanceFromOrigin(double lat, double lon, double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
        {

            //Reference https://github.com/scottschluer/geolocation
            //Based on the distance from the origin or provided co-ordinates
           return _foodTruckRepository.GetFoodTruckFacilities()
              .Where(x => x.Latitude >= minLatitude && x.Latitude <= maxLatitude)
              .Where(x => x.Longitude >= minLongitude && x.Longitude <= maxLongitude)
              .Select(result => new PointBlockFoodTruck
              {
                  FoodTruck = result,
                  Distance = GeoCalculator.GetDistance(lat, lon, result.Latitude, result.Longitude, 1),
                  Direction = GeoCalculator.GetDirection(lat, lon, result.Latitude, result.Longitude)
              });

        }
    }
}
