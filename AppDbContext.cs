using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace CrudMariaDB;

public class AppDbContext : DbContext
{
    private readonly string? _connectionString;

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
        options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
    }
}
