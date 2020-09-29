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

        public ProfessorTurma Alterar(int id, ProfessorTurma e)
        {
            cmd.Connection = conexao.Conectar();
            //colocando os Paramentros 
            cmd.CommandText = "UPDATE Curso SET Descricao = @descricao WHERE IdCurso = @id";

            cmd.Parameters.AddWithValue("@descricao", e.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //encerrar Conexão
            conexao.Desconectar();
            return e;
        }
        //Cauê vou te passar o Link para vc ver as tabelas https://classroom.google.com/u/0/c/MTI4MjM4NDQyMjY1/a/MTcxNTA2MzQxNjc0/details entra ae e ve a tabela certa


        public ProfessorTurma BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //fazer o select por id
            cmd.CommandText = "SELECT * FROM Curso WHERE IdCurso = @id";
            //agora mostrar q o @id é igual ao id!
            cmd.Parameters.AddWithValue("@id", id);
            //agora que ja mostramos vamos executar o comando
            SqlDataReader dados = cmd.ExecuteReader();

            ProfessorTurma e = new ProfessorTurma();
            while (dados.Read())

            {

                e.IdTurma = Convert.ToInt32(dados.GetValue(0));
                e.Descricao = dados.GetValue(1).ToString();
                e.IdUsuario = Convert.ToInt32(dados.GetValue(2));

            }
            conexao.Desconectar();
            return e;



         }
        public ProfessorTurma Cadastrar(ProfessorTurma e)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorTurma> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
