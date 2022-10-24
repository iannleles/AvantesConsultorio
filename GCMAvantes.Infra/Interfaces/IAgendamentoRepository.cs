using GCMAvantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Infra.Interfaces
{
    public interface IAgendamentoRepository
    {
        List<Agendamento> GetAll();
        void Insert(Agendamento agendamentoDTO);

        void Update(Agendamento agendamentoDTO);

        void Delete(Agendamento id);

        Agendamento GetById(int id);
    }
}
