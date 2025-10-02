using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Eshop.Api.Data;
using Eshop.Api.Messaging;
using Eshop.Api.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<IStockUpdateQueue, StockUpdateQueue>();
builder.Services.AddHostedService<StockUpdateWorker>();
builder.Services.AddSingleton<StockUpdateProducer>();
builder.Services.AddHostedService<StockUpdateConsumer>();

// EF Core 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// RabbitMQ connection factory (singleton)
builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    var config = builder.Configuration.GetSection("RabbitMQ");
    return new ConnectionFactory
    {
        HostName = config["Host"],
        Port = int.Parse(config["Port"] ?? "5672"),
        UserName = config["UserName"],
        Password = config["Password"]
    };
});

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // v1, v2, ...
    options.SubstituteApiVersionInUrl = true;
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:5173",
                "https://red-glacier-095170803.1.azurestaticapps.net"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});



// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Eshop API",
        Version = "v1",
        Description = "REST API for managing products and categories in the e-shop (version 1).",
        Contact = new OpenApiContact
        {
            Name = "Matus Bohucky",
            Email = "mat.bohucky@gmail.com"
        }
    });

    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Eshop API",
        Version = "v2",
        Description = "REST API for managing products and categories in the e-shop (version 2 with pagination).",
        Contact = new OpenApiContact
        {
            Name = "Matus Bohucky",
            Email = "mat.bohucky@gmail.com"
        }
    });

    // XML comments
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowFrontend");


// apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Eshop API v2");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
