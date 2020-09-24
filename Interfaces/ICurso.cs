using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ICurso
    {
        Curso Cadastrar(Curso k);

        List<Curso> LerTodos();

        Curso BuscarPorId(int id);

        Curso Alterar(Curso k);

        void Excluir(int id);
    }
}
