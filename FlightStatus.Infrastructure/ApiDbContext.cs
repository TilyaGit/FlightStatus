using FlightStatus.Core;
using FlightStatus.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightStatus.Infrastructure;

public class ApiDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
    
}