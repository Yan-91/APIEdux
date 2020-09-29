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
    public class AlunoTurmaRepository : IAlunoTurma
    {

        //Ligando Com o Context
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public AlunoTurma Alterar(int id, AlunoTurma g)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE AlunoTurma SET Matricula = @matricula WHERE IdCurtida = @id";

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            //encerrando Conexão
            conexao.Desconectar();
            return g;
        }

        public AlunoTurma BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public AlunoTurma Cadastrar(AlunoTurma g)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlunoTurma> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
