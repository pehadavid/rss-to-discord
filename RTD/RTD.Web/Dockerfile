FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RTD.Web/RTD.Web.csproj", "RTD.Web/"]
RUN dotnet restore "RTD.Web/RTD.Web.csproj"
COPY . .
WORKDIR "/src/RTD.Web"
RUN dotnet build "RTD.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -r linux-x64 -p:PublishReadyToRun=true -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RTD.Web.dll"]
