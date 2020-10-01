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
    public class ObjetivoRepository : IObjetivo
    {
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public Objetivo Alterar(int id, Objetivo objetivo)
        {
            cmd.Connection = conexao.Conectar();
            //Aplicando os parametros
            cmd.CommandText = "UPDATE Objetivo SET Descricao = @descricao WHERE IdObjetivo = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", objetivo.Descricao);

            cmd.ExecuteNonQuery();

            return objetivo;
        }

        public Objetivo BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Objetivo WHERE IdObjetivo = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            Objetivo objetivo = new Objetivo();
            while (dados.Read())
            {
                objetivo.IdObjetivo = Convert.ToInt32(dados.GetValue(0));
                objetivo.Descricao = dados.GetValue(1).ToString();
                objetivo.IdCategoria = Convert.ToInt32(dados.GetValue(2));
            }
            conexao.Desconectar();
            return objetivo;


        }

        public Objetivo Cadastrar(Objetivo objetivo)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Objetivo (Descricao)" +
                "VALUES" +
                "(@descricao)";

            cmd.Parameters.AddWithValue("@descricao", objetivo.Descricao);

            //executeNONQUERY
            cmd.ExecuteNonQuery();
            return objetivo;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Objetivo WHERE IdObjetivo = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Objetivo> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Objetivo";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Objetivo> objetivos = new List<Objetivo>();

            while (dados.Read())
            {
                objetivos.Add(
                    new Objetivo()
                    {
                        IdObjetivo = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdCategoria = Convert.ToInt32(dados.GetValue(2)),





                    }





                             );



            }
            conexao.Desconectar();
            return objetivos;
        }
    }
}
