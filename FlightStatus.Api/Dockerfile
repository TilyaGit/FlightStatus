FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FlightStatus.Api/FlightStatus.Api.csproj", "FlightStatus.Api/"]
RUN dotnet restore "FlightStatus.Api/FlightStatus.Api.csproj"
COPY . .
WORKDIR "/src/FlightStatus.Api"
RUN dotnet build "FlightStatus.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlightStatus.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightStatus.Api.dll"]
