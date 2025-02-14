﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTruckChallenge.Models
{
    public class FoodTruck
    {
        public string LocationId { get; set; }

        public string FacilityType { get; set; }

        public string LocationDescription { get; set; }

        public string Address { get; set; }

        public string BlockLot { get; set; }

        public string Block { get; set; }

        public string Lot { get; set; }

        public string Permit { get; set; }

        public string Status { get; set; }

        public string FoodItems { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Schedule { get; set; }

        public string DaysHours { get; set; }

        public DateTime? Approved { get; set; }

        public DateTime? ExpirationDate { get; set; }

    }
}
