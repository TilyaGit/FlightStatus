using FlightStatus.Core.Models;

namespace FlightStatus.Infrastructure.Interfaces;

public interface IFlightRepository
{
    Task<List<Flight>> GetAll();
    Task AddFlight(Flight requestFlight);
    Task UpdateFlight(Flight requestFlight);
}