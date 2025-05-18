using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Le code patient doit contenir exactement 5 caractères.")]
        public int CodePatient { get; set; }
        public string EmailPatient { get; set; }
        [Display(Name = "Informations supplémentaires")]
        [DataType(DataType.MultilineText)]
        public string Informations { get; set; }
        public string NomComplet { get; set; }
        public string NumeroTel { get; set; }
        public ICollection<Infirmier> Infirmiers { get; set; }
        public ICollection<Bilan> Bilans { get; set; }
    }
}
