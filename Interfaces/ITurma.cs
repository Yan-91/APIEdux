using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ITurma
    {
        Turma Cadastrar(Turma f);

        List<Turma> LerTodos();

        Turma BuscarPorId(int id);
       

        Turma Alterar(int id, Turma f);

        void Excluir(int id);
    }
}
