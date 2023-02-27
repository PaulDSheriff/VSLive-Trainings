using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Serilog;
using Serilog.Events;

// **********************************************
// Create a WebApplicationBuilder object
// to configure the how the ASP.NET service runs
// **********************************************
var builder = WebApplication.CreateBuilder(args);

// **********************************************
// Add and Configure Services
// **********************************************
builder.Services.AddSingleton<AdvWorksAPIDefaults, AdvWorksAPIDefaults>();

// Add and Configure Repository Classes
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

// Configure logging to Console & File using Serilog
builder.Host.UseSerilog((ctx, lc) =>
{
  // Log to Console
  lc.WriteTo.Console();
  // Log to Rolling File
  lc.WriteTo.File("Logs/InfoLog-.txt",
   rollingInterval: RollingInterval.Day,
   restrictedToMinimumLevel: LogEventLevel.Information);
  // Log Errors to Rolling File
  lc.WriteTo.File("Logs/ErrorLog-.txt",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Error);
});

// Configure ASP.NET to use the Controller model
builder.Services.AddControllers();

// Configure Open API (Swagger)
// More Info: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// **********************************************
// After adding and configuring services
// Create an instance of a WebApplication object
// **********************************************
var app = builder.Build();

// **********************************************
// Configure the HTTP Request Pipeline
// **********************************************
if (app.Environment.IsDevelopment()) {
  // When in Development mode
  // Enable the Open API (Swagger) page
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Enable Exception Handling Middleware
if (app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/DevelopmentError");
}
else {
  app.UseExceptionHandler("/ProductionError");
}

// Handle status code errors in the range 400-599
app.UseStatusCodePagesWithReExecute("/StatusCodeHandler/{0}");

// Enable Authorization Middleware
app.UseAuthorization();

// Enable the endpoints of Controller Action Methods
app.MapControllers();

// Run the Application
app.Run();
