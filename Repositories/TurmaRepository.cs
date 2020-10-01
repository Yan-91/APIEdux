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
        //Ligando com o Context

        EduxContext conexao = new EduxContext();
        SqlCommand cmd = new SqlCommand();
        public Turma Alterar(int id, Turma turma)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Turma SET Descricao = @descricao WHERE IdTurma = @id";

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            //Encerrando Conexão

            conexao.Desconectar();
            return turma;
        }

        public Turma BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Turma WHERE IdTurma = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Turma turma = new Turma();
            while (dados.Read())
            {
                turma.IdTurma = Convert.ToInt32(dados.GetValue(0));
                turma.Descricao = dados.GetValue(1).ToString();
                turma.IdCurso = Convert.ToInt32(dados.GetValue(2));
            }
            //dados.GetValue(1).ToString();

            conexao.Desconectar();
            return turma;
            

        }

        public Turma Cadastrar(Turma turma)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Turma(Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", turma.Descricao);

            cmd.ExecuteNonQuery();
            return turma;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Turma WHERE IdTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Turma> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Turma";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Turma> turmas = new List<Turma>();
            while (dados.Read())
            {
                turmas.Add(
                    new Turma()
                    {
                        IdTurma = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdCurso = Convert.ToInt32(dados.GetValue(2))
                    }

                    );
            }
            conexao.Desconectar();
            return turmas;
        }
    }
}
    
