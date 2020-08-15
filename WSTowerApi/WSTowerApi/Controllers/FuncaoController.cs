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
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoRepository _repo;

        public FuncaoController(IFuncaoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Funcao> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Funcao funcao)
        {
            if (funcao == null)
            {
                return BadRequest();
            }
            _repo.Add(funcao);

            return new NoContentResult();

        }
    }
}
