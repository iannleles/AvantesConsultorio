﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCMAvantes.Domain.Entities
{
    public class Agendamento : EntityBase
    {    
        public virtual int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }        
        public Paciente Paciente { get; set; }
        public Endereco Endereco { get; set; }        

    }
}
