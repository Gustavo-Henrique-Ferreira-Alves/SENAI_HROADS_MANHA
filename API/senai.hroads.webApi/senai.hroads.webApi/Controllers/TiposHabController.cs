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
    public class TiposHabController : ControllerBase
    {
        private ITiposHabilidadeRepository _tiposHabilidadeRepository { get; set; }


        public TiposHabilidadesController()
        {
            _tiposHabilidadeRepository = new TiposHabilidadeRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposHabilidadeRepository.ListarTiposHabilidades());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposHabilidadeRepository.BuscarTipoHabilidadePorId(id));
        }


        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(TiposHabilidade novoTipoHabilidade)
        {
            _tiposHabilidadeRepository.CadastrarTipoHabilidade(novoTipoHabilidade);

            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposHabilidade tipoHabilidadeAtualizado)
        {
            _tiposHabilidadeRepository.AtualizarTipoHabilidadeUrl(id, tipoHabilidadeAtualizado);

            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tiposHabilidadeRepository.DeletarTipoHabilidade(id);

            return StatusCode(204);
        }


        [HttpGet("habilidades")]
        public IActionResult GetAbilities()
        {
            return Ok(_tiposHabilidadeRepository.ListarHabilidadesInclusas());
        }

    }
}
