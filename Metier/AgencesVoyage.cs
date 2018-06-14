using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage2.Metier
{
    public class AgencesVoyage
    {
        [Key]
        public int NumeroUniqueAgence { get; set; }
        public string Nom { get; set; }

    }
}
