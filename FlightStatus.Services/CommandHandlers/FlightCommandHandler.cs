using FlightStatus.Infrastructure.Interfaces;
using FlightStatus.Services.Commands.Flights;
using MediatR;

namespace FlightStatus.Services.CommandHandlers;

public class FlightCommandHandler : CommandHandler, IRequestHandler<AddFlightCommand, bool>,
    IRequestHandler<UpdateFlightCommand, bool>
{
    private readonly IFlightRepository _flightRepository;

    public FlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<bool> Handle(AddFlightCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            return false;
        }

        await _flightRepository.AddFlight(request.Flight);
        return true;
    }

    public async Task<bool> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            return false;
        }

        await _flightRepository.UpdateFlight(request.Flight);
        return true;
    }
}