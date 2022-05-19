using FlightStatus.Core.Models;

namespace FlightStatus.Services.Interfaces;

public interface IFlightService : IDisposable
{
    Task<List<Flight>> GetAll();
}