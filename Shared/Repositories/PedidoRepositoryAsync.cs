using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Repositories;

/// <summary>
/// Implementación asíncrona del repositorio de pedidos en memoria.
/// Demuestra el patrón Repository con programación asíncrona (async/await).
/// </summary>
public class PedidoRepositoryAsync : IPedidoRepositoryAsync
{
    private readonly ConcurrentDictionary<int, Pedido> _pedidos = new();
    private int _proximoId = 1;
    private readonly object _lock = new();

    public async Task<Pedido> CrearAsync(Pedido pedido)
    {
        // Simulamos I/O asíncrona realista (ej. base de datos)
        await Task.Delay(10);

        lock (_lock)
        {
            pedido.Id = _proximoId++;
            _pedidos[pedido.Id] = pedido;
            return pedido;
        }
    }

    public async Task<Pedido?> ObtenerPorIdAsync(int id)
    {
        await Task.Delay(5);
        _pedidos.TryGetValue(id, out var pedido);
        return pedido;
    }

    public async Task<IEnumerable<Pedido>> ObtenerTodosAsync()
    {
        await Task.Delay(5);
        return _pedidos.Values;
    }

    public async Task<bool> ActualizarEstadoAsync(int id, EstadoPedido nuevoEstado)
    {
        await Task.Delay(5);

        if (_pedidos.TryGetValue(id, out var pedido))
        {
            switch (nuevoEstado)
            {
                case EstadoPedido.EnCocina:
                    pedido.IniciarPreparacion();
                    break;
                case EstadoPedido.ListoParaReparto:
                    pedido.MarcarComoListo();
                    break;
                case EstadoPedido.EnReparto:
                    pedido.EnviarAReparto();
                    break;
                case EstadoPedido.Entregado:
                    pedido.Entregar();
                    break;
            }
            return true;
        }

        return false;
    }
}
