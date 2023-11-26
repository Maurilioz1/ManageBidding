using Microsoft.EntityFrameworkCore;
using ManageBidding.IoC;
using ManageBidding.MVC.Configuration;
using ManageBidding.Data.EntityFramework.Context;
using ManageBidding.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<ManageBiddingContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
builder.Services.AddMvcConfiguration();
DependencyInjection.RegisterServices(builder.Services);

var app = builder.Build();

IWebHostEnvironment env = app.Environment;
IConfiguration config = app.Configuration;

var builderConfig = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builderConfig.AddUserSecrets<Program>();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

config = builderConfig.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
