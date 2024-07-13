# Use the official .NET Core runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Create a working directory within the container
WORKDIR /app

# Expose port 80 (standard HTTP port)
EXPOSE 80

# Copy your .NET Core project file (e.g., MyApi.csproj)
COPY *.csproj ./

# Restore project dependencies
RUN dotnet restore

# Copy the rest of your application code
COPY . .

# Publish the application in Release mode
RUN dotnet publish -c Release -o out

# Copy the published output from the build stage
COPY --from=runtime /app/out.dll .

# Set the entrypoint to run the published application
ENTRYPOINT ["dotnet", "MyApi.dll"]
