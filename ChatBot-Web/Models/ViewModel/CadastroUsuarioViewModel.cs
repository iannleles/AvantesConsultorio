using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot_Web.Models.ViewModel
{
    public class CadastroUsuarioViewModel
    {
        public int UsuarioId { get; set; }

        public int PerfilId { get; set; }

        public Endereco Endereco { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

    }
}
