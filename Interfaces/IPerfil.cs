using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IPerfil
    {
        Perfil Cadastrar(Perfil perfil);

        List<Perfil> LerTodos();

        Perfil BuscarPorId(int id);
        

        Perfil Alterar(int id, Perfil perfil);

        void Excluir(int id);
    }
}
