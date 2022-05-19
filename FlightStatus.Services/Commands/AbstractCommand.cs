using FlightStatus.Core.Commands;

namespace FlightStatus.Services.Commands;

public abstract class AbstractCommand : Command
{
    public Guid Id { get; protected set; }
}