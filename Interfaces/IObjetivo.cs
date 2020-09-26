using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IObjetivo
    {
        Objetivo Cadastrar(Objetivo h);

        List<Objetivo> LerTodos();

        Objetivo BuscarPorId(int id);
        

        Objetivo Alterar(int id, Objetivo h);

        void Excluir(int id);
    }
}
