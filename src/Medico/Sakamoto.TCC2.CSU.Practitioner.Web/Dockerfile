FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Medico/Sakamoto.TCC2.CSU.Practitioner.Web/Sakamoto.TCC2.CSU.Practitioner.Web.csproj", "src/Medico/Sakamoto.TCC2.CSU.Practitioner.Web/"]
RUN dotnet restore "src/Medico/Sakamoto.TCC2.CSU.Practitioner.Web/Sakamoto.TCC2.CSU.Practitioner.Web.csproj"
COPY . .
WORKDIR "/src/src/Medico/Sakamoto.TCC2.CSU.Practitioner.Web"
RUN dotnet build "Sakamoto.TCC2.CSU.Practitioner.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sakamoto.TCC2.CSU.Practitioner.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sakamoto.TCC2.CSU.Practitioner.Web.dll"]