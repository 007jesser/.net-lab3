using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Laboratoire
    {
        public string Intitule { get; set; }
        public int LaboratoireId { get; set; }
        public string Localisation { get; set; }
        public ICollection<Infirmier> Infirmiers { get; set; }

    }
}
