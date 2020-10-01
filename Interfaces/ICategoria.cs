using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ICategoria
    {
        Categoria Cadastrar(Categoria categoria);

        List<Categoria> LerTodos();

        Categoria BuscarPorId(int id);

        Categoria Alterar(int id, Categoria categoria);

        void Excluir(int id);
    }
}
