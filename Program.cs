using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace CrudMariaDB;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("Default");

        var servicos = new ProdutoService();
        while (true)
        {
            Console.Clear();
            Console.WriteLine(UI.CentralizarTexto(" Banco de Dados ", '—'));
            Console.WriteLine($"{"Id",-3} | {"Nome",-15} | {"Categoria",-25} | {"Preco",6:C}");
            Console.WriteLine(UI.CentralizarTexto("", '—'));
            servicos.ListarTodos();

            Console.WriteLine($"""
                {UI.CentralizarTexto("", '—')}
                1 - Adicionar no Banco
                2 - Alterar Produto
                3 - Remover produto
                4 - Sair
                """);
            Console.Write("Escolha: ");
            switch (Console.ReadLine())
            {
                case "1": servicos.Adicionar(); break;
                case "2": servicos.Alterar(); break;
                case "3": servicos.Remover(); break;
                case "4": return;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
