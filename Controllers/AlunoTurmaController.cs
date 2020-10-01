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
        private readonly AlunoTurmaRepository _AlunoTurmaRepository;

        public AlunoTurmaController()
        {
            _AlunoTurmaRepository = new AlunoTurmaRepository();
        }
        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public List<AlunoTurma> Get()
        {
            return _AlunoTurmaRepository.LerTodos();
        }

        // GET api/<AlunoTurmaController>/5
        [HttpGet("{id}")]
        public AlunoTurma Get(int id)
        {
            return _AlunoTurmaRepository.BuscarPorId(id);
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public AlunoTurma Post([FromBody] AlunoTurma alunoTurma)
        {
            return _AlunoTurmaRepository.Cadastrar(alunoTurma);
        }

        // PUT api/<AlunoTurmaController>/5
        [HttpPut("{id}")]
        public AlunoTurma Put(int id, [FromBody] AlunoTurma alunoTurma)
        {
            return _AlunoTurmaRepository.Alterar(id, alunoTurma);
        }

        // DELETE api/<AlunoTurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _AlunoTurmaRepository.Excluir(id);
        }
    }
}
