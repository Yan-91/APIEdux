using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IProfessorTurma
    {
        ProfessorTurma Cadastrar(ProfessorTurma professorTurma);

        List<ProfessorTurma> LerTodos();

        ProfessorTurma BuscarPorId(int id);
       

        ProfessorTurma Alterar(int id, ProfessorTurma professorTurma);


        void Excluir(int id);
    }
}
