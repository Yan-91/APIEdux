using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IUsuario
    {
        Usuario Cadastrar(Usuario j);

        List<Usuario> LerTodos();

        Usuario BuscarPorId(int id);

        Usuario Alterar(Usuario j);

        void Excluir(int id);
    }
}
