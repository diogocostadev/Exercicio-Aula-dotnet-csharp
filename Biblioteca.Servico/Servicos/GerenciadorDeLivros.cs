using Biblioteca.Servico.Models;
using System.Text.Json;

namespace Biblioteca.Servico.Servicos;

public class GerenciadorDeLivros 
{
    private readonly string _caminhoDoArquivo = "Biblioteca.json";
    private List<Livro> _livros = new List<Livro>();

    public GerenciadorDeLivros()
    {
        CarregarLivros();
    }

    void CarregarLivros()
    {
        if (File.Exists(_caminhoDoArquivo))
        {
            var json = File.ReadAllText(_caminhoDoArquivo);
            _livros = JsonSerializer.Deserialize<List<Livro>>(json) ?? new List<Livro>();
        }
    }

    void SalvarLivros()
    {
        var json = JsonSerializer.Serialize(_livros, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoDoArquivo, json);
    }

    public void Adicionar(Livro livro)
    {
        _livros.Add(livro);
        SalvarLivros();
    }

    public List<Livro> Listar()
    {
        return _livros;
    }

    public void Remover(string id)
    {
        _livros.RemoveAll(l => l.Id == id);
        SalvarLivros();
    }

    public void Atualizar(string id, Livro livro)
    {
        var index = _livros.FindIndex(l => l.Id == id);
        if (index == -1)
        {
            throw new InvalidOperationException("Livro não encontrado");
        }

        _livros[index] = livro;
        SalvarLivros();
    }

    public Livro ObterLivroPorId(string id)
    {
        return _livros.FirstOrDefault(l => l.Id == id);
    }
}