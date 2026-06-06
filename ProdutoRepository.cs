namespace CrudMariaDB;

class ProdutoRepository(AppDbContext database)
{
    public void Adicionar(Produto produto)
    {
        database.Produtos.Add(produto);
        database.SaveChangesAsync();
    }
    public void Remover(Produto produto)
    {
        database.Produtos.Remove(produto);
        database.SaveChangesAsync();
    }
    public void Alterar(Produto produto) => database.SaveChangesAsync();
    public IEnumerable<Produto> MostrarProdutos() => database.Produtos.ToList();
    public Produto? BuscarId(int id) => database.Produtos.FirstOrDefault(p => p.Id == id);
}
