using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using senai.hroads.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(int idClasse, Classe classeAtualizada)
        {
            _classeRepository.Atualizar(idClasse, classeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);

            return StatusCode(204);
        }
    }
}
