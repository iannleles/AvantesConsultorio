using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotGO.Web.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<RespostaChat> RespostaChat { get; set; }
    }
}
