FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Event.Store/Sakamoto.TCC2.CSU.EventStore.Application/Sakamoto.TCC2.CSU.EventStore.Application.csproj", "src/Event.Store/Sakamoto.TCC2.CSU.EventStore.Application/"]
RUN dotnet restore "src/Event.Store/Sakamoto.TCC2.CSU.EventStore.Application/Sakamoto.TCC2.CSU.EventStore.Application.csproj"
COPY . .
WORKDIR "/src/src/Event.Store/Sakamoto.TCC2.CSU.EventStore.Application"
RUN dotnet build "Sakamoto.TCC2.CSU.EventStore.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sakamoto.TCC2.CSU.EventStore.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sakamoto.TCC2.CSU.EventStore.Application.dll"]