using FlightStatus.Core.Bus;
using FlightStatus.Core.Models;
using FlightStatus.Services.Commands.Flights;
using FlightStatus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightStatus.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightStatusController : ControllerBase
{
    private readonly ILogger<FlightStatusController> _logger;
    private readonly IFlightService _flightService;
    private readonly IMediatorHandler _mediator;

    public FlightStatusController(ILogger<FlightStatusController> logger, IFlightService flightService,
        IMediatorHandler mediator)
    {
        _logger = logger;
        _flightService = flightService;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/api/FlightStatus.Core.Models.Flight/getAll")]
    public async Task<List<Flight>> GetAll()
    {
        var data = await _flightService.GetAll();
        return data;
    }


    [HttpPost]
    [Route("/api/FlightStatus.Core.Models.Flight/addFlight")]
    public async Task<Flight> AddFlight([FromBody] Flight flight)
    {
        await _mediator.SendCommand(new AddFlightCommand() { Flight = flight });
        return flight;
    }

    [HttpPut]
    [Route("/api/FlightStatus.Core.Models.Flight/updateFlight")]
    public async Task<Flight> UpdateFlight([FromBody] Flight flight)
    {
        await _mediator.SendCommand(new UpdateFlightCommand() { Flight = flight });
        return flight;
    }
}