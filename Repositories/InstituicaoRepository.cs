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
    public class InstituicaoRepository : IInstituicao
    {
        //ligando Com o banco
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public Instituicao Alterar(int id, Instituicao instituicao)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Instituicao SET Nome = @nome WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Logradouro = @logradouro WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Numero = @numero WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Complemento = @complemento WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Bairro = @bairro WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Cidade = @cidade WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Uf = @uf WHERE IdInstituicao = @id";
            cmd.CommandText = "UPDATE Instituicao SET Cep = @cep WHERE IdInstituicao = @id";

            cmd.Parameters.AddWithValue("@nome", instituicao.Nome);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@logradouro", instituicao.Logradouro);
            cmd.Parameters.AddWithValue("@numero", instituicao.Numero);
            cmd.Parameters.AddWithValue("@complemento", instituicao.Complemento);
            cmd.Parameters.AddWithValue("@bairro", instituicao.Bairro);
            cmd.Parameters.AddWithValue("@cidade", instituicao.Cidade);
            cmd.Parameters.AddWithValue("@uf", instituicao.Uf);
            cmd.Parameters.AddWithValue("cep", instituicao.Cep);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            return instituicao;
        }

        public Instituicao BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Instituicao WHERE IdInstituicao =@id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Instituicao instituicao = new Instituicao();
            while (dados.Read())
            {
                instituicao.IdInstituicao = Convert.ToInt32(dados.GetValue(0));
                instituicao.Nome = dados.GetValue(1).ToString();
                instituicao.Logradouro = dados.GetValue(2).ToString();
                instituicao.Numero = dados.GetValue(3).ToString();
                instituicao.Complemento = dados.GetValue(4).ToString();
                instituicao.Bairro = dados.GetValue(5).ToString();
                instituicao.Cidade = dados.GetValue(6).ToString();
                instituicao.Uf = dados.GetValue(7).ToString();
                instituicao.Cep = dados.GetValue(8).ToString();




            }
            conexao.Desconectar();
            //return
            return instituicao;




        }

        public Instituicao Cadastrar(Instituicao instituicao)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText =
                "INSERT INTO Instituicao (Nome, Logradouro, Numero, Complemento , Bairro, Cidade, Uf, Cep)" +
                "VALUES" +
                "(@nome, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep)";
            
            cmd.Parameters.AddWithValue("@nome", instituicao.Nome);
            cmd.Parameters.AddWithValue("@logradouro", instituicao.Logradouro);
            cmd.Parameters.AddWithValue("@numero", instituicao.Numero);
            cmd.Parameters.AddWithValue("@complemento", instituicao.Complemento);
            cmd.Parameters.AddWithValue("@bairro", instituicao.Bairro);
            cmd.Parameters.AddWithValue("@cidade", instituicao.Cidade);
            cmd.Parameters.AddWithValue("@uf", instituicao.Uf);
            cmd.Parameters.AddWithValue("@cep", instituicao.Cep);

            cmd.ExecuteNonQuery();
            return instituicao;

        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            //exibindo o id que tem que ser deletado
            cmd.CommandText = "DELETE FROM Instituicao WHERE IdInstituicao = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public List<Instituicao> LerTodos()
        {
            //conexão
            cmd.Connection = conexao.Conectar();
            //Comando que ligara com o banco
            cmd.CommandText = "SELECT FROM Instituicao";

            SqlDataReader dados = cmd.ExecuteReader();
            List<Instituicao> instituicaos = new List<Instituicao>();

            while (dados.Read())
            {
                instituicaos.Add(
                                  new Instituicao
                                  {
                                      IdInstituicao = Convert.ToInt32(dados.GetValue(0)),
                                      Nome = dados.GetValue(1).ToString(),
                                      Logradouro = dados.GetValue(2).ToString(),
                                      Numero = dados.GetValue(3).ToString(),
                                      Complemento = dados.GetValue(4).ToString(),
                                      Bairro = dados.GetValue(5).ToString(),
                                      Cidade = dados.GetValue(6).ToString(),
                                      Uf = dados.GetValue(7).ToString(),
                                      Cep = dados.GetValue(8).ToString(),


                                  }

                   );

            }
            conexao.Desconectar();
            return instituicaos;
        }
    }
}
