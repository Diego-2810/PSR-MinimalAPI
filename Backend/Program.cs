using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Backend.Repositories;
using Backend.Services;
using Backend.Sockets;
using Backend.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de controladores y vistas MVC
builder.Services.AddControllersWithViews();

// 2. Generador del documento técnico (OpenAPI / Scalar)
builder.Services.AddOpenApi(); 

// 3. Registro de repositorios y servicios de negocio de forma 100% asíncrona
builder.Services.AddSingleton<IPedidoRepositoryAsync, PedidoRepositoryAsync>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// 4. Registro de servicio de Sockets TCP para Cocina y Reparto
builder.Services.AddSingleton<SocketServerService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<SocketServerService>());

var app = builder.Build();

// 5. Servir archivos estáticos (wwwroot/css/landing.css)
app.UseStaticFiles();

app.UseRouting();

// 6. Endpoints de la interfaz gráfica OpenAPI / Scalar
app.MapOpenApi(); 
app.MapScalarApiReference(); 

// 7. Mapear endpoints de la Minimal API y ruteo predeterminado MVC (Home/Index)
app.MapPedidoEndpoints();
app.MapDefaultControllerRoute(); // Apunta a HomeController.Index por defecto

app.Run();