using GCMAvantes.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Application.Interfaces
{
    public interface IAgendamentoApplication
    {      
        List<AgendamentoDTO> GetAll();
        void Insert(AgendamentoDTO agendamentoDTO);
        void Update(AgendamentoDTO agendamentoDTO);
        void Delete(int id);
       
    }
}
