# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the project files
COPY Api/Api.csproj ./Api/
COPY BissnessLayer/BissnessLayer.csproj ./BissnessLayer/
COPY DataLayer/DataLayer.csproj ./DataLayer/

# Restore dependencies
RUN dotnet restore Api/Api.csproj

# Copy the rest of the application
COPY . .

# Build the application
RUN dotnet publish Api/Api.csproj -c Release -o out

# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port that your API listens on
EXPOSE 80

# Set the entry point to run your application
ENTRYPOINT ["dotnet", "Api.dll"]