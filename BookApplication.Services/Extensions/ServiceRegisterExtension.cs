using BookApplication.Services.Service.BookCategoryServices;
using BookApplication.Services.Service.BookServices;
using BookApplication.Services.Service.RoleService;
using BookApplication.Services.Service.UserBookServices;
using BookApplication.Services.Service.UserServices;
using BookApplication.Services.Services.AdminService;
using BookApplication.Services.Services.AuthService;
using Microsoft.Extensions.DependencyInjection;

namespace BookApplication.Services.Extensions
{
    public static class ServiceRegisterExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserBookService, UserBookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
