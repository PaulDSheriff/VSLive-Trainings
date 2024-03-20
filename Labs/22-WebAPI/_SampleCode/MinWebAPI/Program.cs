using AdventureWorks.MinWebAPI;
using AdventureWorks.MinWebAPI.ExtensionClasses;
using Common.Library.Web;

// **********************************************
// Create a WebApplicationBuilder object
// to configure the how the ASP.NET service runs
// **********************************************
var builder = WebApplication.CreateBuilder(args);

// **********************************************
// Add and Configure Services
// **********************************************
// Add & Configure Global Application Settings
AdventureWorksAppSettings config = builder.ConfigureGlobalSettings();

// Add & Configure Database Context
builder.Services.ConfigureDataStore(
  builder.Configuration.GetConnectionString("DefaultConnection"));

// Add & Configure Repository Classes
builder.Services.AddRepositoryClasses();

// Add & Configure View Model Classes
builder.Services.AddViewModelClasses();

// Add "Router" classes as a service
builder.Services.AddRouterClasses();

// Add & Configure Open API (Swagger)
builder.Services.ConfigureOpenAPI();

// **********************************************
// After adding and configuring services
// Create an instance of a WebApplication object
// **********************************************
var app = builder.Build();

// **********************************************
// Configure the HTTP Request Pipeline
// **********************************************
if (app.Environment.IsDevelopment()) {
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

//*********************************************
// Map Minimal API Endpoints by
// Adding Routes from All Router Classes
// Run the Application
//*********************************************
using (var scope = app.Services.CreateScope()) {
  var services = scope.ServiceProvider.GetServices<RouterBase>();
  // Loop through each RouterBase class
  foreach (var item in services) {
    // Invoke the AddRoutes() method to add the routes
    item.AddRoutes(app);
  }

  // Run the Application
  app.Run();
}
