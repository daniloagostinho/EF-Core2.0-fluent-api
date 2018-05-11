using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Planeta> Planetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=CEDRONOTE-01; Initial Catalog=UniversoDB; Trusted_Connection=True;"
           );
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // crio a tabela Galaxias e defino um maxleng para aceitar apenas 100 caracteres
            mb.Entity<Galaxia>()
                .ToTable("Galaxias")
                .Property(g => g.Nome).HasMaxLength(100);

            // crio a tabela Planetas e defino um maxleng para aceitar apenas 100 caracteres
            mb.Entity<Planeta>()
                .ToTable("Planetas")
                .Property(g => g.Nome).HasMaxLength(100);

            // defino o relacionamento das tabelas
            // planeta tem uma galaxia
            mb.Entity<Planeta>()
                .HasOne(g => g.Galaxia)
                .WithOne(p => p.Planeta);

            mb.Entity<BuracoNegro>()
                .ToTable("BuracosNegros")
                .Property(g => g.Nome).HasMaxLength(100);

            // definir o reçacionamento um para muitos
            // uma galaxia tem um buraco, e buraco negro tem muitas galaxiass
            mb.Entity<BuracoNegro>()
                .HasOne(g => g.Galaxia)
                .WithMany(bn => bn.BuracoNegros);
        }
    }
}
