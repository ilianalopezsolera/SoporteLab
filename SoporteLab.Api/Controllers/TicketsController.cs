// Controllers/TicketsController.cs
using Microsoft.AspNetCore.Mvc;
using SoporteLab.Api.Models;
using SoporteLab.Api.Repositories;

namespace SoporteLab.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketRepository _repo;

    private static readonly string[] PrioridadesValidas = ["Baja", "Media", "Alta", "Crítica"];
    private static readonly string[] EstadosValidos = ["Abierto", "En proceso", "Resuelto", "Cerrado"];

    public TicketsController(ITicketRepository repo)
    {
        _repo = repo;
    }

    // GET /api/tickets
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _repo.ObtenerTodosAsync());

    // GET /api/tickets/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _repo.ObtenerPorIdAsync(id);
        return ticket is null ? NotFound($"Ticket {id} no existe.") : Ok(ticket);
    }

    // GET /api/tickets/estado/{estado}
    [HttpGet("estado/{estado}")]
    public async Task<IActionResult> GetByEstado(string estado)
    {
        if (!EstadosValidos.Contains(estado))
            return BadRequest($"Estado inválido. Use: {string.Join(", ", EstadosValidos)}");

        return Ok(await _repo.ObtenerPorEstadoAsync(estado));
    }

    // GET /api/tickets/prioridad/{prioridad}
    [HttpGet("prioridad/{prioridad}")]
    public async Task<IActionResult> GetByPrioridad(string prioridad)
    {
        if (!PrioridadesValidas.Contains(prioridad))
            return BadRequest($"Prioridad inválida. Use: {string.Join(", ", PrioridadesValidas)}");

        return Ok(await _repo.ObtenerPorPrioridadAsync(prioridad));
    }

    // GET /api/tickets/abiertos
    [HttpGet("abiertos")]
    public async Task<IActionResult> GetAbiertos() =>
        Ok(await _repo.ObtenerAbiertosAsync());

    // POST /api/tickets
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Ticket ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.Titulo))
            return BadRequest("El título no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(ticket.Solicitante))
            return BadRequest("El solicitante no puede estar vacío.");

        if (!PrioridadesValidas.Contains(ticket.Prioridad))
            return BadRequest($"Prioridad inválida. Use: {string.Join(", ", PrioridadesValidas)}");

        if (!EstadosValidos.Contains(ticket.Estado))
            return BadRequest($"Estado inválido. Use: {string.Join(", ", EstadosValidos)}");

        ticket.FechaRegistro = DateTime.Now;
        var creado = await _repo.CrearAsync(ticket);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    // PUT /api/tickets/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Ticket ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.Titulo))
            return BadRequest("El título no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(ticket.Solicitante))
            return BadRequest("El solicitante no puede estar vacío.");

        if (!PrioridadesValidas.Contains(ticket.Prioridad))
            return BadRequest($"Prioridad inválida. Use: {string.Join(", ", PrioridadesValidas)}");

        if (!EstadosValidos.Contains(ticket.Estado))
            return BadRequest($"Estado inválido. Use: {string.Join(", ", EstadosValidos)}");

        var actualizado = await _repo.ActualizarAsync(id, ticket);
        return actualizado is null ? NotFound($"Ticket {id} no existe.") : Ok(actualizado);
    }

    // DELETE /api/tickets/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _repo.EliminarAsync(id);
        return eliminado ? NoContent() : NotFound($"Ticket {id} no existe.");
    }
}