using FlightStatus.Core.Models;
using FlightStatus.Infrastructure.Interfaces;
using FlightStatus.Services.Interfaces;

namespace FlightStatus.Services.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;
    private Task<List<Flight>> _getAll;

    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<List<Flight>> GetAll()
    {
        return await _flightRepository.GetAll();
    }
}