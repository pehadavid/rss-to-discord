FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RTD/RTD.csproj", "RTD/"]
RUN dotnet restore "RTD/RTD.csproj"
COPY . .
WORKDIR "/src/RTD"
RUN dotnet build "RTD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RTD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RTD.dll"]
