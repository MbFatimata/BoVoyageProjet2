using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage2.Metier
{
    public class Assurances
    {
        public int NumeroUniqueAssurance { get; set; }
        public string SouscriptionAnnulation { get; set; }

        [ForeignKey("NumeroUniqueDossier")]
        public virtual List<DossiersReservation> Dossiers { get; set; }
        public int NumeroUniqueDossier { get; set; }
    }
}
