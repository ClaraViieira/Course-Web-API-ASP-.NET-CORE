using Microsoft.AspNetCore.Mvc;
using LivrosApi.Context;
using LivrosApi.Models;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly LivrosContext _context;

        public EditorasController(LivrosContext context)
        {
            _context = context;
        }

        [HttpPost("CriarEditoras")]
        public IActionResult CriarEditoras(Editora editora)
        {
            if (editora == null)
                return BadRequest("Dados inválidos");

            _context.Add(editora);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterEditoraPorId), 
                new { id = editora.EditoraId }, editora);
        }

        [HttpGet("ObterEditoras")]
        public IActionResult ObterEditoras()
        {
            var editora = _context.Editoras.ToList();
            if (editora == null)
                return NotFound("Editoras não localizadas");

            return Ok(editora);
        }

        [HttpGet("ObterEditoraPorId/{id}")]
        public IActionResult ObterEditoraPorId(int id)
        {
            var editora = _context.Editoras.Find(id);

            if (editora == null)
                return NotFound("Editora não localizada");

            return Ok(editora);

        }

        [HttpPut("AtualizarEditoras/{id}")]
        public IActionResult AtualizarEditoras(Editora editora, int id)
        {
            var editoras = _context.Editoras.Find(id);

            if (editoras == null)
                return NotFound("Editora não localizada");

            editoras.CNPJ = editora.CNPJ;
            editoras.RazaoSocial = editora.RazaoSocial;
            editoras.NomeFantasia = editora.NomeFantasia;

            _context.Editoras.Update(editoras);
            _context.SaveChanges();

            return Ok(editoras);
        }

        [HttpDelete("DeletarEditoras/{id}")]
        public IActionResult DeletarEditoras(int id)
        {
            var editora = _context.Editoras.Find(id);

            if (editora == null)
                return NotFound("Editora não localizada");

            _context.Editoras.Remove(editora);
            _context.SaveChanges();

            return Ok(editora);
        }
    }
}
