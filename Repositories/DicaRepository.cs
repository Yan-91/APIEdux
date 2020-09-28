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
    public class DicaRepository : IDica
    {
        //Conexão com o banco
        EduxContext conexao = new EduxContext();
        //chamando o comando
        SqlCommand cmd = new SqlCommand();
        
        public Dica Alterar(int id, Dica d)
        {
            throw new NotImplementedException();
        }

        public Dica BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //select por ID
            cmd.CommandText = "SELECT * FROM Dica WHERE IdDica = @id";

            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dados = cmd.ExecuteReader();

            Dica d = new Dica();
            while (dados.Read())
            {
                d.IdDica = Convert.ToInt32(dados.GetValue(0));
                d.Texto = dados.GetValue(1).ToString();
                d.Imagem = (Microsoft.AspNetCore.Http.IFormFile)dados.GetStream(2);
                d.UrlImagem = dados.GetValue(3).ToString();
                d.IdUsuario = Convert.ToInt32(dados.GetValue(4));

            }
            conexao.Desconectar();
            return d;
        }

        public Dica Cadastrar(Dica d)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Dica (Texto)" +
                "VALUES" +
                "(@texto)";
            cmd.Parameters.AddWithValue("@texto", d.Texto);

            //POST = ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            return d;

        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dica> LerTodos()
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT FROM Dica";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Dica> dicas = new List<Dica>();
            while (dados.Read())
            {
                dicas.Add(
                    new Dica()
                    {
                        IdDica = Convert.ToInt32(dados.GetValue(0)),
                        Texto = dados.GetValue(1).ToString(),
                        Imagem = (Microsoft.AspNetCore.Http.IFormFile)dados.GetStream(2),
                        UrlImagem = dados.GetValue(3).ToString(),
                        IdUsuario = Convert.ToInt32(dados.GetValue(4)),
                    }




                    );

            }
            conexao.Desconectar();
            return dicas;
        }
    }
}
