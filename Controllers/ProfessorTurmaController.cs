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
        private readonly ProfessorTurmaRepository _ProfessorTurmaRepository;

        public ProfessorTurmaController()
        {
            _ProfessorTurmaRepository = new ProfessorTurmaRepository();
        }
        // GET: api/<ProfessorTurmaController>
        [HttpGet]
        public List<ProfessorTurma> Get()
        {
            return _ProfessorTurmaRepository.LerTodos();
        }

        // GET api/<ProfessorTurmaController>/5
        [HttpGet("{id}")]
        public ProfessorTurma Get(int id)
        {
            return _ProfessorTurmaRepository.BuscarPorId(id);
        }

        // POST api/<ProfessorTurmaController>
        [HttpPost]
        public ProfessorTurma Post([FromBody] ProfessorTurma professorTurma)
        {
            return _ProfessorTurmaRepository.Cadastrar(professorTurma);
        }

        // PUT api/<ProfessorTurmaController>/5
        [HttpPut("{id}")]
        public ProfessorTurma Put(int id, [FromBody] ProfessorTurma professorTurma)
        {
            return _ProfessorTurmaRepository.Alterar(id, professorTurma);
        }

        // DELETE api/<ProfessorTurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ProfessorTurmaRepository.Excluir(id);
        }
    }
}
