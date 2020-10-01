using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IAlunoTurma
    {
         AlunoTurma Cadastrar(AlunoTurma alunoTurma);

        List<AlunoTurma> LerTodos();

        AlunoTurma BuscarPorId(int id);
       

        AlunoTurma Alterar(int id,AlunoTurma alunoTurma);

        void Excluir(int id);
    }
}
