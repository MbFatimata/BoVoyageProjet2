using System.ComponentModel.DataAnnotations;
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
