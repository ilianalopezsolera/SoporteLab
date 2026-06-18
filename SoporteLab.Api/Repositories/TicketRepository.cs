// Repositories/TicketRepository.cs
using Microsoft.EntityFrameworkCore;
using SoporteLab.Api.Data;
using SoporteLab.Api.Models;

namespace SoporteLab.Api.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> ObtenerTodosAsync() =>
        await _context.Tickets.ToListAsync();

    public async Task<Ticket?> ObtenerPorIdAsync(int id) =>
        await _context.Tickets.FindAsync(id);

    public async Task<Ticket> CrearAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket?> ActualizarAsync(int id, Ticket datos)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket is null) return null;

        ticket.Titulo = datos.Titulo;
        ticket.Descripcion = datos.Descripcion;
        ticket.Categoria = datos.Categoria;
        ticket.Prioridad = datos.Prioridad;
        ticket.Estado = datos.Estado;
        ticket.Solicitante = datos.Solicitante;

        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket is null) return false;

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Ticket>> ObtenerPorEstadoAsync(string estado) =>
        await _context.Tickets.Where(t => t.Estado == estado).ToListAsync();

    public async Task<List<Ticket>> ObtenerPorPrioridadAsync(string prioridad) =>
        await _context.Tickets.Where(t => t.Prioridad == prioridad).ToListAsync();

    public async Task<List<Ticket>> ObtenerAbiertosAsync() =>
        await _context.Tickets
            .Where(t => t.Estado == "Abierto" || t.Estado == "En proceso")
            .ToListAsync();
}