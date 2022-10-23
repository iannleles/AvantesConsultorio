using Microsoft.EntityFrameworkCore;

namespace GCMAvantes.Infra.Context
{
    public class GCMAvantesContext : DbContext
    {
        public GCMAvantesContext(DbContextOptions<GCMAvantesContext> options) : base(options)
        {

        }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            base.OnModelCreating(modelBuilder);
        }
    }
}
