# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["ekvip.CommandShell/ekvip.CommandShell.csproj", "ekvip.CommandShell/"]
RUN dotnet restore "./ekvip.CommandShell/ekvip.CommandShell.csproj"

# Copy everything else
COPY . .

# Build and publish the application
WORKDIR /src/ekvip.CommandShell
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS runtime
WORKDIR /app
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ekvip.CommandShell.dll"]
