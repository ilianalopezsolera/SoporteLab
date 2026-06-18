// Services/TicketApiService.cs
using System.Net.Http.Json;
using SoporteLab.Web.Models;

namespace SoporteLab.Web.Services;

public class TicketApiService
{
    private readonly HttpClient _http;

    public TicketApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Ticket>> ObtenerTodosAsync() =>
        await _http.GetFromJsonAsync<List<Ticket>>("api/tickets") ?? [];

    public async Task<Ticket?> ObtenerPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Ticket>($"api/tickets/{id}");

    public async Task<bool> CrearAsync(Ticket ticket)
    {
        var respuesta = await _http.PostAsJsonAsync("api/tickets", ticket);
        return respuesta.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarAsync(int id, Ticket ticket)
    {
        var respuesta = await _http.PutAsJsonAsync($"api/tickets/{id}", ticket);
        return respuesta.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var respuesta = await _http.DeleteAsync($"api/tickets/{id}");
        return respuesta.IsSuccessStatusCode;
    }
}