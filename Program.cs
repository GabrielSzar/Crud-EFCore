using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
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

        do
        {
            Console.Clear();
            using var database = new AppDbContext();

            Console.WriteLine("====== Banco de Produtos ======\n");

            foreach (var p in database.Produtos)// Read
            {
                Console.WriteLine(p.MostrarProduto());
            }

            Console.Write("""

                ==========================
                1 - Adicionar no Banco
                2 - Alterar Produto
                3 - Remover produto
                4 - Sair
                Escolha:
                """);
            var escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1: AdicionarBanco(); break;
                case 2: await AlterarBanco(); break;
                case 3: RemoverBanco(); break;
                case 4: return;
                default:
                    continue;
            }
        } while (true);

    }
    static void AdicionarBanco()// Create
    {
        using var database = new AppDbContext();
        Console.WriteLine("Informe o Nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Informe o Preço: ");
        var preco = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Informe a categoria: ");
        var categoria = Console.ReadLine();

        database.Add(new Produto { Nome = nome, Preco = preco, Categoria = categoria });
        database.SaveChanges();
    }
    static async Task AlterarBanco()// Update
    {
        using var database = new AppDbContext();
        Console.Write("Informe o Id qual produto voce quer alterar: ");
        var id = Convert.ToInt32(Console.ReadLine());

        var produtoAlterar = await database.Produtos.FirstOrDefaultAsync(p => p.Id == id);


        Console.WriteLine($"Alterando:  {produtoAlterar.Id} - {produtoAlterar.Nome}");
        Console.WriteLine("Informe o Nome: ");
        produtoAlterar.Nome = Console.ReadLine();
        Console.WriteLine("Informe o Preço: ");
        produtoAlterar.Preco = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Informe a categoria: ");
        produtoAlterar.Categoria = Console.ReadLine();

        await database.SaveChangesAsync();

    }
    static async Task RemoverBanco()
    {
        using var database = new AppDbContext();
        Console.Write("Informe o Id qual produto voce quer alterar: ");
        var id = Convert.ToInt32(Console.ReadLine());

        var produtoRemover = await database.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        database.Remove(produtoRemover);
        await database.SaveChangesAsync();
    }
}
