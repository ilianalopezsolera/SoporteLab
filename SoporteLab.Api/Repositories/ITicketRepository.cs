// Repositories/ITicketRepository.cs
using SoporteLab.Api.Models;

namespace SoporteLab.Api.Repositories;

public interface ITicketRepository
{
    Task<List<Ticket>> ObtenerTodosAsync();
    Task<Ticket?> ObtenerPorIdAsync(int id);
    Task<Ticket> CrearAsync(Ticket ticket);
    Task<Ticket?> ActualizarAsync(int id, Ticket ticket);
    Task<bool> EliminarAsync(int id);
    Task<List<Ticket>> ObtenerPorEstadoAsync(string estado);
    Task<List<Ticket>> ObtenerPorPrioridadAsync(string prioridad);
    Task<List<Ticket>> ObtenerAbiertosAsync();
}