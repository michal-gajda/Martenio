## Martenio ###

### What's New ###

1. Marten [https://martendb.io/]
2. HttpRepl [https://docs.microsoft.com/en-gb/aspnet/core/web-api/http-repl/]
3. HTTPS in Docker

#### 1. Marten ####

.NET Transactional Document DB and Event Store on PostgreSQL

#### 2. HttpRepl ####

Install
```
dotnet tool install --global Microsoft.dotnet-httprepl
```

#### 3. HTTPS in Docker ####
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p P@ssw0rd
```
or
```
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p P@ssw0rd
```