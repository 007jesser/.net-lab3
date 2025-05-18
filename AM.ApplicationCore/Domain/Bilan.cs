using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }
        public ICollection<Analyse> Analyses { get; set; }
        public int CodeInfirmier { get; set; }
        public Infirmier Infirmier { get; set; }

        public int CodePatient { get; set; }
        public Patient Patient { get; set; }

        public class BilanConfiguration : IEntityTypeConfiguration<Bilan>
        {
            public void Configure(EntityTypeBuilder<Bilan> builder)
            {
                builder.HasKey(b => new { b.CodeInfirmier, b.CodePatient, b.DatePrelevement });

                builder.HasOne(b => b.Infirmier)
                       .WithMany()
                       .HasForeignKey(b => b.CodeInfirmier);

                builder.HasOne(b => b.Patient)
                       .WithMany()
                       .HasForeignKey(b => b.CodePatient);
            }
        }
    }
}
