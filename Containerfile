FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_URLS=http://*:8080

EXPOSE 8080 

WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "CelestialBodies_MVC.dll"]
