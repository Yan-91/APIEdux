﻿using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ICurtida
    {
        Curtida Cadastrar(Curtida curtida);

        List<Curtida> LerTodos();

        Curtida BuscarPorId(int id);


        Curtida Alterar(int id, Curtida curtida);

        void Excluir(int id);
    }
}
