using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Repositories;
using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Capa de Servicio de Negocio.
/// Contiene las reglas de validación y coordina las operaciones con el repositorio asíncrono.
/// </summary>
public class PedidoService : IPedidoService
{
    private readonly IPedidoRepositoryAsync _pedidoRepository;

    public PedidoService(IPedidoRepositoryAsync pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Pedido> RegistrarPedidoAsync(Pedido pedido)
    {
        if (string.IsNullOrWhiteSpace(pedido.Cliente))
        {
            throw new ArgumentException("El nombre del cliente es obligatorio.");
        }

        if (pedido.Items == null || pedido.Items.Count == 0)
        {
            throw new InvalidOperationException("El pedido debe contener al menos un producto.");
        }

        // Delegar la persistencia asíncrona al repositorio
        return await _pedidoRepository.CrearAsync(pedido);
    }

    public async Task<Pedido?> ConsultarPedidoPorIdAsync(int id)
    {
        if (id <= 0) return null;
        return await _pedidoRepository.ObtenerPorIdAsync(id);
    }

    public async Task<IEnumerable<Pedido>> ListarPedidosAsync()
    {
        return await _pedidoRepository.ObtenerTodosAsync();
    }

    public async Task<bool> CambiarEstadoPedidoAsync(int id, EstadoPedido nuevoEstado)
    {
        var pedido = await _pedidoRepository.ObtenerPorIdAsync(id);
        if (pedido == null) return false;

        return await _pedidoRepository.ActualizarEstadoAsync(id, nuevoEstado);
    }
}
