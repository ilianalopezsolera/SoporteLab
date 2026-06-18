// Models/Ticket.cs
namespace SoporteLab.Api.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;  // Hardware, Software, Red, Acceso, Otro
    public string Prioridad { get; set; } = string.Empty;  // Baja, Media, Alta, Crítica
    public string Estado { get; set; } = "Abierto";        // Abierto, En proceso, Resuelto, Cerrado
    public string Solicitante { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}