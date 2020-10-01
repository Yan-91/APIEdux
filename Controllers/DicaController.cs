using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_Edux.Domains;
using API_Edux.Repositories;
using API_Edux.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {

        private readonly DicaRepository _DicaRepository;

        public DicaController()
        {
            _DicaRepository = new DicaRepository();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<Dica> Get()
        {
            return _DicaRepository.LerTodos();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Dica Get(int id)
        {
            return _DicaRepository.BuscarPorId(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Dica Post([FromForm] Dica dica)
        {
            if (dica.Imagem != null)
            {
                var urlImagem = Upload.Local(dica.Imagem);

                dica.UrlImagem = urlImagem;
            }
            return _DicaRepository.Cadastrar(dica);

            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Dica Put(int id, [FromBody] Dica dica)
        {
            return _DicaRepository.Alterar(id, dica);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _DicaRepository.Excluir(id);
        }
    }
}
