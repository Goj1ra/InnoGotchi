using InnoGotchi.Application.Services.Implementations;
using InnoGotchi.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InnoGotchi.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IFarmService, FarmService>();
            serviceCollection.AddScoped<IPetService, PetService>();
        }
    }
}
