using GCMAvantes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GCMAvantes.Infra.Context
{
    public class GCMAvantesContext : DbContext
    {
        public GCMAvantesContext(DbContextOptions<GCMAvantesContext> options) : base(options)
        {

        }
        
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            base.OnModelCreating(modelBuilder);
        }
    }
}
