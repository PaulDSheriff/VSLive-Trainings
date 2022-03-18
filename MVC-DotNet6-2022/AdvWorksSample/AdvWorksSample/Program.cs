using Microsoft.EntityFrameworkCore;
using AdvWorks.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Read in the connection string from the appSettings.json file
string connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Setup the AdvWorks DB Context
builder.Services.AddDbContext<AdventureWorksLTDbContext>(
  options => options.UseSqlServer(connString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
