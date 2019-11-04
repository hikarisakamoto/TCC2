FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/WEB/Sakamoto.TCC2.CSU.Web/Sakamoto.TCC2.CSU.Web.csproj", "src/WEB/Sakamoto.TCC2.CSU.Web/"]
RUN dotnet restore "src/WEB/Sakamoto.TCC2.CSU.Web/Sakamoto.TCC2.CSU.Web.csproj"
COPY . .
WORKDIR "/src/src/WEB/Sakamoto.TCC2.CSU.Web"
RUN dotnet build "Sakamoto.TCC2.CSU.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sakamoto.TCC2.CSU.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sakamoto.TCC2.CSU.Web.dll"]