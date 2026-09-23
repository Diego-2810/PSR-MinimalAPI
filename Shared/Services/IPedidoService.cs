using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para la capa de servicios de negocio de pedidos.
/// Aplica el principio de inversión de dependencias y desacopla la lógica de negocio del repositorio.
/// </summary>
public interface IPedidoService
{
    Task<Pedido> RegistrarPedidoAsync(Pedido pedido);
    Task<Pedido?> ConsultarPedidoPorIdAsync(int id);
    Task<IEnumerable<Pedido>> ListarPedidosAsync();
    Task<bool> CambiarEstadoPedidoAsync(int id, EstadoPedido nuevoEstado);
}
