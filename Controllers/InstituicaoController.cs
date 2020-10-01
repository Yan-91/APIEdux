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
        private readonly InstituicaoRepository _InstituicaoRepository;

        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/<InstituicaoController>
        [HttpGet]
        public List<Instituicao> Get()
        {
            return _InstituicaoRepository.LerTodos();
        }

        // GET api/<InstituicaoController>/5
        [HttpGet("{id}")]
        public Instituicao Get(int id)
        {
            return _InstituicaoRepository.BuscarPorId(id);
        }

        // POST api/<InstituicaoController>
        [HttpPost]
        public Instituicao Post([FromBody] Instituicao instituicao)
        {
            return _InstituicaoRepository.Cadastrar(instituicao);
        }

        // PUT api/<InstituicaoController>/5
        [HttpPut("{id}")]
        public Instituicao Put(int id, [FromBody] Instituicao instituicao)
        {
            return _InstituicaoRepository.Alterar(id, instituicao);
        }

        // DELETE api/<InstituicaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _InstituicaoRepository.Excluir(id);
        }
    }
}
