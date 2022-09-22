using VulcanizationAPI.Entities;
using VulcanizationAPI;
using Microsoft.OpenApi.Writers;
using System.Reflection;
using VulcanizationAPI.ControllerServices;
using NLog.Web;
using VulcanizationAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Nlog Setup
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VulcanizationDbContext>();
builder.Services.AddScoped<VulcanizationSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IVulcanizationService, VulcanizationService>();
builder.Services.AddScoped<ErrorHandlingMiddeware>();

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<VulcanizationSeeder>();

// Configure the HTTP request pipeline.
seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddeware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
