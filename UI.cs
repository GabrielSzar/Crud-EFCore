namespace CrudMariaDB;

class UI
{
    public static string CentralizarTexto(string texto, char fill)
    => $"{new string(fill, (Console.WindowWidth - texto.Length) / 2)}{texto}{new string(fill, (Console.WindowWidth - texto.Length) / 2)}";

}
