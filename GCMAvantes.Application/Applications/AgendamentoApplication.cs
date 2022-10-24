﻿using GCMAvantes.Application.DTOs;
using GCMAvantes.Application.Interfaces;
using GCMAvantes.Domain.Entities;
using GCMAvantes.Infra.Interfaces;

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
            List<Agendamento> agendamentos = _agendamentoRepository.GetAll();
            return agendamentos.Select(agendamentos => new AgendamentoDTO
            {
                Especialidade = new Especialidade
                {
                    Id = agendamentos.Especialidade.Id,
                    Nome = agendamentos.Especialidade.Nome
                },
                Data = agendamentos.Data,
                Horario = agendamentos.Horario,
                Paciente = new Paciente
                {
                    Nome = agendamentos.Paciente.Nome,
                    Sobrenome = agendamentos.Paciente.Sobrenome,
                    RG = agendamentos.Paciente.RG,
                    CPF = agendamentos.Paciente.CPF,
                    DataNascimento = agendamentos.Paciente.DataNascimento,
                    Telefone = agendamentos.Paciente.Telefone,
                    Celular = agendamentos.Paciente.Celular,
                },
                Endereco = new Endereco
                {
                    Cep = agendamentos.Endereco.Cep,
                    Logradouro = agendamentos.Endereco.Logradouro,
                    Numero = agendamentos.Endereco.Numero,
                    Complemento = agendamentos.Endereco.Complemento,
                    Bairro = agendamentos.Endereco.Bairro,
                    Cidade = agendamentos.Endereco.Cidade,
                    UFSiglaId = agendamentos.Endereco.UFSiglaId,
                }
            }).ToList();            
        }

        public void Insert(AgendamentoDTO agendamentoDTO)
        {

            var agendamento = new Agendamento
            {

                Especialidade = new Especialidade
                {
                    Id = agendamentoDTO.Especialidade.Id,
                    Nome = agendamentoDTO.Especialidade.Nome
                },                
                Data = agendamentoDTO.Data,
                Horario = agendamentoDTO.Horario,
                Paciente = new Paciente
                {
                    Nome = agendamentoDTO.Paciente.Nome,
                    Sobrenome = agendamentoDTO.Paciente.Sobrenome,
                    RG = agendamentoDTO.Paciente.RG,
                    CPF = agendamentoDTO.Paciente.CPF,
                    DataNascimento = agendamentoDTO.Paciente.DataNascimento,
                    Telefone = agendamentoDTO.Paciente.Telefone,
                    Celular = agendamentoDTO.Paciente.Celular,
                },
                Endereco = new Endereco
                {
                    Cep = agendamentoDTO.Endereco.Cep,
                    Logradouro = agendamentoDTO.Endereco.Logradouro,
                    Numero = agendamentoDTO.Endereco.Numero,
                    Complemento = agendamentoDTO.Endereco.Complemento,
                    Bairro = agendamentoDTO.Endereco.Bairro,
                    Cidade = agendamentoDTO.Endereco.Cidade,
                    UFSiglaId = agendamentoDTO.Endereco.UFSiglaId,
                }               
            };
           
           
            agendamento.InserirDadosBase();
            _agendamentoRepository.Insert(agendamento);
        }

        public void Update(AgendamentoDTO agendamentoDTO)
        {
            var agendamento = _agendamentoRepository.GetById(agendamentoDTO.AgendamentoId);

            agendamento.Especialidade = new Especialidade
            {
                Id = agendamentoDTO.Especialidade.Id,
                Nome = agendamentoDTO.Especialidade.Nome
            };
            agendamento.Data = agendamentoDTO.Data;
            agendamento.Horario = agendamentoDTO.Horario;
            agendamento.Paciente = new Paciente
            {
                Nome = agendamentoDTO.Paciente.Nome,
                Sobrenome = agendamentoDTO.Paciente.Sobrenome,
                RG = agendamentoDTO.Paciente.RG,
                CPF = agendamentoDTO.Paciente.CPF,
                DataNascimento = agendamentoDTO.Paciente.DataNascimento,
                Telefone = agendamentoDTO.Paciente.Telefone,
                Celular = agendamentoDTO.Paciente.Celular,
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

            _agendamentoRepository.Update(agendamento);
        }

        public void Delete(int id)
        {
            Agendamento agendamento = _agendamentoRepository.GetById(id);
            _agendamentoRepository.Delete(agendamento);
        }
    }
}
