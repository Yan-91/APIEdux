using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface IInstituicao
    {
        Instituicao Cadastrar(Instituicao instituicao);

        List<Instituicao> LerTodos();

        Instituicao BuscarPorId(int id);

        Instituicao Alterar(int id, Instituicao instituicao);

        void Excluir(int id);
    }
}
