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
    public class InstituicaoController : ControllerBase
    {
        InstituicaoRepository rep = new InstituicaoRepository();
        // GET: api/<InstituicaoController>
        [HttpGet]
        public List<Instituicao> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<InstituicaoController>/5
        [HttpGet("{id}")]
        public Instituicao Get(int id)
        {
            return rep.BuscarPorId(id);
        }

        // POST api/<InstituicaoController>
        [HttpPost]
        public Instituicao Post([FromBody] Instituicao i)
        {
            return rep.Cadastrar(i);
        }

        // PUT api/<InstituicaoController>/5
        [HttpPut("{id}")]
        public Instituicao Put(int id, [FromBody] Instituicao i)
        {
            return rep.Alterar(id, i);
        }

        // DELETE api/<InstituicaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Excluir(id);
        }
    }
}
