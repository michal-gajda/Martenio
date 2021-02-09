FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY Martenio.sln Martenio.sln
COPY Martenio.Application/Martenio.Application.csproj Martenio.Application/Martenio.Application.csproj
COPY Martenio.Core/Martenio.Core.csproj Martenio.Core/Martenio.Core.csproj
COPY Martenio.Infrastructure/Martenio.Infrastructure.csproj Martenio.Infrastructure/Martenio.Infrastructure.csproj
COPY Martenio.Tests/Martenio.Tests.csproj Martenio.Tests/Martenio.Tests.csproj
COPY Martenio.WebApi/Martenio.WebApi.csproj Martenio.WebApi/Martenio.WebApi.csproj

RUN dotnet restore

COPY . .

RUN dotnet build --configuration Release --output /app/build
RUN dotnet publish --configuration Release --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

RUN apt-get update && apt-get install -y curl=7.64.0-4+deb10u1 --no-install-recommends && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

RUN groupadd -g 10000 dotnet && useradd -u 10000 -g dotnet dotnet && chown -R dotnet:dotnet /app
USER dotnet:dotnet

ENV ASPNETCORE_URLS http://+:5080;https://+:5443
EXPOSE 5080
EXPOSE 5443

HEALTHCHECK --interval=5s --timeout=10s --retries=3 CMD curl --fail http://localhost:5080/health || exit 1
ENTRYPOINT ["dotnet", "Martenio.WebApi.dll"]