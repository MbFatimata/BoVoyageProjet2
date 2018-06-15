using System.ComponentModel.DataAnnotations;

namespace BoVoyage2.Metier
{
    public class Destinations
    {
        [Key]
        public int NumeroUniqueDestination { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{this.Pays.ToUpper()} {this.Description}"; 
        }
    }
}
