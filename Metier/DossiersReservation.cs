﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage2.Metier
{
    public class DossiersReservation
    {
        [Key]
        public int NumeroUniqueDossier { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }
        public int NombreParticipant { get; set; }

        [ForeignKey("NumeroUniqueClient")]
        public virtual Clients Clients { get; set; }
        public int NumeroUniqueClient { get; set; }

        [ForeignKey("NumeroUniqueVoyage")]
        public virtual Voyages Voyages { get; set; }
        public int NumeroUniqueVoyage { get; set; }


    }
}