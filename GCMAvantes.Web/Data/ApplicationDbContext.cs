using GCMAvantes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCMAvantes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<RespostaChat> RespostaChat { get; set; }

    }
}
