FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Models/ContosoPizza.Models.csproj Models/
RUN dotnet restore Models/ContosoPizza.Models.csproj

COPY Data/ContosoPizza.Data.csproj Data/
RUN dotnet restore Data/ContosoPizza.Data.csproj

COPY Business/ContosoPizza.Business.csproj Business/
RUN dotnet restore Business/ContosoPizza.Business.csproj

COPY API/ContosoPizza.API.csproj API/
RUN dotnet restore API/ContosoPizza.API.csproj

WORKDIR /app
COPY . .

RUN dotnet build -c Release -o /app/out API/ContosoPizza.API.csproj

# VOLUME /app/Data

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "ContosoPizza.API.dll"]