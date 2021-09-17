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
    public class ClassesHabController : ControllerBase
    {
        private IClassesHabRepository _classesHabRepository { get; set; }

        public ClassesHabController()
        {
            _classesHabRepository = new ClassesHabRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classesHabRepository.Listar());
        }

        [HttpGet("{idClasseHab}")]
        public IActionResult BuscarPorId(int idClasseHab)
        {
            return Ok(_classesHabRepository.BuscarPorId(idClasseHab));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(ClassesHabilidade novaClasseHab)
        {
            _classesHabRepository.Cadastrar(novaClasseHab);

            return StatusCode(201);
        }

        [HttpPut("{idClasseHab}")]
        public IActionResult Atualizar(int idClasseHab, ClassesHabilidade classeHabAtualizada)
        {
            _classesHabRepository.Atualizar(idClasseHab, classeHabAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idClasseHab}")]
        public IActionResult Deletar(int idClasseHab)
        {
            _classesHabRepository.Deletar(idClasseHab);

            return StatusCode(204);
        }
    }
}
