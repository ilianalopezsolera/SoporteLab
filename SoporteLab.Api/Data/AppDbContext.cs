// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using SoporteLab.Api.Models;

namespace SoporteLab.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets => Set<Ticket>();
}