using InnoGotchi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InnoGotchi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(s => s.UseSqlServer(connectionString));
        }
    }
}
