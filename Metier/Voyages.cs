using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage2.Metier
{
    public class Voyages
    {
        [Key]
        public int NumeroUniqueVoyage { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal TarifToutCompris { get; set; }

        [ForeignKey("NumeroUniqueDestination")]
        public virtual Destinations Destinations { get; set; }
        public int NumeroUniqueDestination { get; set; }

        [ForeignKey("NumeroUniqueAgence")]
        public virtual AgencesVoyage AgencesVoyage { get; set; }
        public int NumeroUniqueAgence { get; set; }
    }
}
