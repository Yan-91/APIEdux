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
    public class PerfilController : ControllerBase
    {
        private readonly PerfilRepository _PerfilRepository;

        public PerfilController()
        {
            _PerfilRepository = new PerfilRepository();
        }
        // GET: api/<PerfilController>
        [HttpGet]
        public List<Perfil> Get()
        {
            return _PerfilRepository.LerTodos();
        }

        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public Perfil Get(int id)
        {
            return _PerfilRepository.BuscarPorId(id);
        }

        // POST api/<PerfilController>
        [HttpPost]
        public Perfil Post([FromBody] Perfil perfil)
        {
            return _PerfilRepository.Cadastrar(perfil);
        }

        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public Perfil Put(int id, [FromBody] Perfil perfil)
        {
            return _PerfilRepository.Alterar(id, perfil);
        }

        // DELETE api/<PerfilController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _PerfilRepository.Excluir(id);
        }
    }
}
