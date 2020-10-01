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
    public class CursoController : ControllerBase
    {
        //Chamando o Repositorio 
        private readonly CursoRepository _CursoRepository;

        public CursoController()
        {
            _CursoRepository = new CursoRepository();
        }

        // GET: api/<CursoController>
        [HttpGet]
        public List<Curso> Get()
        {
            return _CursoRepository.LerTodos();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public Curso Get(int id)
        {
            return _CursoRepository.BuscarPorId(id);
        }

        // POST api/<CursoController>
        [HttpPost]
        public Curso Post([FromBody] Curso curso)
        {
            return _CursoRepository.Cadastrar(curso);
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public Curso Put(int id, [FromBody] Curso curso)
        {
            return _CursoRepository.Alterar(id,curso);
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CursoRepository.Excluir(id);
        }
    }
}
