using EveryMatrix.Application.Interfaces;
using EveryMatrix.Application.Repositories;
using EveryMatrix.Application.Services;
using EveryMatrix.Infrastructure.Repositories;
using EveryMatrixApp.Infrastructure.Data;
using EveryMatrixApp.Presentation.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMongoDB(
    mongoDBSettings.AtlasURI,
    mongoDBSettings.DatabaseName
    ));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
