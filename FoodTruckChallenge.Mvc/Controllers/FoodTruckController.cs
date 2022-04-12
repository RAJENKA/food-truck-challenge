using FoodTruckChallenge;
using FoodTruckChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace food_truck_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodTruckController : ControllerBase
    {
        private IFoodTruckRepository _foodTruckRepository;
        private FoodTruckManager _foodTruckManager;

        public FoodTruckController(IFoodTruckRepository foodTruckRepository, FoodTruckManager foodTruckManager)
        {
            _foodTruckRepository = foodTruckRepository;
            _foodTruckManager = foodTruckManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task = await Task.Run(() =>
            {
                return _foodTruckRepository.GetFoodTruckFacilities();
            });

            return Ok(task);
        }

        [HttpGet]
        [Route("location")]
        [ProducesResponseType(typeof(IEnumerable<PointBlockFoodTruck>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(double? latitude, double? longitude, double? radiusInMiles)
        {
            //Add Validator for legit lat/long values
            if (latitude == null || longitude == null || radiusInMiles == null)
            {
                return BadRequest("Invalid input");
            }


            var result = await Task.Run(() =>
            {
                return _foodTruckManager.GetFoodTrucksWithinArea(latitude.Value, longitude.Value, radiusInMiles.Value);
            });

            return result.Item2 != null ? StatusCode(StatusCodes.Status500InternalServerError, result.Item2) : Ok(result.Item1);
        }
    }
}
