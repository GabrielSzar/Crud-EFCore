namespace CrudMariaDB;

class ProdutoService
{

    private readonly AppDbContext _db;
    private readonly ProdutoRepository _repo;

    public ProdutoService()
    {
        _db = new AppDbContext();
        _repo = new ProdutoRepository(_db);
    }
    private (string?, double, string?) Infos()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        Console.Write("Preço: ");
        var preco = Convert.ToDouble(Console.ReadLine());

        Console.Write("Categoria: ");
        var categoria = Console.ReadLine();
        return (nome, preco, categoria);
    }
    public void Adicionar()
    {
        var (nome, preco, categoria) = Infos();

        _repo.Adicionar(new Produto { Nome = nome, Preco = preco, Categoria = categoria });
    }
    public void Alterar()
    {
        Console.Write("Id do produto a alterar: ");
        var id = Convert.ToInt32(Console.ReadLine());

        var produto = _repo.BuscarId(id);
        if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }

        Console.WriteLine($"Alterando: {produto.Id} - {produto.Nome}");

        var (nome, preco, categoria) = Infos();

        produto.Nome = nome;
        produto.Preco = preco;
        produto.Categoria = categoria;

        _repo.Alterar(produto);
    }
    public void Remover()
    {
        Console.Write("Id do produto a alterar: ");
        var id = Convert.ToInt32(Console.ReadLine());

        var produto = _repo.BuscarId(id);
        if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }

        Console.WriteLine($"Removendo: {produto.Id} - {produto.Nome}");
        _repo.Remover(produto);
    }
    public void ListarTodos()
    {
        using var db = new AppDbContext();
        var repo = new ProdutoRepository(db);

        foreach (var p in repo.MostrarProdutos())
            Console.WriteLine($"{p.Id,-3} | {p.Nome,-15} | {p.Categoria,-25} | {p.Preco,6:C}");
    }
}
