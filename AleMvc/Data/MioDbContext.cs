using System;
using AleMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AleMvc.Data
{
    public partial class MioDbContext : DbContext
    {
        public MioDbContext()
        {
        }

        public MioDbContext(DbContextOptions<MioDbContext> options)
            : base(options)
        {
        }
        public DbSet<Nuoviutenti> Utente { get; set; }
        public DbSet<Lezioni> Lezione { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=alesviluppo\\sqlexpress;Database=ProgettoMvc;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Lezioni>(entity =>
            {
                entity.ToTable("Lezioni");
                entity.HasKey(lezione => lezione.ID);
            });

            modelBuilder.Entity<Nuoviutenti>(entity =>
            {
                entity.ToTable("Utenti");
                entity.HasKey(utente => utente.ID);

                entity.HasMany(utente => utente.Lezione)
                .WithOne(lezione => lezione.utente)
                .HasForeignKey(lezione => lezione.Id_Docente);
            });

        }

        
    }
}
