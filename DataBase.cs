using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace CrudMariaDB;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public AppDbContext()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = config.GetConnectionString("Default");
    }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
