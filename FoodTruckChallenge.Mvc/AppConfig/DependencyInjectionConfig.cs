using FoodTruckChallenge;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MobileFoodFacilitiesService;
using SODA;

namespace food_truck_challenge.AppConfig
{
    public class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            services.AddTransient<IFoodTruckRepository, FoodTruckRepository>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<IFacilitiesService, FacilitiesService>();
            services.AddTransient<IFoodTruckService, FoodTruckService>();
            services.AddTransient<FoodTruckManager>();

            services.Configure<MobileFacilitiesServiceConfig>(configuration.GetSection("MobileFacilitiesServiceConfig"));
            services.AddSingleton(container => container.GetService<IOptions<MobileFacilitiesServiceConfig>>()?.Value);

            services.AddSingleton(c =>
            {
                var serviceConfig = c.GetService<MobileFacilitiesServiceConfig>();
                return  new SodaClient(serviceConfig.ServiceBaseUrl, serviceConfig.ServiceAppAuthKey);
            });
        }
    }
}
