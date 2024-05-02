using BookApplication.Data.Extensions;
using BookApplication.Services.Extensions;
using BookApplication.WebApi.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);


/*Below is the line of code written to create and display the nlog.config file of the NLog package.*/
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "nlog.config"));

/* Controllers And AddNewtonsoftJson */
builder.Services.AddControllers()
                .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* sqlConnection Extension */
builder.Services.RegisterSqlConnect(builder.Configuration);
/* Configure Repository Extension */
builder.Services.RegisterRepositories();
/* Configure Service Extension */
builder.Services.RegisterServices();
/* Configure AutoMapper Extension */
builder.Services.AutoMapperExtension();
/* Configure NLog Extension */
builder.Services.ConfigureNLogService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

