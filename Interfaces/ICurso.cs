﻿using API_Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Interfaces
{
    interface ICurso
    {
        Curso Cadastrar(Curso curso);

        List<Curso> LerTodos();

        Curso BuscarPorId(int id);


        Curso Alterar(int id, Curso curso);

        void Excluir(int id);
    }
}
