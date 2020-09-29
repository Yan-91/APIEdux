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

        public Perfil Alterar(int id, Perfil a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Perfil SET Permiisao = @permissao WHERE IdPerfil = @id";

            cmd.Parameters.AddWithValue("@permissao", a.Permissao);

            cmd.ExecuteNonQuery();

            return a;
        }

        public Perfil BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Perfil WHERE IdPerfil = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            Perfil a = new Perfil();
            while (dados.Read())
            {
                a.IdPerfil = Convert.ToInt32(dados.GetValue(0));
                a.Permissao = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return a;
        }

        public Perfil Cadastrar(Perfil a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Perfil(Permissao)" +
                "VALUES" +
                "(@permissao)";

            cmd.Parameters.AddWithValue("@permissao", a.Permissao);

            cmd.ExecuteNonQuery();
            return a;
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
