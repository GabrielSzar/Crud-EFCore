## Pré-requisitos
 
- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- MariaDB/MySQL rodando localmente
## Configuração
 
1. Clone o repositório:
```bash
git clone https://github.com/GabrielSzar/Crud-EFCore.git
cd Crud-EFCore
```
 
2. Crie o arquivo `appsettings.json` a partir do exemplo:
```bash
cp appsettings.example.json appsettings.json
```
 
3. Edite o `appsettings.json` com os dados do seu banco:
```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=seu_banco;User=seu_usuario;Password=sua_senha;"
  }
}
```
 
4. Aplique as migrations para criar as tabelas:
```bash
dotnet ef database update
```
 
5. Execute a aplicação:
```bash
dotnet run
```
