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

        public ObjetivoAluno Alterar(int id, ObjetivoAluno b)
        {
            cmd.Connection = conexao.Conectar();
            //APLICANDO os parametros
            cmd.CommandText = "UPDATE ObjetivoAluno SET Nota = @nota WHERE IdObjetivoAluno = @id";
            cmd.CommandText = "UPDATE ObjetivoAluno SET DataAlcancado = @dataalcancado WHERE IdObjetivoAluno = @id";

            cmd.Parameters.AddWithValue("@nota", b.Nota);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("dataalcancado", b.DataAlcancado);

            cmd.ExecuteNonQuery();
            //Encerrando conexao
            return b;
        }

        public ObjetivoAluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM ObjetivoAluno WHERE IdObjetivoAluno = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            ObjetivoAluno b = new ObjetivoAluno();
            while (dados.Read())
            {
                b.IdObjetivoAluno = Convert.ToInt32(dados.GetValue(0));
                b.Nota = Convert.ToInt32(dados.GetValue(1));
                b.DataAlcancado = Convert.ToDateTime(dados.GetValue(2));
                b.IdAlunoTurma = Convert.ToInt32(dados.GetValue(3));
            }
            conexao.Desconectar();
            return b;
        }

        public ObjetivoAluno Cadastrar(ObjetivoAluno b)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO ObjetivoAluno (Nota , DataAlcancado)" +
                "VALUES" +
                "(@nota , @dataalcancado)";
           

            cmd.Parameters.AddWithValue("@nota", b.Nota);
            cmd.Parameters.AddWithValue("@dataalcancado", b.DataAlcancado);

            //Post = ExecuteNonQuery
            cmd.ExecuteNonQuery();
            return b;


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
