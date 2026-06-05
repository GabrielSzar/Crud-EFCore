namespace CrudMariaDB;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public string? Categoria { get; set; }

    public string MostrarProduto()
    {
        return $"{Id} - {Nome} - {Categoria} ..... {Preco}";
    }
}
