using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Edux.Domains;
using API_Edux.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly CurtidaRepository _CurtidaRepository;

        public CurtidaController()
        {
            _CurtidaRepository = new CurtidaRepository();
        }

        // GET: api/<CurtidaController>
        [HttpGet]
        public   List<Curtida> Get()
        {
            return _CurtidaRepository.LerTodos();
        }

        // GET api/<CurtidaController>/5
        [HttpGet("{id}")]
        public Curtida Get(int id)
        {
            return _CurtidaRepository.BuscarPorId(id);
        }

        // POST api/<CurtidaController>
        [HttpPost]
        public Curtida Post([FromBody] Curtida curtida)
        {
            return _CurtidaRepository.Cadastrar(curtida);
        }

        // PUT api/<CurtidaController>/5
        [HttpPut("{id}")]
        public Curtida Put(int id, [FromBody] Curtida curtida)
        {
            return _CurtidaRepository.Alterar(id, curtida);
        }

        // DELETE api/<CurtidaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CurtidaRepository.Excluir(id);
        }
    }
}
