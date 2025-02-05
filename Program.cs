using HotelBookingAPI.Data;
using HotelBookingAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
var configuration = builder.Configuration;

// Retrieve connection string from configuration
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Add services to the container

// Register Entity Framework Core with SQL Server as the database provider
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register application services for dependency injection
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Register controllers for handling HTTP requests
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Fixes circular references
        options.JsonSerializerOptions.WriteIndented = true; // Makes JSON output readable
    });

// Enable OpenAPI (Swagger) for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline

// Enable Swagger only in development mode for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure the database is up-to-date with the latest migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    dbContext.Database.Migrate(); // Apply any pending migrations    
}

// Enable HTTPS redirection to enforce secure connections
app.UseHttpsRedirection();

// Enable authorization middleware (not used currently but kept for future authentication needs)
app.UseAuthorization();

// Map controllers to handle API routes
app.MapControllers();

// Run the application
app.Run();