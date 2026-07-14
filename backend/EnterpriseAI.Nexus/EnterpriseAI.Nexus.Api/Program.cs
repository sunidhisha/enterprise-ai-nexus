using EnterpriseAI.Nexus.Api.Data;
using EnterpriseAI.Nexus.Api.Interfaces;
using EnterpriseAI.Nexus.Api.Repositories;
using EnterpriseAI.Nexus.Api.Services;
using Microsoft.EntityFrameworkCore;
using EnterpriseAI.Nexus.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    // Register the OpenAPI JSON endpoint only once.
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Enterprise AI Nexus API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();