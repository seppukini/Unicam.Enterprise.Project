# Use the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /App

# Copy everything and build
COPY . ./
RUN dotnet restore "Unicam.Enterprise.Project.Web/Unicam.Enterprise.Project.Web.csproj"
RUN dotnet publish "Unicam.Enterprise.Project.Web/Unicam.Enterprise.Project.Web.csproj" -c Release -o /App/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build /App/out .
COPY entrypoint.sh .

# Make the script executable
RUN chmod +x entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]
