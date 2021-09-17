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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarUsuarioPorId(id));
        }




        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.CadastrarUsuario(novoUsuario);

            return StatusCode(201);
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuarioRepository.AtualizarUsuarioUrl(id, usuarioAtualizado);

            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.DeletarUsuario(id);

            return StatusCode(204);
        }


        [HttpGet("tiposusuarios")]
        public IActionResult GetTypesUsers()
        {
            return Ok(_usuarioRepository.ListarTiposUsuariosInclusos());
        }



        [HttpPost("login")]
        public IActionResult Login(Usuario login)
        {

            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);


            if (usuarioBuscado == null)
            {
                return NotFound("email ou senha inválidos");
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuario.ToString()),
                new Claim("Claim personalizada", "Valor teste")
            };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao"));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "hroads.webAPI",
                audience: "hroads.webAPI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }




    }
}
