using GCMAvantes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Infra.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sobrenome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x=>x.DataNascimento)                
                .IsRequired();

            builder.Property(x=>x.Celular)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .IsRequired();

            builder.Property(x => x.RG)
                .IsRequired();
        }
    }
}
