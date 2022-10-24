using GCMAvantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Application.DTOs
{
    public class AgendamentoDTO
    {
        public int AgendamentoId { get; set; }
        public Especialidade Especialidade { get; set; }

        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }

        public Paciente Paciente { get; set; }

        public Endereco Endereco { get; set; }
    }
}
