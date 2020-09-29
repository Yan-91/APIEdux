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
    public class CategoriaController : ControllerBase
    {
        CategoriaRepository repr = new CategoriaRepository();
        // GET: api/<CategoriaController>
        [HttpGet]
        public List<Categoria> Get()
        {
            return repr.LerTodos();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            return repr.BuscarPorId(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public Categoria Post([FromBody] Categoria c)
        {
            return repr.Cadastrar(c);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public Categoria Put(int id, [FromBody] Categoria c)
        {
            return repr.Alterar(id,c);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repr.Excluir(id);
        }
    }
}
