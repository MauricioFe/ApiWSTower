using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSTowerApi.Models;
using WSTowerApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<RelatosController>
        [HttpGet]
        public IEnumerable<Relatos> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<RelatosController>/5
        [HttpGet("{id}", Name="GetRelatos")]
        public IActionResult GetById(int id)
        {
            var relatos= _repo.Find(id);
            if (relatos == null)
            {
                return NotFound();
            }

            return new ObjectResult(relatos);
        }

        // POST api/<RelatosController>
        [HttpPost]
        public IActionResult Post([FromBody] Relatos relatos)
        {
            if (relatos == null)
            {
                return NotFound();
            }
            _repo.Add(relatos);
            return CreatedAtRoute("GetRelatos", new { id = relatos.Id}, relatos);
        }

        // PUT api/<RelatosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Relatos relatos)
        {
            var _relatos = _repo.Find(id);
            if (relatos == null || _relatos == null)
            {
                return NotFound();
            }
            _relatos.Imagem = relatos.Imagem;
            _relatos.Relato = relatos.Relato;
            _relatos.Latitude = relatos.Latitude;
            _relatos.Longitude = relatos.Longitude;
            
            _repo.Update(_relatos);
            return CreatedAtRoute("GetRelatos", new { id = relatos.Id }, _relatos);
        }

        // DELETE api/<RelatosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _relatos = _repo.Find(id);
            if (_relatos == null)
            {
                return NotFound();
            }
          
            _repo.Remove(id);
            return new  NoContentResult();
        }
    }
}
