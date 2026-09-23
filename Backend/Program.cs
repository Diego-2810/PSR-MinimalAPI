using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;
using Shared.Services;
using Backend.Sockets;
using Backend.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Generador del documento técnico (OpenAPI / Scalar)
builder.Services.AddOpenApi(); 

// 2. Registro de repositorios y servicios de negocio de forma 100% asíncrona (Desde Shared)
builder.Services.AddSingleton<IPedidoRepositoryAsync, PedidoRepositoryAsync>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// 3. Registro de servicio de Sockets TCP para Cocina y Reparto
builder.Services.AddSingleton<SocketServerService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<SocketServerService>());

var app = builder.Build();

// 4. Endpoints de la interfaz gráfica OpenAPI / Scalar
app.MapOpenApi(); 
app.MapScalarApiReference(); 

// 5. Mapear endpoints de la Minimal API
app.MapPedidoEndpoints();

app.Run();
