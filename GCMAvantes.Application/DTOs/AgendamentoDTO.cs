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
        public int EspecialidadeId { get; set; }
        public string EspecialidadeNome { get; set; }

        public string PacienteNome { get; set; }

        public int PacienteId { get; set; }

        public Paciente Paciente {get; set; }
        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }        

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }     
        
         public DateTime CriadoEm { get; set; }

        public bool Excluido { get; set; }
    }
}
