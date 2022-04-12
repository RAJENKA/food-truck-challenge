using FoodTruckChallenge.Models;
using Geolocation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FoodTruckChallenge
{
    public class FoodTruckManager
    {
        private IFoodTruckRepository _foodTruckRepository;
        private ILogger<FoodTruckManager> _logger;

        public FoodTruckManager(IFoodTruckRepository foodTruckRepository, ILogger<FoodTruckManager> logger)
        {
            _foodTruckRepository = foodTruckRepository;
            _logger = logger;
        }

        /// <summary>
        /// Find the food trucks withing a range defined by provided origin co-ordinates and defined radious
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="radiusInMiles"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Tuple<IEnumerable<PointBlockFoodTruck>, ErrorResult> GetFoodTrucksWithinArea(double lat, double lon, double radiusInMiles = 0.1, int take = 5)
        {
            try
            {
                CoordinateBoundaries boundaries = new CoordinateBoundaries(lat, lon, radiusInMiles);

                var allActiveFoodTrucks = GetFoodTrucksWithDistanceFromOrigin(lat, lon, boundaries.MinLatitude, boundaries.MaxLatitude, boundaries.MinLongitude, boundaries.MaxLongitude);

                var foodTrucksWithinRadius = allActiveFoodTrucks.Where(x => x.Distance <= radiusInMiles)
                  .OrderBy(x => x.Distance)
                  .Take(take);
                return new Tuple<IEnumerable<PointBlockFoodTruck>, ErrorResult>(foodTrucksWithinRadius, null);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to process the request.", ex);

                return new Tuple<IEnumerable<PointBlockFoodTruck>, ErrorResult>(null, new ErrorResult
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    Error = "Unable to process the request. Please try again or contact support."
                });
            }

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
