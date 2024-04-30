using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Repository;
using BookApplication.Data.Repository.BookCategoryRepository;
using BookApplication.Data.Repository.BookRepository;
using BookApplication.Data.Repository.UserBookRepository;
using BookApplication.Data.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApplication.Data.Extensions
{
    public static class RepositoryRegisterExtension
    {
        public static IServiceCollection RegisterSqlConnect(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookAppDataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlCon")));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBookRepository, UserBookRepository>();

            return services;
        }
    }
}
