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
    public class ObjetivoController : ControllerBase
    {
        ObjetivoRepository repy = new ObjetivoRepository();
        // GET: api/<ObjetivoController>
        [HttpGet]
        public List<Objetivo> Get()
        {
            return repy.LerTodos();
        }

        // GET api/<ObjetivoController>/5
        [HttpGet("{id}")]
        public Objetivo Get(int id)
        {
            return repy.BuscarPorId(id);
        }

        // POST api/<ObjetivoController>
        [HttpPost]
        public Objetivo Post([FromBody] Objetivo h)
        {
            return repy.Cadastrar(h);
        }

        // PUT api/<ObjetivoController>/5
        [HttpPut("{id}")]
        public Objetivo Put(int id, [FromBody] Objetivo h)
        {
            return repy.Alterar(id, h);
        }

        // DELETE api/<ObjetivoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repy.Excluir(id);
        }
    }
}
