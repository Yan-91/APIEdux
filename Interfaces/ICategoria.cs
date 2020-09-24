using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ICategoria
    {
        Categoria Cadastrar(Categoria c);

        List<Categoria> LerTodos();

        Categoria BuscarPorId(int id);

        Categoria Alterar(Categoria c);

        void Excluir(int id);
    }
}
