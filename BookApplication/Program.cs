using BookApplication.Data;
using BookApplication.Services;
using BookApplication.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

/* Controllers And AddNewtonsoftJson */
builder.Services.AddControllers()
                .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* sqlConnection Extension */
builder.Services.RegisterSqlConnect(builder.Configuration);
/* Configure Repository Extension */
builder.Services.RegisterRepository();
/* Configure Service Extension */
builder.Services.RegisterServices();

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
