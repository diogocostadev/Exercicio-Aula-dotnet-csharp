namespace Biblioteca.Servico.Models;

public class Livro
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Ano { get; set; }
}