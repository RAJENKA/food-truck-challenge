using FoodTruckChallenge.Models;
using MobileFoodFacilitiesService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTruckChallenge.Extensions
{
    internal static class MobileFacilitiesExtension
    {
        public static FoodTruck ToFoodTruck(this MobileFacility mobileFacility)
        {
            if(mobileFacility == null)
            {
                return null;
            }

            return new FoodTruck()
            {
                Address = mobileFacility.Address,
                Approved = mobileFacility.Approved.ParseDate(),
                Block = mobileFacility.Block,
                BlockLot = mobileFacility.BlockLot,
                DaysHours = mobileFacility.DaysHours,
                ExpirationDate = mobileFacility.ExpirationDate.ParseDate(),
                FacilityType = mobileFacility.FacilityType,
                FoodItems = mobileFacility.FoodItems,
                Latitude = mobileFacility.Latitude,
                LocationDescription = mobileFacility.LocationDescription,
                LocationId = mobileFacility.LocationId,
                Longitude = mobileFacility.Longitude,
                Lot = mobileFacility.Lot,
                Permit = mobileFacility.Permit,
                Schedule = mobileFacility.Schedule,
                Status = mobileFacility.Status,
                X = mobileFacility.X,
                Y = mobileFacility.Y
            };
        }

        
    }
}
