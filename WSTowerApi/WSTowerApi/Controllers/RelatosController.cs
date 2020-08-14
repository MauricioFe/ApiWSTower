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
        private readonly IRelatosRepository _repo;

        public RelatosController(IRelatosRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Relato> GetAll()
        {
            return _repo.GetAll();
        }
        [HttpGet("{id}", Name = "GetRelato")]
        public IActionResult FindById(int id)
        {
            var relato = _repo.Find(id);
            if (relato == null)
            {
                return NotFound();
            }

            return new ObjectResult(relato);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Relato relato)
        {
            if (relato == null)
            {
                return BadRequest();
            }
            _repo.Add(relato);

            return CreatedAtRoute("GetRelato", new { id = relato.Id }, relato);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Relato relato)
        {
            var _relato = _repo.Find(id);
            if (relato == null)
            {
                return BadRequest();
            }

            if (_relato == null)
            {
                return NotFound();
            }

            _relato.Imagem = relato.Imagem;
            _relato.relato = relato.relato;
            _relato.Latitude = relato.Latitude;
            _relato.Longitude = relato.Longitude;

            _repo.Update(_relato);

            return CreatedAtRoute("GetRelato", new { id = _relato.Id }, _relato);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var relato = _repo.Find(id);
            if (relato == null)
            {
                return NotFound();
            }

            _repo.Remove(id);
            return new NoContentResult();
        }
    }
}
