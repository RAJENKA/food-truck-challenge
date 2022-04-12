using MobileFoodFacilitiesService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFoodFacilitiesService
{
    public interface IFacilitiesService
    {
        IEnumerable<MobileFacility> GetFacilities();

        IEnumerable<MobileFacility> GetFacilities(string facilityType);

    }
}
