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
    public class CurtidaRepository : ICurtida
    {

        //Ligando Com o Context
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();


        public Curtida Alterar(int id, Curtida curtida)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Curtida SET IdDica = @IdDica WHERE IdCurtida = @id";

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
            //encerrando Conexão
            conexao.Desconectar();
            return curtida;
        }

        public Curtida BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Curtida WHERE IdCurtida = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Curtida curtida = new Curtida();
            while (dados.Read())
            {
                curtida.IdCurtida = Convert.ToInt32(dados.GetValue(0));
                curtida.IdDica = Convert.ToInt32(dados.GetValue(1));
                curtida.IdUsuario = Convert.ToInt32(dados.GetValue(2));
            }
            conexao.Desconectar();
            return curtida;
        }

        public Curtida Cadastrar(Curtida curtida)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Curtida(IdDica)" +
                "VALUES" +
                "(@IdDica)";
            cmd.Parameters.AddWithValue("@IdDica", curtida.IdDica);

            cmd.ExecuteNonQuery();
            return curtida;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Curtida WHERE IdCurtida = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Curtida> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Curtida";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Curtida> curtidas = new List<Curtida>();
            while (dados.Read())
            {
                curtidas.Add(
                    new Curtida()
                    {
                        IdCurtida = Convert.ToInt32(dados.GetValue(0)),
                        IdDica = Convert.ToInt32(dados.GetValue(1)),
                        IdUsuario = Convert.ToInt32(dados.GetValue(2))


                    }

                    );
            }
            conexao.Desconectar();
            return curtidas;
        }
    }
}
