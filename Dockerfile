# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything and build
COPY . ./
RUN dotnet restore "Unicam.Enterprise.Project.Web/Unicam.Enterprise.Project.Web.csproj"
RUN dotnet publish "Unicam.Enterprise.Project.Web/Unicam.Enterprise.Project.Web.csproj" -c Release -o /App/out

# Use the ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Unicam.Enterprise.Project.Web.dll"]
