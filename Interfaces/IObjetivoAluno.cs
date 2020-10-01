using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IObjetivoAluno
    {
        ObjetivoAluno Cadastrar(ObjetivoAluno objetivoAluno);

        List<ObjetivoAluno> LerTodos();

        ObjetivoAluno BuscarPorId(int id);
        

        ObjetivoAluno Alterar(int id, ObjetivoAluno objetivoAluno);

        void Excluir(int id);
    }
}
