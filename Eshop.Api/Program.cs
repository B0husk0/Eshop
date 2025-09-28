using Eshop.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Add EF Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
   
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Eshop API",
        Version = "v1",
        Description = "REST API for managing products and categories in the e-shop.",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "you@example.com"
        }
    });

    
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
    c.RoutePrefix = "swagger"; 
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
