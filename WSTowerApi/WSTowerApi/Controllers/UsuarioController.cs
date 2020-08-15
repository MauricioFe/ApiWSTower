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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _repo.GetAll();
        }
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult FindById(int id)
        {
            var usuario = _repo.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return new ObjectResult(usuario);
        }
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
                return BadRequest("Credenciais Erradas");
            }

            return CreatedAtRoute("GetUsuario", new { id = usuarioLogado.Id }, usuarioLogado);

        }
        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _repo.Add(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);

        }
    }
}
