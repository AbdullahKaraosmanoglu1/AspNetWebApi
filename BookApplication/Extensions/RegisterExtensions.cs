using AutoMapper;
using BookApplication.Services.NLog;
using BookApplication.WebApi.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


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

            services.AddAutoMapper(typeof(Program));

            return services;
        }

        public static void ConfigureNLogServiceExtension(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }

        public static void AddCorsPolicyExtension(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod());
            });
        }

        public static CorsPolicy GetCorsPolicyExtension(this IApplicationBuilder app, string policyName)
        {
            var corsPolicyProvider = app.ApplicationServices.GetRequiredService<ICorsPolicyProvider>();
            return corsPolicyProvider.GetPolicyAsync(null, policyName).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static void AddJwtAuthenticationExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            RequireExpirationTime = true,
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero,
                            ValidIssuer = configuration["JWT:Issuer"],
                            ValidAudience = configuration["JWT:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"] ?? string.Empty))
                        };
                    });
        }

        public static void ConfigureJwtBearerTokenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Üye", policy => policy.RequireRole("Üye"));
                options.AddPolicy("Satıcı", policy => policy.RequireRole("Satıcı"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });
        }
    }
}
