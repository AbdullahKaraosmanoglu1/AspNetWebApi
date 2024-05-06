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

builder.Services.AddSwaggerGen();/*Added*/

/* sqlConnection Extension */
builder.Services.RegisterSqlConnect(builder.Configuration);
/* Configure Repository Extension */
builder.Services.RegisterRepositories();
/* Configure Service Extension */
builder.Services.RegisterServices();
/* Configure AutoMapper Extension */
builder.Services.AutoMapperExtension();
/* Configure NLog Extension */
builder.Services.ConfigureNLogServiceExtension();
/*Configure JWT Token Extension*/
builder.Services.ConfigureJwtBearerTokenExtension();
builder.Services.AddCustomAuthorization();
builder.Services.AddJwtAuthenticationExtension(builder.Configuration);
/*Configure CORS-Policy Extension*/
var allowOrigin = "AllowOrigin";
builder.Services.AddCorsPolicyExtension(allowOrigin);

builder.Services.AddAuthorization();/*Added*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowOrigin);/*Added*/

app.UseHttpsRedirection();

app.UseAuthentication();/*Added*/
app.UseAuthorization();


app.MapControllers();

app.Run();

