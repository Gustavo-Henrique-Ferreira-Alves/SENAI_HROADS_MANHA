using Microsoft.AspNetCore.Authorization;
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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.Listar());
        }

        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }

        [Authorize(Roles = "Jogador")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(idPersonagem, personagemAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }
    }
}