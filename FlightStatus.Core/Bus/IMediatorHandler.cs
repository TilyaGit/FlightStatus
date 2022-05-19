using FlightStatus.Core.Commands;

namespace FlightStatus.Core.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
}