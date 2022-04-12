## Food truck finder based on user entered geo coordinates (Latitude, Longitude) for the cisty of San Franscisco
 - API returns the details of the food trucks, which are legal, approved and operation within specified radius.

 ## Repository content
 - MobileFoodFacilitiesService:  Service interface to fetch the food truck data from gov. open data source. Isolated from the client. Can be changed using Dependency Injection Config.
 - FoodTruckChallenge: Business logic to co-ordinate between the API layer and external services layer along with required geo calcuations. Also has the interfance as to data source via cache. Uses .NET Core InMemory cache to avoid reloading the data. 
 - FoodTruckChallenge.Mvc: API layer to expose the required endpoints for clients to consume.
 - MobileFoodService.Tests: Test cases


 ## Setup
 - To run the solution locally, edit the below configuration to provide the required AuthKey in App.Settings .
     "MobileFacilitiesServiceConfig": {
        "ServiceBaseUrl": "data.sfgov.org",
        "ServiceAppAuthKey": ""
      }
- Application Swagger UI is available at e.g. https://localhost:44306/swagger/index.html 

- Data from external source is cached for 30 mins

- Solution relies on client SDK implementation of SODA API endpoints https://www.nuget.org/packages/CSM.SodaDotNet/

## Reference 
Uses Geolocation nuget package for distance calculations and defining the block withing the given radius.
https://github.com/scottschluer/geolocation