using System.ComponentModel.DataAnnotations;

namespace FlightStatus.Services.CommandHandlers;

public class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler() => this.ValidationResult = new ValidationResult(null);

    protected void AddError(string msg) => this.ValidationResult.ErrorMessage += msg;
}