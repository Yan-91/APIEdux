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
    public class AlunoTurmaController : ControllerBase
    {
        AlunoTurmaRepository repu = new AlunoTurmaRepository();
        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public List<AlunoTurma> Get()
        {
            return repu.LerTodos();
        }

        // GET api/<AlunoTurmaController>/5
        [HttpGet("{id}")]
        public AlunoTurma Get(int id)
        {
            return repu.BuscarPorId(id);
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public AlunoTurma Post([FromBody] AlunoTurma g)
        {
            return repu.Cadastrar(g);
        }

        // PUT api/<AlunoTurmaController>/5
        [HttpPut("{id}")]
        public AlunoTurma Put(int id, [FromBody] AlunoTurma g)
        {
            return repu.Alterar(id, g);
        }

        // DELETE api/<AlunoTurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repu.Excluir(id);
        }
    }
}
