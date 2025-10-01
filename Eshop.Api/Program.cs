using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Eshop.Api.Data;
using Eshop.Api.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<IStockUpdateQueue, StockUpdateQueue>();
builder.Services.AddHostedService<StockUpdateWorker>();

// EF Core 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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
