using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFuncionario.Entities
{
    public class Dependente
    {
        public int DependenteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
