using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Backend.Repositories;

/// <summary>
/// Interfaz del Repositorio Asíncrono de Pedidos.
/// Define el contrato de acceso a datos utilizando programación asíncrona (Task<T>).
/// </summary>
public interface IPedidoRepositoryAsync
{
    Task<Pedido> CrearAsync(Pedido pedido);
    Task<Pedido?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Pedido>> ObtenerTodosAsync();
    Task<bool> ActualizarEstadoAsync(int id, EstadoPedido nuevoEstado);
}
