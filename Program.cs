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
            Thread.Sleep(1000);
            string[] options = { "Adicionar no Banco", "Alterar Produto", "Remover produto" };
            var selected = UI.Select(options, servicos.ListarTodos());

            Console.Clear();
            switch (selected)
            {
                case 1: servicos.Adicionar(); break;
                case 2: servicos.Alterar(); break;
                case 3: servicos.Remover(); break;
                case -1: Console.WriteLine("Obrigado por Testar :)"); return;
            }

        }
    }
}
