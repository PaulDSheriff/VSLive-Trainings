// **********************************************
// Create a WebApplicationBuilder object
// to configure the how the ASP.NET service runs
// **********************************************
var builder = WebApplication.CreateBuilder(args);

// **********************************************
// Add and Configure Services
// **********************************************


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

// Enable Authorization Middleware
app.UseAuthorization();

// Enable the endpoints of Controller Action Methods
app.MapControllers();

// Run the Application
app.Run();
