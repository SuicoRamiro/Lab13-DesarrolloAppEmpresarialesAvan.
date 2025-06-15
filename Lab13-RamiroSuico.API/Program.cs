using System.Reflection;
using Lab13_RamiroSuico.Domain.Interfaces;
using Lab13_RamiroSuico.Infrastructure.Context;
using Lab13_RamiroSuico.Infrastructure.Persistence;
using Lab13_RamiroSuico.Infrastructure.Persistence.Repositories;
using Lab13_RamiroSuico.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LinqexampleContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.Load("Lab13-RamiroSuico.Application"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IExcelReportService, ExcelReportService>();

var app = builder.Build();

// Redirigir raíz a Swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

// Swagger disponible en todos los entornos (opcional)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    c.RoutePrefix = "swagger";
});

// Middleware estándar
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Rutas
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
).WithStaticAssets();

app.Run();