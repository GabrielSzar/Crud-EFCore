## Pré-requisitos
 
- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- MySQL rodando localmente
---
### Como baixar o MySQL
 
**Windows**
 
1. Baixe o MySQL Installer em [dev.mysql.com/downloads/installer](https://dev.mysql.com/downloads/installer/)
2. Escolha a opção **MySQL Server** e siga o assistente
3. Defina uma senha para o `root` e finalize

**Linux (Ubuntu/Debian)**
 
```bash
sudo apt update
sudo apt install mysql-server
sudo systemctl start mysql
sudo mysql_secure_installation   # opcional, mas recomendado
```
 
**macOS**
 
```bash
brew install mysql
brew services start mysql
```
 
---
 
### Criando o banco e o usuário
 
Após instalar, acesse o console do banco:
 
```bash
mysql -u root -p
```
 
E execute:
 
```sql
CREATE DATABASE crud_efcoreDB;
CREATE USER 'crud_efcoreUser'@'localhost' IDENTIFIED BY 'crud_efcorePassword';
GRANT ALL PRIVILEGES ON crud_efcoreDB.* TO 'crud_efcoreUser'@'localhost';
FLUSH PRIVILEGES;
EXIT;
```
 

---

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
    "Default": "Server=localhost;Database=crud_efcoreDB;User=crud_efcoreUser;Password=crud_efcorePassword;"
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
