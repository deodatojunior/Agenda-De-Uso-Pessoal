using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Models;

namespace ProjetoIntegrador.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Anotacao> Anotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Lembrete>()
                .Property(p => p.texto)
                .HasMaxLength(10000);

           

            modelBuilder.Entity<Evento>()
                .Property(p => p.descricao)
                .HasMaxLength(10000);



            modelBuilder.Entity<Lembrete>()
                .HasData(
                new Lembrete { id = 1, data = DateTime.Now, texto = "Hoje foi um belo dia, espero que amanhã seja melhor!" },
                new Lembrete { id = 2, data = DateTime.Now, texto = "Hoje foi um dia comum, espero que amanhã seja melhor!" },
                new Lembrete { id = 3, data = DateTime.Now, texto = "Hoje foi um péssimo dia, espero que amanhã seja melhor!" });
        }


        
    }
}
