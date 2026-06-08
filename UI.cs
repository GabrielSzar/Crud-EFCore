namespace CrudMariaDB;

class UI
{
    public static string CentralizarTexto(string texto, char fill)
    => $"{new string(fill, (Console.WindowWidth - texto.Length) / 2)}{texto}{new string(fill, (Console.WindowWidth - texto.Length) / 2)}";

    public static int Select(string[] options, List<string> produtos)
    {
        var selected = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(UI.CentralizarTexto(" Banco de Dados ", '—'));
            Console.WriteLine($"{"Id",-3} | {"Nome",-15} | {"Categoria",-25} | {"Preco",6:C}");
            Console.WriteLine(UI.CentralizarTexto("", '—'));

            foreach (var produto in produtos)
                Console.WriteLine(produto);

            Console.WriteLine(UI.CentralizarTexto("", '—'));
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" >> {options[i]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"    {options[i]}");
            }
            Console.WriteLine("\n[↑↓] Navegar [Enter] Selecionar [Esc] Sair");

            var key = Console.ReadKey(false).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selected = selected != 0 ? selected - 1 : options.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selected = selected != options.Length - 1 ? selected + 1 : 0;
                    break;

                case ConsoleKey.Enter: return selected + 1;
                case ConsoleKey.Escape: return -1;
            }
        }
    }
}
