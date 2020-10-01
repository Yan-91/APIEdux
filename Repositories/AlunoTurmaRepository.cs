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

        public AlunoTurma Alterar(int id, AlunoTurma alunoTurma)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE AlunoTurma SET Matricula = @matricula WHERE IdAlunoTurma = @id";

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            //encerrando Conexão
            conexao.Desconectar();
            return alunoTurma;
        }

        public AlunoTurma BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM AlunoTurma WHERE IdAlunoTurma = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            AlunoTurma alunoTurma = new AlunoTurma();
            while (dados.Read())
            {
                alunoTurma.IdAlunoTurma = Convert.ToInt32(dados.GetValue(0));
                alunoTurma.Matricula = dados.GetValue(1).ToString();            
                alunoTurma.IdUsuario = Convert.ToInt32(dados.GetValue(2));
                alunoTurma.IdTurma = Convert.ToInt32(dados.GetValue(3));
            }
            conexao.Desconectar();
            return alunoTurma;
        }

        public AlunoTurma Cadastrar(AlunoTurma alunoTurma)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO AlunoTurma(Matricula)" +
                "VALUES" +
                "(Matricula)";
            cmd.Parameters.AddWithValue("@matricula", alunoTurma.Matricula);

            cmd.ExecuteNonQuery();
            return alunoTurma;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM AlunoTurma WHERE IdAlunoTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<AlunoTurma> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM AlunoTurma";

            SqlDataReader dados = cmd.ExecuteReader();
            List<AlunoTurma> alunoturmas = new List<AlunoTurma>();
            while (dados.Read())
            {
                alunoturmas.Add(
                    new AlunoTurma()
                    {
                        IdAlunoTurma = Convert.ToInt32(dados.GetValue(0)),
                        Matricula = dados.GetValue(1).ToString(),
                        IdUsuario = Convert.ToInt32(dados.GetValue(2)),
                        IdTurma = Convert.ToInt32(dados.GetValue(3))


            }

                    );
            }
            conexao.Desconectar();
            return alunoturmas;
        }
    }
}
 