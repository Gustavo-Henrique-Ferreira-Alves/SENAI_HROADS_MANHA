using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Controllers
{
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
        public IActionResult Get()
        {
            return Ok(_personagemRepository.ListarPersonagens());
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagemRepository.BuscarPersonagemPorId(id));
        }



        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            _personagemRepository.CadastrarPersonagem(novoPersonagem);

            return StatusCode(201);
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            _personagemRepository.AtualizarPersonagemUrl(id, personagemAtualizado);

            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.DeletarPersonagem(id);

            return StatusCode(204);
        }


        [HttpGet("classes")]
        public IActionResult GetClasses()
        {
            return Ok(_personagemRepository.ListarClassesInclusas());
        }

    }
}
