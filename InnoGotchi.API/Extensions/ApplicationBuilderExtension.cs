using InnoGotchi.API.Middlewares;

namespace InnoGotchi.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
