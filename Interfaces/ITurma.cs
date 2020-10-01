using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ITurma
    {
        Turma Cadastrar(Turma turma);

        List<Turma> LerTodos();

        Turma BuscarPorId(int id);
       

        Turma Alterar(int id, Turma turma);

        void Excluir(int id);
    }
}
