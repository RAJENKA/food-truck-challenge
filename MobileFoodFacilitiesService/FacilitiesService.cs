using MobileFoodFacilitiesService.Model;
using SODA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileFoodFacilitiesService
{
    public class FacilitiesService : IFacilitiesService
    {
        private SodaClient _sodaClient;

        public FacilitiesService(SodaClient sodaClient)
        {
            _sodaClient = sodaClient;
        }

        public IEnumerable<MobileFacility> GetFacilities()
        {

            //read metadata of a dataset using the resource identifier (Socrata 4x4)
            var metadata = _sodaClient.GetMetadata("rqzj-sfat");
            Console.WriteLine("{0} has {1} views.", metadata.Name, metadata.ViewsCount);

            //of course, a custom type can be used as long as it is JSON serializable
            var dataset2 = _sodaClient.GetResource<MobileFacility>("rqzj-sfat");

            return dataset2.GetRows();

        }

        public IEnumerable<MobileFacility> GetFacilities(string facilityType)
        {
            //This can also be done using the filters on the API.
            return GetFacilities().Where(f => !string.IsNullOrEmpty(f.FacilityType) && f.FacilityType.Equals(facilityType, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
