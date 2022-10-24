using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Domain.Entities 
{ 
    public class Paciente : EntityBase
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }


    }
}
