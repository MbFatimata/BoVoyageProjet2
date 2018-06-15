using BoVoyage2.Metier;
using System.Data.Entity;

namespace BoVoyage2.Dal
{
    public class BaseDonnees : DbContext
    {
        public BaseDonnees(string connectionString = "Connexion")
            : base(connectionString)
        {
        }

        public DbSet<AgencesVoyage> AgencesVoyage { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Destinations> Destinations { get; set; }

        public DbSet<DossiersReservation> DossiersReservation { get; set; }

        public DbSet<Participants> Participants { get; set; }

        public DbSet<Voyages> Voyages { get; set; }
    }
}