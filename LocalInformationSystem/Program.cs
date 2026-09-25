/*
 * Entry point.
 */

using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Services.BusinessServices;
using LocalInformationSystem.Services.Mappers;
using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.Mappers;

#region Application Building And IoC Container Configuration

var builder = WebApplication.CreateBuilder(args);

// Controllers and views services.
builder.Services.AddControllersWithViews();

// DbContext and repository services.
builder.Services.AddDbContext<BgDatabaseContext>();
builder.Services.AddScoped<IRepository, Repository>();

// Services(Service Layer).
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();

// AutoMapper services.
builder.Services.AddAutoMapper(
    (config) => config.AddMaps(
        typeof(DTOAutoMapper), typeof(ViewModelAutoMapper)
    )
);

// Construct the application.
var app = builder.Build();

#endregion
#region HTTP Request Pipe Line Configuration

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();

#endregion
#region Startup

app.Run();

#endregion