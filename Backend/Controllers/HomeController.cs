using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers;

/// <summary>
/// Controlador MVC principal encargado de gestionar la Landing Page de la Pizzería.
/// Cumple con el patrón MVC heredando de la clase Controller de ASP.NET Core.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Acción principal que sirve la Landing Page artesanal (Index.cshtml).
    /// </summary>
    /// <returns>Devuelve explícitamente la vista principal.</returns>
    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Navegando a la Landing Page principal de la Pizzería PSR.");
        return View();
    }

    /// <summary>
    /// Vista secundaria opcional para políticas / privacidad.
    /// </summary>
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }
}
