using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using ParkingPOC.Services.Services;
using System.Linq; 

namespace ParkingPOC.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(ITokenService tokenService, IPasswordHasher<Usuario> passwordHasher, IUsuarioService usuarioService)
        {
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _usuarioService = usuarioService; 
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody] Login login)
        {
            var usuario = _usuarioService.Listar().Result.Where(_ => _.Login == login.Usuario).FirstOrDefault();

            if (usuario == null) return NotFound();

            var passwordResult = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, login.Password);

            if (passwordResult == PasswordVerificationResult.Failed) return BadRequest();

            var token = _tokenService.Executar();

            return Ok(token); 

        }

        [HttpPost]
        [AllowAnonymous] //apenas para efeito de facilitar a analise
        public IActionResult Post([FromBody] UsuarioDTO dto)
        {
            var usuario = new Usuario { Nome = dto.Nome, Login = dto.Login, Password = dto.Password };

            var passwordHash = _passwordHasher.HashPassword(usuario, dto.Password);

            usuario.Password = passwordHash;

            _usuarioService.Incluir(usuario); 

            return Ok();
        }

    }
}
