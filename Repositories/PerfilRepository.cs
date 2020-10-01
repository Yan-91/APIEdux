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
    public class PerfilRepository : IPerfil
    {
        EduxContext conexao = new EduxContext();
        SqlCommand cmd = new SqlCommand();

        public Perfil Alterar(int id, Perfil perfil)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Perfil SET Permissao = @permissao WHERE IdPerfil = @id";

            cmd.Parameters.AddWithValue("@permissao", perfil.Permissao);

            cmd.ExecuteNonQuery();

            return perfil;
        }

        public Perfil BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Perfil WHERE IdPerfil = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            Perfil perfil = new Perfil();
            while (dados.Read())
            {
                perfil.IdPerfil = Convert.ToInt32(dados.GetValue(0));
                perfil.Permissao = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return perfil;
        }

        public Perfil Cadastrar(Perfil perfil)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Perfil(Permissao)" +
                "VALUES" +
                "(@permissao)";

            cmd.Parameters.AddWithValue("@permissao", perfil.Permissao);

            cmd.ExecuteNonQuery();
            return perfil;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Perfil WHERE IdPerfil = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Perfil> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Perfil";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Perfil> perfils = new List<Perfil>();

            while (dados.Read())
            {
                perfils.Add(
                    new Perfil()
                    {
                        IdPerfil = Convert.ToInt32(dados.GetValue(0)),
                        Permissao = dados.GetValue(1).ToString(),

                    }



                 );

            }
            conexao.Desconectar();
            return perfils;
        }
    }
}
