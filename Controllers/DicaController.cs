using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_Edux.Domains;
using API_Edux.Repositories;
using API_Edux.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        
        DicaRepository reposi = new DicaRepository();
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Dica> Get()
        {
            return reposi.LerTodos();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Dica Get(int id)
        {
            return reposi.BuscarPorId(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Dica Post([FromForm] Dica d)
        {

            return reposi.Cadastrar(d);

            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Dica Put(int id, [FromBody] Dica d)
        {
            return reposi.Alterar(id, d);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reposi.Excluir(id);
        }
    }
}
