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
    public class CursoRepository : ICurso
    {
        //Conectando com o Banco
        EduxContext conexao = new EduxContext();
        //Trazendo o Comando que vai executar os comando do banco dados
        SqlCommand cmd = new SqlCommand();
        

        public Curso Alterar(int id, Curso curso)
        {
            cmd.Connection = conexao.Conectar();
            //Colocando os Parametros
            cmd.CommandText = "UPDATE Curso SET NomeCurso = @nomecurso WHERE IdCurso = @id";

            cmd.Parameters.AddWithValue("@nomecurso", curso.NomeCurso);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //encerrar Conexão
            conexao.Desconectar();
            return curso;
        }

        public Curso BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //Fazer o Select Por ID
            cmd.CommandText = "SELECT * FROM Curso WHERE IdCurso = @id";
            //Agora mostrar q o @id é igual ao id!
            cmd.Parameters.AddWithValue("@id", id);
            //agora que ja mostramos vamos Executar o comando 
            SqlDataReader dados = cmd.ExecuteReader();

            Curso curso = new Curso();
            while (dados.Read())
            {
                curso.IdCurso = Convert.ToInt32(dados.GetValue(0));
                curso.NomeCurso = dados.GetValue(1).ToString();
                curso.IdInstituicao = Convert.ToInt32(dados.GetValue(2));
            }
            conexao.Desconectar();
            return curso;

        }

        public Curso Cadastrar(Curso curso)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Curso (NomeCurso)" +
                "VALUES" +
                "(@nomecurso)";
            cmd.Parameters.AddWithValue("@nomecurso", curso.NomeCurso);

            //POST = ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            return curso;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            //Exibindo o Id que tem que ser deletado
            cmd.CommandText = "DELETE FROM Curso WHERE IdCurso = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

        }

        public List<Curso> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Curso";

            SqlDataReader dados = cmd.ExecuteReader();
            //Lista para Guardar os Cursos
            List<Curso> cursos = new List<Curso>();
            //Abrindo Laço
            while (dados.Read())
            {
                cursos.Add(
                    new Curso()
                    {
                        IdCurso = Convert.ToInt32(dados.GetValue(0)),
                        NomeCurso = dados.GetValue(1).ToString(),
                        IdInstituicao = Convert.ToInt32(dados.GetValue(2))

                    }
                    );

            }
            //fechar conexão
            conexao.Desconectar();
            return cursos;
        }
    }
}
