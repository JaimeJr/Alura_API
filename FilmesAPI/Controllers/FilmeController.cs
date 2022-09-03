﻿using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
          filmes.Add(filme);
        }
    }
}
