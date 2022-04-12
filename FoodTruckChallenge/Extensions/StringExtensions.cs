using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTruckChallenge.Extensions
{
    internal static class StringExtensions
    {
        public static DateTime? ParseDate(this String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }

            return null;
        }

        public static bool? ParseBoolean(this String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (Boolean.TryParse(input, out bool result))
            {
                return result;
            }

            return null;
        }
    }
}
