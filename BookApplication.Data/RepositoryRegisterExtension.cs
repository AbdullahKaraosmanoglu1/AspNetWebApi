using BookApplication.Data.Repository;
using BookApplication.Data.Repository.BookCategoryRepository;
using BookApplication.Data.Repository.BookRepository;
using BookApplication.Data.Repository.UserBookRepository;
using BookApplication.Data.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookApplication.Data
{
    public static class RepositoryRegisterExtension
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRespository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRespository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBookRepository, UserBookRepository>();

            return services;
        }
    }
}
