using API_Edux.Domains;
using API_Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;

namespace API_Edux.Repositories
{
    public class UsuarioRepository : IUsuario
    {
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

        public Usuario Alterar(int id, Usuario j)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Cadastrar(Usuario j)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
