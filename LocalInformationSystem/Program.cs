/*
 * Entry point.
 */

using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Services.BusinessServices;
using LocalInformationSystem.Services.Mappers;
using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.Mappers;

using Microsoft.EntityFrameworkCore;

#region Application Building And IoC Container Configuration

var builder = WebApplication.CreateBuilder(args);

// Controllers and views services.
builder.Services.AddControllersWithViews();

// DbContext and repository services.
builder.Services.AddDbContext<BgDatabaseContext>((dbContextOptionsBuilder) =>
{
    dbContextOptionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        (sqlServerOptBuilder) =>
        {
            sqlServerOptBuilder.UseParameterizedCollectionMode(
                ParameterTranslationMode.MultipleParameters
            );

            // For future integration of new technologies like SqlVector etc...
            sqlServerOptBuilder.UseCompatibilityLevel(170);
        }
    );
});
builder.Services.AddScoped<IRepository, Repository>();

// Services(Service Layer).
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<IMountainsService, MountainsService>();
builder.Services.AddScoped<IRiversService, RiversService>();

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
else if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();

#endregion
#region Startup

// Ensure database is created and migrations are applied at startup.
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<BgDatabaseContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        // If migration fails during startup we at least write to console. The app will still attempt to start.
        Console.WriteLine($"Database migration failed: {ex.Message}");
    }
}

app.Run();

#endregion