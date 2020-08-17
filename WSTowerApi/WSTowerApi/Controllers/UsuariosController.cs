using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowerApi.Models;
using WSTowerApi.Repository;

namespace WSTowerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public UsuariosController(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
            var usuario = _repo.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return new ObjectResult(usuario);
        }

        // POST api/<RelatosController>
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {

            if (usuario == null)
            {
                return BadRequest();
            }
            var usuarioLogado = _repo.Login(usuario);
            if (usuarioLogado == null)
            {
                return BadRequest("Credenciais erradas");
            }

            return new NoContentResult();
        }
    }
}
