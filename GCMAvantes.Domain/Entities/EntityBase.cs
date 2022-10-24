using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime CriadoEm { get; set; }

        public bool Excluido { get; set; }

        public void InserirDadosBase()
        {
            CriadoEm = DateTime.Now;
            Excluido = false;
        }
    }
}
