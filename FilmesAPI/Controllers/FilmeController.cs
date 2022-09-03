using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
          _context.Filmes.Add(filme);
          _context.SaveChanges();
          return CreatedAtAction(nameof(RecurepaFilmesPorId), new {Id = filme.Id}, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecurepaFilmesPorId(int id)
        {
           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
           if (filme != null)
           {
             return Ok(filme);
           }
           return NotFound();
        }
    }
}
