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
    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        EduxContext conexao = new EduxContext();
        SqlCommand cmd = new SqlCommand();

        public ObjetivoAluno Alterar(int id, ObjetivoAluno objetivoAluno)
        {
            cmd.Connection = conexao.Conectar();
            //APLICANDO os parametros
            cmd.CommandText = "UPDATE ObjetivoAluno SET Nota = @nota WHERE IdObjetivoAluno = @id";
            cmd.CommandText = "UPDATE ObjetivoAluno SET DataAlcancado = @dataalcancado WHERE IdObjetivoAluno = @id";

            cmd.Parameters.AddWithValue("@nota", objetivoAluno.Nota);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("dataalcancado", objetivoAluno.DataAlcancado);

            cmd.ExecuteNonQuery();
            //Encerrando conexao
            return objetivoAluno;
        }

        public ObjetivoAluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM ObjetivoAluno WHERE IdObjetivoAluno = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            ObjetivoAluno objetivoAluno = new ObjetivoAluno();
            while (dados.Read())
            {
                objetivoAluno.IdObjetivoAluno = Convert.ToInt32(dados.GetValue(0));
                objetivoAluno.Nota = Convert.ToInt32(dados.GetValue(1));
                objetivoAluno.DataAlcancado = Convert.ToDateTime(dados.GetValue(2));
                objetivoAluno.IdAlunoTurma = Convert.ToInt32(dados.GetValue(3));
            }
            conexao.Desconectar();
            return objetivoAluno;
        }

        public ObjetivoAluno Cadastrar(ObjetivoAluno objetivoAluno)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO ObjetivoAluno (Nota , DataAlcancado)" +
                "VALUES" +
                "(@nota , @dataalcancado)";
           

            cmd.Parameters.AddWithValue("@nota", objetivoAluno.Nota);
            cmd.Parameters.AddWithValue("@dataalcancado", objetivoAluno.DataAlcancado);

            //Post = ExecuteNonQuery
            cmd.ExecuteNonQuery();
            return objetivoAluno;


        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM ObjetivoAluno WHERE IdObjetivoAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<ObjetivoAluno> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM ObjetivoAluno";


            SqlDataReader dados = cmd.ExecuteReader();
            List<ObjetivoAluno> objetivoAlunos = new List<ObjetivoAluno>();
            while (dados.Read())
            {
                objetivoAlunos.Add(
                    new ObjetivoAluno()
                    {
                        IdObjetivoAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nota = Convert.ToInt32(dados.GetValue(1)),
                        DataAlcancado = Convert.ToDateTime(dados.GetValue(2)),
                        IdAlunoTurma = Convert.ToInt32(dados.GetValue(3)),


                    }



                    );
            }
            conexao.Desconectar();
            return objetivoAlunos;
        }
    }
}
