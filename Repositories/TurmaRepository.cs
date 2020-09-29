using API_Edux.Contexts;
using API_Edux.Domains;
using API_Edux.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Repositories
{
    public class TurmaRepository : ITurma
    {
        EduxContext conexao = new EduxContext();
        SqlCommand cmd = new SqlCommand();
        public Turma Alterar(int id, Turma f)
        {
            throw new NotImplementedException();
        }

        public Turma BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            
        }

        public Turma Cadastrar(Turma f)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Turma> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
