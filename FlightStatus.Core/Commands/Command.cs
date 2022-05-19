using FlightStatus.Core.Events;

namespace FlightStatus.Core.Commands;

public abstract class Command : Message
{
    public DateTime Timestamp { get; private set; }

    public Command()
    {
        Timestamp = DateTime.Now;
    }

    public abstract bool IsValid();
}