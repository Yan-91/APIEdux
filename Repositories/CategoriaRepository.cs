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
    public class CategoriaRepository : ICategoria
    {
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();


        public Categoria Alterar(int id, Categoria categoria)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Categoria SET Tipo = @tipo WHERE IdCategoria = @id";

            cmd.Parameters.AddWithValue("@tipo", categoria.Tipo);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return categoria;
        }

        public Categoria BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Categoria WHERE IdCategoria = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Categoria categoria = new Categoria();
            while (dados.Read())
            {
                categoria.IdCategoria = Convert.ToInt32(dados.GetValue(0));
                categoria.Tipo = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return categoria;
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Categoria (Tipo)" +
                "VALUES" +
                "(@tipo)";

            cmd.Parameters.AddWithValue("@tipo", categoria.Tipo);

            cmd.ExecuteNonQuery();
            return categoria;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Categoria WHERE IdCategoria = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Categoria> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Categoria";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Categoria> categorias = new List<Categoria>();

            while (dados.Read())
            {
                categorias.Add(
                    new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dados.GetValue(0)),
                        Tipo = dados.GetValue(1).ToString(),

                    }



                              );




            }
            conexao.Desconectar();
            return categorias;
        }
    }
}
