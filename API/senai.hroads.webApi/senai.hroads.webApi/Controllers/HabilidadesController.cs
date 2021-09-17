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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.ListarHabilidades());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_habilidadeRepository.BuscarHabilidadePorId(id));
        }


        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            _habilidadeRepository.CadastrarHabilidade(novaHabilidade);

            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            _habilidadeRepository.AtualizarHabilidadeUrl(id, habilidadeAtualizada);

            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.DeletarHabilidade(id);

            return StatusCode(204);
        }


        [HttpGet("tiposhabilidades")]
        public IActionResult GetTypesAbilities()
        {
            return Ok(_habilidadeRepository.ListarTiposHabilidadeInclusas());
        }


    }
}
