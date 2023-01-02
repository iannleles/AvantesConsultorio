using GCMAvantes.Application.DTOs;
using GCMAvantes.Application.Interfaces;
using GCMAvantes.Domain.Entities;
using GCMAvantes.Infra.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace GCMAvantes.Application.Applications
{
    public class AgendamentoApplication : IAgendamentoApplication
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public AgendamentoApplication(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public List<AgendamentoDTO> GetAll()
        {
            var agendamentos = _agendamentoRepository.GetAll();
            var resultado = agendamentos.Select(agendamentos => new AgendamentoDTO
            {
                AgendamentoId = agendamentos.Id,
                EspecialidadeId = agendamentos.EspecialidadeId,
                EspecialidadeNome = agendamentos.Especialidade.Nome,
                Data = agendamentos.Data,
                Horario = agendamentos.Horario,
                PacienteNome = agendamentos.Paciente.Nome,
                PacienteId = agendamentos.Paciente.Id,
                EnderecoId = agendamentos.Endereco.Id,
                Excluido = agendamentos.Excluido,
                CriadoEm = agendamentos.CriadoEm,
            }).ToList();

            return resultado;
        }

        public void Insert(AgendamentoDTO agendamentoDTO)
        {
            Agendamento agendamento = new Agendamento();            
            agendamento.Especialidade.Id = agendamentoDTO.EspecialidadeId;
            agendamento.Data = agendamentoDTO.Data;
            agendamento.Horario = agendamentoDTO.Horario;
            agendamento.Paciente = new Paciente
            { 
               Celular = agendamentoDTO.Paciente.Celular,
               CPF = agendamentoDTO.Paciente.CPF,
               DataNascimento = agendamentoDTO.Paciente.DataNascimento,
               Nome = agendamentoDTO.Paciente.Nome,
               RG = agendamentoDTO.Paciente.RG,
               Sobrenome = agendamentoDTO.Paciente.Sobrenome,
               Telefone = agendamentoDTO.Paciente.Telefone,               
            };
            agendamento.Endereco = new Endereco
            {
                Cep = agendamentoDTO.Endereco.Cep,
                Logradouro = agendamentoDTO.Endereco.Logradouro,
                Numero = agendamentoDTO.Endereco.Numero,
                Complemento = agendamentoDTO.Endereco.Complemento,
                Bairro = agendamentoDTO.Endereco.Bairro,
                Cidade = agendamentoDTO.Endereco.Cidade,
                UFSiglaId = agendamentoDTO.Endereco.UFSiglaId,
            };                    
            agendamento.InserirDadosBase();
            _agendamentoRepository.Insert(agendamento);
        }
        public void Update(AgendamentoDTO agendamentoDTO)
        {
            var agendamento = _agendamentoRepository.GetById(agendamentoDTO.AgendamentoId);
            agendamento.Especialidade.Id = agendamento.Especialidade.Id;
            agendamento.Data = agendamentoDTO.Data;
            agendamento.Horario = agendamentoDTO.Horario;
            agendamento.Paciente.Id = agendamentoDTO.PacienteId;
            agendamento.Endereco.Id = agendamentoDTO.Endereco.Id;
            _agendamentoRepository.Update(agendamento);
        }
        public void Delete(int id)
        {
            Agendamento agendamento = _agendamentoRepository.GetById(id);
            _agendamentoRepository.Delete(agendamento);
        }
    }
}
