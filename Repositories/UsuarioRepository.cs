using API_Edux.Contexts;
using API_Edux.Domains;
using API_Edux.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_Edux.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        EduxContext conexao = new EduxContext();
        SqlCommand cmd = new SqlCommand();
        static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }

            return hash;
        }


        public Usuario Alterar(int id, Usuario usuario)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Alterar SET Nome = @nome WHERE IdUsuario = @id";
            

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            //Encerrando Conexão

            conexao.Desconectar();
            return usuario;
        }

        public Usuario BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Usuario WHERE IdUsuario = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Usuario usuario = new Usuario();
            while (dados.Read())
            {
                usuario.IdUsuario = Convert.ToInt32(dados.GetValue(0));
                usuario.Email = dados.GetValue(1).ToString();
                usuario.Senha = dados.GetValue(2).ToString();
                usuario.DataUltimoAcesso = Convert.ToDateTime(dados.GetSqlDateTime(3));
                usuario.DataCadastro = Convert.ToDateTime(dados.GetSqlDateTime(4));
            }
            //dados.GetValue(1).ToString();

            conexao.Desconectar();
            return usuario;

        }

        public Usuario Cadastrar(Usuario usuario)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText =
                "INSERT INTO Usuario (Nome, Email, Senha,  DataUltimoAcesso, DataCadastro)" +
                "VALUES" +
                "(@nome, @email, @senha, @dataultimoacesso, @datacadastro)";
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@dataultimoacesso", usuario.DataUltimoAcesso);
            cmd.Parameters.AddWithValue("@datacadastro", usuario.DataCadastro);

            cmd.ExecuteNonQuery();
            return usuario;

        }


        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            //exibindo o id que tem que ser deletado
            cmd.CommandText = "DELETE FROM Usuario WHERE IdUsuario = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Usuario> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Usuario";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Usuario> usuarios = new List<Usuario>();
            while (dados.Read())
            {
                usuarios.Add(
                    new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dados.GetValue(0)),
                        Email = dados.GetValue(1).ToString(),
                        Senha = dados.GetValue(2).ToString(),
                        DataUltimoAcesso = Convert.ToDateTime(dados.GetSqlDateTime(3)),
                DataCadastro = Convert.ToDateTime(dados.GetSqlDateTime(4)),
            }




                    );

            }
            conexao.Desconectar();
            return usuarios;
        }
    }
}
