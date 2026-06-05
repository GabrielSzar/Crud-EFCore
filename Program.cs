using Microsoft.Extensions.Configuration;
namespace CrudMariaDB;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("Default");
        Console.Clear();
        using var db = new AppDbContext();
        db.Produtos.Add(new Produto { Nome = "Teclado", Preco = 150.00, Categoria = "Periférico" });
        await db.SaveChangesAsync();

        // Consultar com LINQ
        var baratos = db.Produtos
            .Where(p => p.Preco < 200)
            .OrderBy(p => p.Nome);

        foreach (var p in baratos)
            Console.WriteLine($"{p.Id} — {p.Nome} — R${p.Preco}");
    }
}
