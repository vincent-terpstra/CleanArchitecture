# CleanArchitecture
A Blazor web app and ASP.Net web api using clean architecture following various youtube tutorials

## Credits
[Amichai Mantinband](https://www.youtube.com/@amantinband) - initial design and architecture (BuberDinner Api)


## Database

### Create Initial migration
```shell
dotnet ef migrations add InitialCreate --project .\BuberDinner.Infrastructure\ --startup-project .\BuberDinner.API\  
```

### Create docker Container
```shell
docker pull mcr.microsoft.com/mssql/server:2022-latest 
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=pwd123!' -p 1433:1433 -d mcr.microsoft.com/mssql/server-2022-latest
docker container ls
```

### Sql Connection string
> User Secrets BuberDinner.API
```json
{
  "ConnectionStrings": {
    "SqlDatabase": "Server=localhost;Database=BuberDinner;User Id=sa;Password=pwd123!;TrustServerCertificate=true;"
  }
}
```

### Update Database
```shell
dotnet ef database update -p BuberDinner.Infrastructure -s BuberDinner.Api
```
