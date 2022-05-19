using FlightStatus.Core.Models;
using FlightStatus.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightStatus.Infrastructure.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly ApiDbContext _apiDbContext;

    public FlightRepository(ApiDbContext apiDbContext)
    {
        _apiDbContext = apiDbContext;
    }

    public async Task<List<Flight>> GetAll()
    {
        return await _apiDbContext.Flights.OrderBy(x => x.Origin).ToListAsync();
    }

    public async Task AddFlight(Flight requestFlight)
    {
        await _apiDbContext.Flights.AddAsync(requestFlight);
        await _apiDbContext.SaveChangesAsync();
    }

    public async Task UpdateFlight(Flight requestStatus)
    {
        var flight = await _apiDbContext.Flights.Where(x => x.ID == requestStatus.ID).FirstAsync();

        flight.Status = requestStatus.Status;

        _apiDbContext.Flights.Update(flight);
        await _apiDbContext.SaveChangesAsync();
    }
}