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
    public class ProfessorTurmaController : ControllerBase
    {
        ProfessorTurmaRepository repa = new ProfessorTurmaRepository();
        // GET: api/<ProfessorTurmaController>
        [HttpGet]
        public List<ProfessorTurma> Get()
        {
            return repa.LerTodos();
        }

        // GET api/<ProfessorTurmaController>/5
        [HttpGet("{id}")]
        public ProfessorTurma Get(int id)
        {
            return repa.BuscarPorId(id);
        }

        // POST api/<ProfessorTurmaController>
        [HttpPost]
        public ProfessorTurma Post([FromBody] ProfessorTurma e)
        {
            return repa.Cadastrar(e);
        }

        // PUT api/<ProfessorTurmaController>/5
        [HttpPut("{id}")]
        public ProfessorTurma Put(int id, [FromBody] ProfessorTurma e)
        {
            return repa.Alterar(id, e);
        }

        // DELETE api/<ProfessorTurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             repa.Excluir(id);
        }
    }
}
