using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Services;
using Shared.Models;

namespace Backend.Controllers;

/// <summary>
/// Controlador MVC principal encargado de gestionar la Landing Page y visualización de la Pizzería.
/// Cumple estrictamente con la arquitectura N-Capas comunicándose EXCLUSIVAMENTE con IPedidoService.
/// Todas sus acciones utilizan programación asíncrona (Task<IActionResult>).
/// </summary>
public class HomeController : Controller
{
    private readonly IPedidoService _pedidoService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IPedidoService pedidoService, ILogger<HomeController> logger)
    {
        _pedidoService = pedidoService;
        _logger = logger;
    }

    /// <summary>
    /// Acción principal asíncrona que sirve la Landing Page principal (Index.cshtml) con datos de pedidos.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Navegando a la Landing Page principal de la Pizzería PSR.");
        var pedidos = await _pedidoService.ListarPedidosAsync();
        return View(pedidos);
    }

    /// <summary>
    /// Acción de seguimiento asíncrona para consultar el estado de pedidos mediante IPedidoService.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Seguimiento(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            var pedido = await _pedidoService.ConsultarPedidoPorIdAsync(id.Value);
            ViewData["PedidoConsultado"] = pedido;
        }

        var pedidos = await _pedidoService.ListarPedidosAsync();
        return View(pedidos);
    }

    /// <summary>
    /// Vista de información secundaria / privacidad.
    /// </summary>
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }
}

