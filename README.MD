# Todo MVC App with .NET Framework and Entity Framework 

## 1. Set Connection String
```bash
db_password="yourpassword"

dotnet user-secrets set "ConnectionStrings:TodoAppContext" "Server=localhost; Database=todo_app; User Id=aziemp66; Password=$db_password; TrustServerCertificate=True;"
``````

## 2. Run App
```bash
dotnet run . 
```