using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BoVoyage2.Metier
{
    [Table("DossiersReservation")]
    public class DossiersReservation
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroUniqueDossier { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }
        public int NombreParticipant { get; set; }
        public bool Assurance { get; set; }

        [ForeignKey("NumeroUniqueClient")]
        public virtual Clients Clients { get; set; }
        public int NumeroUniqueClient { get; set; }

        [ForeignKey("NumeroUniqueVoyage")]
        public virtual Voyages Voyages { get; set; }
        public int NumeroUniqueVoyage { get; set; }

        public enum EtatDossierReservation : byte
        {
            enAttente = 0,
            enCours = 1,
            refusee = 2,
            acceptee = 3
        }

        public enum RaisonAnnulationDossier
        {
            client = 1,
            placesInsuffisantes = 2,
        }


    }
}
