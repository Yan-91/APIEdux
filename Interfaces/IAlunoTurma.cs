using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IAlunoTurma
    {
         AlunoTurma Cadastrar(AlunoTurma g);

        List<AlunoTurma> LerTodos();

        AlunoTurma BuscarPorId(int id);
       

        AlunoTurma Alterar(int id,AlunoTurma g);

        void Excluir(int id);
    }
}
