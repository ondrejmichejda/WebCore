using AspCoreBE.Context;
using AspCoreBE.Repositories;
using AspCoreBE.Repositories.Wrapper;
using AspCoreBE.WebCoreSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

IWebCoreSettings WebCoreSettings = configuration.GetSection("WebCoreSettings").Get<WebCoreSettings>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins().WithOrigins(WebCoreSettings.AllowedCorsDomains).AllowAnyHeader().AllowAnyMethod();
        });
});


// Add services to the container.
builder.Services.AddDbContext<WebCoreContext>(options => options.UseSqlServer(WebCoreSettings.DbConnectionString));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();