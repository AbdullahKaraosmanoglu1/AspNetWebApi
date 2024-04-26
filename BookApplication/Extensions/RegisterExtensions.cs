using BookApplication.Data.BookApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.WebApi.Extensions
{
    public static class RegisterExtensions
    {
        public static IServiceCollection RegisterSqlConnect(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookAppDataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlCon")));

            return services;
        }
    }
}
