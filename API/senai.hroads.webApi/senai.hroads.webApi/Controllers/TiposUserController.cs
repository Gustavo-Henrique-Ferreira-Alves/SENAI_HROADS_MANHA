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
    public class TiposUserController : ControllerBase
    {
        private ITiposUserRepository _tipoUserRepository { get; set; }

        public TiposUserController()
        {
            _tipoUserRepository = new TiposUserRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUserRepository.Listar());
        }

        [HttpGet("{idTipoUser}")]
        public IActionResult BuscarPorId(int idTipoUser)
        {
            return Ok(_tipoUserRepository.BuscarPorId(idTipoUser));
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposUsuario novoUsuario)
        {
            _tipoUserRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{idTipoUser}")]
        public IActionResult Atualizar(int idTipoUser, TiposUsuario tipoUserAtualizado)
        {
            _tipoUserRepository.Atualizar(idTipoUser, tipoUserAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idTipoUser}")]
        public IActionResult Deletar(int idTipoUser)
        {
            _tipoUserRepository.Deletar(idTipoUser);

            return StatusCode(204);
        }
    }
}
