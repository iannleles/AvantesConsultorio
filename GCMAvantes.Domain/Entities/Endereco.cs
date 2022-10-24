using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public int UFSiglaId { get; set; }

        public UF UFSigla { get; set; }

        public string Cidade { get; set; }

    }
}
