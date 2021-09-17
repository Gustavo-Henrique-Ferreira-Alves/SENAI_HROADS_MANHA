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
    public class TiposHabController : ControllerBase
    {
        private ITiposHabRepository _tiposHabRepository { get; set; }


        public TiposHabController()
        {
            _tiposHabRepository = new TiposHabRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tiposHabRepository.Listar());
        }


        [HttpGet("{idTipoHab}")]
        public IActionResult BuscarPorId(int idTipoHab)
        {
            return Ok(_tiposHabRepository.BuscarPorId(idTipoHab));
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(TiposHabilidade novoTipoHab)
        {
            _tiposHabRepository.Cadastrar(novoTipoHab);

            return StatusCode(201);
        }


        [HttpPut("{idTipoHab}")]
        public IActionResult Atualizar(int idTipoHab, TiposHabilidade tipoHabAtualizado)
        {
            _tiposHabRepository.Atualizar(idTipoHab, tipoHabAtualizado);

            return StatusCode(204);
        }


        [HttpDelete("{idTipoHab}")]
        public IActionResult Deletar(int idTipoHab)
        {
            _tiposHabRepository.Deletar(idTipoHab);

            return StatusCode(204);
        }
    }
}
