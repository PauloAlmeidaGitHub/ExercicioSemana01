using System;
using System.Collections.Generic;

namespace ConsoleFuncionario.Entities
{
    public class Funcionario : Pessoa
    {
        public DateTime DataAdmissao { get; set; }
        public List<Dependente> Dependentes { get; set; }
    }

}
