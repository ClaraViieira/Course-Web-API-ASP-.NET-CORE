using Microsoft.AspNetCore.Mvc;
using LivrosApi.Context;
using LivrosApi.Models;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosContext _context;

        public LivrosController(LivrosContext context)
        {
            _context = context;
        }

        [HttpPost("CriarLivros")]
        public IActionResult CriarLivros(Livro livro)
        {
            if (livro == null)
                return BadRequest("Dados inválidos");

            _context.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterLivroPorId),
                new { id = livro.LivrosId }, livro);
        }

        [HttpGet("ObterLivros")]
        public IActionResult ObterLivros()
        {
            var livro = _context.Livros.ToList();
            if (livro == null)
                return NotFound("Livros não localizados");

            return Ok(livro);
        }

        [HttpGet("ObterLivroPorId/{id}")]
        public IActionResult ObterLivroPorId(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
                return NotFound("Livro não localizado");

            return Ok(livro);

        }

        [HttpPut("AtualizarLivros/{id}")]
        public IActionResult AtualizarLivros(Livro livro, int id)
        {
            var livros = _context.Livros.Find(id);

            if (livros == null)
                return NotFound("Livro não localizado");

            livros.Titulo = livro.Titulo;
            livros.ISBN = livro.ISBN;
            livros.Estoque = livro.Estoque;
            livros.Ativo = livro.Ativo;
            livros.Preco = livro.Preco;
            livros.DataCadastro = livro.DataCadastro;

            _context.Livros.Update(livros);
            _context.SaveChanges();

            return Ok(livros);
        }

        [HttpDelete("DeletarLivros/{id}")]
        public IActionResult DeletarLivros(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
                return NotFound("Livro não localizado");

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return Ok(livro);
        }
    }
}