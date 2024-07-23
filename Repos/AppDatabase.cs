using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SidimEsus.Models;
using System;

namespace SidimEsus.Repos
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string DefaultFormat = "yyyyMMdd";
            var converter = new ValueConverter<DateTime?, int?>(
               v => int.Parse(v.Value.ToString(DefaultFormat)),
               v => DateTime.ParseExact(v.Value.ToString(), DefaultFormat,
                                       System.Globalization.CultureInfo.InvariantCulture)
               );

            modelBuilder.Entity<VisitaDomiciliar>()
              .Property(e => e.Data)
              .HasConversion(converter);

            modelBuilder.Entity<VisitaDomiciliar>()
                .HasOne(e => e.Domicilio)
              .WithMany()
              .HasForeignKey(e => e.CodigoDomicilio)
              .HasPrincipalKey(e => e.Codigo);
              

            modelBuilder.Entity<VisitaDomiciliar>()
                .Navigation(e => e.Domicilio).AutoInclude();
            modelBuilder.Entity<VisitaDomiciliar>()
                .Navigation(e => e.Cidadao).AutoInclude();
            modelBuilder.Entity<VisitaDomiciliar>()
                .Navigation(e => e.Funcionario).AutoInclude();
            modelBuilder.Entity<VisitaDomiciliar>()
                .Navigation(e => e.Estabelecimento).AutoInclude();
        }

        public DbSet<Cidadao> Cidadaos { get; set; }
        public DbSet<VisitaDomiciliar> VisitasDomiciliar { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Cbo> Cbos { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
    }
}
