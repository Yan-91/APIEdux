using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IDica
    {
        Dica Cadastrar(Dica dica);

        List<Dica> LerTodos();

        Dica BuscarPorId(int id);

        Dica Alterar(int id, Dica dica);

        void Excluir(int id);
    }
}
