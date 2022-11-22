using GCMAvantes.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCMAvantes.Infra.Context
{
    public class GCMAvantesContext : IdentityDbContext
    {
        public GCMAvantesContext(DbContextOptions<GCMAvantesContext> options) : base(options)
        {

        }
        
        public DbSet<Agendamento> Agendamentos { get; set; }        
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<RespostaChat> RespostaChat { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            base.OnModelCreating(modelBuilder);
        }
    }
}
