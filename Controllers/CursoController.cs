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
        CursoRepository repos = new CursoRepository();

        // GET: api/<CursoController>
        [HttpGet]
        public List<Curso> Get()
        {
            return repos.LerTodos();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public Curso Get(int id)
        {
            return repos.BuscarPorId(id);
        }

        // POST api/<CursoController>
        [HttpPost]
        public Curso Post([FromBody] Curso k)
        {
            return repos.Cadastrar(k);
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public Curso Put(int id, [FromBody] Curso k)
        {
            return repos.Alterar(id, k);
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.Excluir(id);
        }
    }
}
