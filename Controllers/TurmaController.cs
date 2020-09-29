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
    public class TurmaController : ControllerBase
    {
        TurmaRepository repli = new  TurmaRepository();
        // GET: api/<TurmaController>
        [HttpGet]
        public List<Turma> Get()
        {
            return repli.LerTodos();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return repli.BuscarPorId(id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public Turma Post([FromBody] Turma f)
        {
            return repli.Cadastrar(f);
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public Turma Put(int id, [FromBody] Turma f)
        {
            return repli.Alterar(id, f);
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repli.Excluir(id);
        }
    }
}
