﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Application.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public int UFSiglaId { get; set; }        

        public string Cidade { get; set; }

    }
}
