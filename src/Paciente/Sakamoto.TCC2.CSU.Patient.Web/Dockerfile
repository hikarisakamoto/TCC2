FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Paciente/Sakamoto.TCC2.CSU.Patient.Web/Sakamoto.TCC2.CSU.Patient.Web.csproj", "src/Paciente/Sakamoto.TCC2.CSU.Patient.Web/"]
RUN dotnet restore "src/Paciente/Sakamoto.TCC2.CSU.Patient.Web/Sakamoto.TCC2.CSU.Patient.Web.csproj"
COPY . .
WORKDIR "/src/src/Paciente/Sakamoto.TCC2.CSU.Patient.Web"
RUN dotnet build "Sakamoto.TCC2.CSU.Patient.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sakamoto.TCC2.CSU.Patient.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sakamoto.TCC2.CSU.Patient.Web.dll"]