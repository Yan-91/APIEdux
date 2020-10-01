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
    public class ProfessorTurmaRepository : IProfessorTurma
    {
        //Conectando ao Banco
        EduxContext conexao = new EduxContext();
        //Trazendo o Comando que vai executar os comandos do banco de dados
        SqlCommand cmd = new SqlCommand();

        public ProfessorTurma Alterar(int id, ProfessorTurma professorTurma)
        {
            cmd.Connection = conexao.Conectar();
            //colocando os Paramentros 
            cmd.CommandText = "UPDATE Curso SET Descricao = @descricao WHERE IdCurso = @id";

            cmd.Parameters.AddWithValue("@descricao", professorTurma.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //encerrar Conexão
            conexao.Desconectar();
            return professorTurma;
        }
       


        public ProfessorTurma BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //fazer o select por id
            cmd.CommandText = "SELECT * FROM Curso WHERE IdCurso = @id";
            //agora mostrar q o @id é igual ao id!
            cmd.Parameters.AddWithValue("@id", id);
            //agora que ja mostramos vamos executar o comando
            SqlDataReader dados = cmd.ExecuteReader();

            ProfessorTurma professorTurma = new ProfessorTurma();
            while (dados.Read())

            {
                professorTurma.IdProfessorTurma = Convert.ToInt32(dados.GetValue(0));
                professorTurma.Descricao = dados.GetValue(1).ToString();
                professorTurma.IdTurma = Convert.ToInt32(dados.GetValue(2));
                professorTurma.IdUsuario = Convert.ToInt32(dados.GetValue(3));

            }
            conexao.Desconectar();
            return professorTurma;



         }
        public ProfessorTurma Cadastrar(ProfessorTurma professorTurma)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO ProfessorTurma(Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", professorTurma.Descricao);

            cmd.ExecuteNonQuery();
            return professorTurma;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM ProfessorTurma WHERE IdProfessorTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<ProfessorTurma> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM ProfessorTurma";

            SqlDataReader dados = cmd.ExecuteReader();
            List<ProfessorTurma> professorturmas = new List<ProfessorTurma>();
            while (dados.Read())
            {
                professorturmas.Add(
                    new ProfessorTurma()
                    {
                        IdProfessorTurma = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTurma = Convert.ToInt32(dados.GetValue(2)),
                        IdUsuario = Convert.ToInt32(dados.GetValue(3))

            }

                    );
            }
            conexao.Desconectar();
            return professorturmas;
        }
    }
}
    