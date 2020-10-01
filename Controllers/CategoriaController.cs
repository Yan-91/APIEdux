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
        private readonly CategoriaRepository _CategoriaRepository;

        public CategoriaController()
        {
            _CategoriaRepository = new CategoriaRepository();
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public List<Categoria> Get()
        {
            return _CategoriaRepository.LerTodos();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            return _CategoriaRepository.BuscarPorId(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public Categoria Post([FromBody] Categoria categoria)
        {
            return _CategoriaRepository.Cadastrar(categoria);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public Categoria Put(int id, [FromBody] Categoria categoria)
        {
            return _CategoriaRepository.Alterar(id,categoria);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CategoriaRepository.Excluir(id);
        }
    }
}
