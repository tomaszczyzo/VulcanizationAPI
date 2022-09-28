using VulcanizationAPI.Entities;
using VulcanizationAPI;
using Microsoft.OpenApi.Writers;
using System.Reflection;
using VulcanizationAPI.ControllerServices;
using NLog.Web;
using VulcanizationAPI.Middleware;
using VulcanizationAPI.Services;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using VulcanizationAPI.Models;
using VulcanizationAPI.Models.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Nlog Setup
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VulcanizationDbContext>();
builder.Services.AddScoped<VulcanizationSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IVulcanizationService, VulcanizationService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeMiddleware>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

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
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
