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
    public class ObjetivoAlunoController : ControllerBase
    {
        ObjetivoAlunoRepository re = new ObjetivoAlunoRepository();
        // GET: api/<ObjetivoAlunoController>
        [HttpGet]
        public List<ObjetivoAluno> Get()

        {
            return re.LerTodos();
        }

        // GET api/<ObjetivoAlunoController>/5
        [HttpGet("{id}")]
        public ObjetivoAluno Get(int id)
        {
            return re.BuscarPorId(id);
        }

        // POST api/<ObjetivoAlunoController>
        [HttpPost]
        public ObjetivoAluno Post([FromBody] ObjetivoAluno b)
        {
            return re.Cadastrar(b);
        }

        // PUT api/<ObjetivoAlunoController>/5
        [HttpPut("{id}")]
        public ObjetivoAluno Put(int id, [FromBody] ObjetivoAluno b)
        {
            return re.Alterar(id, b);
        }

        // DELETE api/<ObjetivoAlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            re.Excluir(id);
        }
    }
}
