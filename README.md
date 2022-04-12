## Food truck finder based on user entered geo coordinates (Latitude, Longitude) for the city of San Franscisco
 - API returns the details of the food trucks, which are legal, approved and operational within specified radius.

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


## Behind the scenes
- When I started reading through the problem, there were lot of questions on my mind to tackle something that I never did mainly around the locations data. But at the same time it seemed achievable in given time frame. Few steps I took,
1. Quickly learned about the Food Truck data API and their documentation. The API response content was overwhelming to write a parser, so I was looking for some client SDK that can help. While going throuhg their Developer documentation I found about the access strategy as well as the available SDK. This was a breather in time crunch situation.
2. Secondly, I was looking to explore around how the location data is interpreted and consumed. I was focused on searching the solution which can give me long, lat and radius based search. I came across the Scott Schluer's solution for .NET core apps which solves this problem.
3. Now, there were lot of thoughts around how do I approach this solution. Just the API/CLI/WEB or a Console app, all this was on the table but to focus on problem I sticked with the API first strategy and kep client side as an option if time permits since swagger api was an option with Web API.
