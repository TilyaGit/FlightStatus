using FlightStatus.Core.Bus;
using FlightStatus.Infrastructure;
using FlightStatus.Infrastructure.Interfaces;
using FlightStatus.Infrastructure.Repository;
using FlightStatus.Services.CommandHandlers;
using FlightStatus.Services.Commands.Flights;
using FlightStatus.Services.Interfaces;
using FlightStatus.Services.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddScoped<IMediatorHandler, InMemoryBus>();

builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

builder.Services.AddScoped<IRequestHandler<AddFlightCommand, bool>, FlightCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateFlightCommand, bool>, FlightCommandHandler>();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("FlightDB"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();