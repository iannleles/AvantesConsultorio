using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Domain.Entities
{
    public class Especialidade : EntityBase
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
