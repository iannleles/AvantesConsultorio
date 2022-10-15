using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Models.ViewModel
{
    public class UsuarioPerfilViewModel
    {
        public string UsuarioId { get; set; }
        public string NomeUsuario { get; set; }        
        public string Email { get; set; }
        public IEnumerable<string> Perfis { get; set; }
    }
}
