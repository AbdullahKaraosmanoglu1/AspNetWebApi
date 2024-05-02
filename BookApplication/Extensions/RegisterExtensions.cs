using AutoMapper;
using BookApplication.Services.NLog;
using BookApplication.WebApi.AutoMapper;

namespace BookApplication.WebApi.Extensions
{
    public static class RegisterExtensions
    {
        public static IServiceCollection AutoMapperExtension(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddAutoMapper(typeof(Program)); // AutoMapper'ı yapılandırma

            return services;
        }

        public static void ConfigureNLogService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
