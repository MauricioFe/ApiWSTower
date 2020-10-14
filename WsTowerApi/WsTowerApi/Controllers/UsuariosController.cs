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

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name ="Get")]
        public IActionResult GetById(int id)
        {
            var usuario = _repo.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return new ObjectResult(usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            var usuarioLogado = _repo.Login(usuario);
            if (usuarioLogado == null)
            {
                return BadRequest("Erro nas credenciais");
            }

            return CreatedAtRoute("Get", new { id = usuarioLogado.Id}, usuarioLogado);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _repo.Add(usuario);
            return CreatedAtRoute("Get", new { id = usuario.Id }, usuario);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _repo.Find(id);
            if (usuario == null)
            {
                return BadRequest();
            }
            
            _repo.Remove(id);
            return Ok(new { Message = "Usuário excluído com sucesso" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            var usuarioEditado = _repo.Find(id);
            if (usuarioEditado == null)
            {
                return BadRequest();
            }
            usuarioEditado.Nome = usuario.Nome;
            usuarioEditado.Email = usuario.Email;
            usuarioEditado.Telefone = usuario.Telefone;
            usuarioEditado.Senha = usuario.Senha;
            usuarioEditado.FuncaoId = usuario.FuncaoId;
            _repo.Update(usuarioEditado);
            return CreatedAtRoute("Get", new { id = usuarioEditado.Id }, usuarioEditado);
        }
    }
}
