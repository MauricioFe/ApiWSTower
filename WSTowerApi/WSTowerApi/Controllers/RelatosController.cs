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
    public class RelatosController : ControllerBase
    {
        private readonly IRelatoRepository _repo;

        public RelatosController(IRelatoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Relatos> GetAll()
        {
            return _repo.GetAll();
        }
        [HttpGet("{id}", Name = "GetRelato")]
        public IActionResult GetById(int id)
        {
            var relatos = _repo.Find(id);

            if (relatos == null)
            {
                return NotFound();
            }

            return new ObjectResult(relatos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Relatos relato)
        {
            if (relato == null)
            {
                return BadRequest();
            }

            _repo.Add(relato);
            return CreatedAtRoute("GetRelato", new { id = relato.Id }, relato);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var relato = _repo.Find(id);
            if (relato == null)
            {
                return BadRequest();
            }

            _repo.Remove(id);
            return new NoContentResult();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Relatos relato)
        {
            if (relato == null)
            {
                return BadRequest();
            }
            var relatoEditado = _repo.Find(id);
            if (relatoEditado == null)
            {
                return BadRequest();
            }
            relatoEditado.Imagem = relato.Imagem;
            relatoEditado.Relato = relato.Relato;
            relatoEditado.Latitude = relato.Latitude;
            relatoEditado.Longitude = relato.Longitude;
            relatoEditado.UsuarioId = relato.UsuarioId;
            _repo.Update(relato);
            return CreatedAtRoute("GetRelato", new { id = relato.Id }, relato);
        }
    }
}
