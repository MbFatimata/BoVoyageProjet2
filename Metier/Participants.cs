using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage2.Metier
{
    public class Participants
    {
        [Key]
        public int NumeroUniqueParticipant { get; set; }
        public float Reduction { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }

        [ForeignKey ("NumeroUniqueDossier")]
        public virtual DossiersReservation Dossiers { get; set; }
        public int NumeroUniqueDossier { get; set; }
    }
}
