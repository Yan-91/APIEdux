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

        public Instituicao Alterar(int id, Instituicao i)
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

            cmd.Parameters.AddWithValue("@nome", i.Nome);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@logradouro", i.Logradouro);
            cmd.Parameters.AddWithValue("@numero", i.Numero);
            cmd.Parameters.AddWithValue("@complemento", i.Complemento);
            cmd.Parameters.AddWithValue("@bairro", i.Bairro);
            cmd.Parameters.AddWithValue("@cidade", i.Cidade);
            cmd.Parameters.AddWithValue("@uf", i.Uf);
            cmd.Parameters.AddWithValue("cep", i.Cep);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            return i;
        }

        public Instituicao BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Instituicao WHERE IdInstituicao =@id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Instituicao i = new Instituicao();
            while (dados.Read())
            {
                i.IdInstituicao = Convert.ToInt32(dados.GetValue(0));
                i.Nome = dados.GetValue(1).ToString();
                i.Logradouro = dados.GetValue(2).ToString();
                i.Numero = dados.GetValue(3).ToString();
                i.Complemento = dados.GetValue(4).ToString();
                i.Bairro = dados.GetValue(5).ToString();
                i.Cidade = dados.GetValue(6).ToString();
                i.Uf = dados.GetValue(7).ToString();
                i.Cep = dados.GetValue(8).ToString();




            }
            conexao.Desconectar();
            //return
            return i;




        }

        public Instituicao Cadastrar(Instituicao i)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText =
                "INSERT INTO Instituicao (Nome)" +
                "VALUES" +
                "(@nome)";
            cmd.CommandText =
                "INSERT INTO Instituicao (Logradouro)" +
                "VALUES" +
                "(@logradouro)";
            cmd.CommandText =
                "INSERT INTO Instituicao (Numero)" +
                "VALUES" +
                "(@numero)";
            cmd.CommandText =
                "INSERT INTO Instituicao(Complemento)" +
                "VALUES" +
                "(@complemento)";
            cmd.CommandText =
                "INSERT INTO Instituicao(Bairro) " +
                "VALUES" +
                "(@bairro)";
            cmd.CommandText =
                "INSERT INTO Instituicao(Cidade)" +
                "VALUES" +
                "(@cidade)";
            cmd.CommandText =
                "INSERT INTO Instituicao(Uf)" +
                "VALUES" +
                "(@uf)";
            cmd.CommandText =
                "INSERT INTO Instituicao(Cep)" +
                "VALUES" +
                "(@cep)";
            cmd.Parameters.AddWithValue("@nome", i.Nome);
            cmd.Parameters.AddWithValue("@logradouro", i.Logradouro);
            cmd.Parameters.AddWithValue("@numero", i.Numero);
            cmd.Parameters.AddWithValue("@complemento", i.Complemento);
            cmd.Parameters.AddWithValue("@bairro", i.Bairro);
            cmd.Parameters.AddWithValue("@cidade", i.Cidade);
            cmd.Parameters.AddWithValue("@uf", i.Uf);
            cmd.Parameters.AddWithValue("@cep", i.Cep);

            cmd.ExecuteNonQuery();
            return i;

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
