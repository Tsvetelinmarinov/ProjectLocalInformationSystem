/*
 * Entry point.
 */

using LocalInformationSystem.Data.DatabaseContext;

#region Application Building And IoC Container Configuration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BgDatabaseContext>();

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