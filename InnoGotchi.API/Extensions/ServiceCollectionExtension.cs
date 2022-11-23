using FluentValidation.AspNetCore;
using InnoGotchi.API.Attributes;
using InnoGotchi.API.Logging;
using InnoGotchi.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InnoGotchi.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void AddCustomExceptionHandler(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvcCore();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateViewModelStateAttribute));
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
        }
    }
}
