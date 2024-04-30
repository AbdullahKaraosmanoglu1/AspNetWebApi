using BookApplication.Services.Service.BookCategoryServices;
using BookApplication.Services.Service.BookServices;
using BookApplication.Services.Service.UserBookServices;
using BookApplication.Services.Service.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace BookApplication.Services
{
    public static class ServiceRegisterExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserBookSevice, UserBookSevice>();
            services.AddScoped<IUserSevice, UserSevice>();

            return services;
        }
    }
}
