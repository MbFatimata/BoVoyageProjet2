using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage2.Metier
{
    [Table("AgencesVoyage")]
    public class AgencesVoyage
    {
        [Key]
        public int NumeroUniqueAgence { get; set; }
        public string Nom { get; set; }

    }
}
