using GCMAvantes.Domain.Entities;
using GCMAvantes.Infra.Context;
using GCMAvantes.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Infra.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly GCMAvantesContext _context;

        public AgendamentoRepository(GCMAvantesContext context)
        {
            _context = context;
        }

        public void Delete(Agendamento agendamento)
        {
            _context.Remove(agendamento);
            _context.SaveChanges();
        }

        public List<Agendamento> GetAll()
        {
            return _context.Agendamentos.ToList();
        }

        public Agendamento GetById(int id)
        {
            return _context.Agendamentos.Find(id);
        }

        public void Insert(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public void Update(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            _context.SaveChanges();
        }

    }
}
