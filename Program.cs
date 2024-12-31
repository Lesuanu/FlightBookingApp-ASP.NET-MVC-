using FlightBookingApp.Infrastructure;
using FlightBookingApp.Interface;
using FlightBookingApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlightBookingApp.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();

builder.Services.AddDbContext<FlightBookingContext>(options =>
                                options.UseSqlServer(builder.Configuration.GetConnectionString("FlightConnectionString"),
                                b => b.MigrationsAssembly("FlightBookingApp")));


builder.Services.AddIdentity<FlightIdentityUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<FlightBookingContext>()
    .AddDefaultUI();
//.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
