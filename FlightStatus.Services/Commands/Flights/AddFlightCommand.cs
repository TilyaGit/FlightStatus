﻿using FlightStatus.Core.Models;

namespace FlightStatus.Services.Commands.Flights;

public class AddFlightCommand : AbstractCommand
{
    public Flight Flight { get; set; }

    public override bool IsValid()
    {
        return true;
    }
}