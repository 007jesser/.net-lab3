using Microsoft.EntityFrameworkCore;
using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AM.ApplicationCore.Domain.Bilan;

namespace AM.Infrastructure
{
    public class R1Context : DbContext
    {
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Bilan> Bilans { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }
        public DbSet<Laboratoire> Laboratoires { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                            Initial Catalog=MohamedOuerfelliRendu1;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laboratoire>()
                .Property(l => l.Localisation)
                .HasColumnName("AdresseLabo")
                .HasMaxLength(50);

            modelBuilder.ApplyConfiguration(new BilanConfiguration());
        }

    }
}
