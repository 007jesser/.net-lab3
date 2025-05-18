using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum Specialite
    {
        Hematologie,
        Biochimie,
        Autre
    }

    public class Infirmier
    {
        public int InfirmierId { get; set; }
        public string NomComplet { get; set; }
        public Specialite specialite { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public Laboratoire Laboratoire { get; set; }

        [ForeignKey("Laboratoire")]
        public int LaboratoireFK { get; set; }

        public ICollection<Bilan> Bilans { get; set; }
    }
}
