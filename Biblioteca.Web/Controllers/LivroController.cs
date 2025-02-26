using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Web.Models;
using Biblioteca.Servico.Servicos;
using Biblioteca.Servico.Models;

namespace Biblioteca.Web.Controllers;

public class LivroController : Controller
{
    private readonly ILogger<LivroController> _logger;
    private readonly GerenciadorDeLivros _gerenciadorDeLivros;
    public LivroController(ILogger<LivroController> logger, GerenciadorDeLivros gerenciadorDeLivros)
    {
        _logger = logger;
        _gerenciadorDeLivros = gerenciadorDeLivros;
    }

    public IActionResult Index()
    {
        var livros = _gerenciadorDeLivros.Listar();
        return View(livros);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Livro livro)
    {
        _gerenciadorDeLivros.Adicionar(livro);
        return RedirectToAction("Index");
    }

   public IActionResult Editar(string id)
    {
        var livro = _gerenciadorDeLivros.ObterLivroPorId(id);
        if (livro == null) return NotFound();
        return View(livro);
    }

    [HttpPost]
    public IActionResult Editar(Livro livro)
    {
        _gerenciadorDeLivros.Atualizar(livro.Id, livro);
        return RedirectToAction("Index");
    }

    public IActionResult Remover(string id)
    {
        var livro = _gerenciadorDeLivros.ObterLivroPorId(id);
        if (livro == null) return NotFound();
        return View(livro);
    }

    [HttpPost]
    public IActionResult ConfirmarDeletar(string id)
    {
        _gerenciadorDeLivros.Remover(id);
        return RedirectToAction("Index");
    }
}
