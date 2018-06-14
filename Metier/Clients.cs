using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage2.Metier
{
    public class Clients
    {
        [Key]
        public int NumeroUniqueClient { get; set; }
        public string Email { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }
    }

}
