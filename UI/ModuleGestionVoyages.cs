using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using BoVoyage2.Metier;
using BoVoyage2.Dal;

namespace BoVoyage2.UI
{
    public class ModuleGestionVoyages
    {
        private static readonly List<InformationAffichage> strategieAffichageEntitesMetier =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyages>(x=>x.NumeroUniqueVoyage, "NumeroUniqueVoyage", 10),
                InformationAffichage.Creer<Voyages>(x=>x.DateAller, "DateAller", 10),
                InformationAffichage.Creer<Voyages>(x=>x.DateRetour, "DateRetour", 10),
                InformationAffichage.Creer<Voyages>(x=>x.PlacesDisponibles, "PlacesDisponibles", 20),
                InformationAffichage.Creer<Voyages>(x=>x.TarifToutCompris, "TarfiToutCompris", 10),
                InformationAffichage.Creer<Voyages>(x=>x.Destinations, "Destinations", 10),
                InformationAffichage.Creer<Voyages>(x=>x.NumeroUniqueAgence, "NumeroUniqueAgence", 10),
            };
        private Menu menu;

        public ModuleGestionVoyages(Application application)
        {
            this.Application = application;
        }

        private Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des contrats");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les voyages")
            {
                FonctionAExecuter = this.AfficherVoyage
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un voyage")
            {
                FonctionAExecuter = this.AjouterVoyage
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenu();
            }

            this.menu.Afficher();
        }
        public void AfficherVoyage()
        {
            ConsoleHelper.AfficherEntete("Afficher Voyages");
            var liste = Application.GetBaseDonnees().Voyages.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }
        public void AjouterVoyage()
        {
            using (var db = new BaseDonnees())
            {
                var destination1 = new Destinations
                {
                    Continent = "Europe",
                    Pays = "France",
                    Region = "Normandie",
                    Description ="Venez visiter notre manifique région",
                };
                var destination2 = new Destinations
                {
                    Continent = "Afrique",
                    Pays = "Maroc",
                    Region = "Marrakech et ses alentours",
                    Description = "Venez visiter notre manifique région",
                };
                var destination3 = new Destinations
                {
                    Continent = "Europe",
                    Pays = "Allemagne",
                    Region = "Baviere et ses alentours",
                    Description = "Venez visiter notre manifique région",
                };
                var destination4 = new Destinations
                {
                    Continent = "Amerique",
                    Pays = "Etats-Unis",
                    Region = "Texas",
                    Description = "Venez visiter notre manifique région",
                };
                var agence1 = new AgencesVoyage
                {
                    Nom ="Nouvelles frontières",
                };
                var agence2 = new AgencesVoyage
                {
                    Nom = "Thomas Cook",
                };
                var agence3 = new AgencesVoyage
                {
                    Nom = "Club med",
                };
                db.Destinations.Add(destination1);
                db.Destinations.Add(destination2);
                db.Destinations.Add(destination3);
                db.Destinations.Add(destination4);
                db.AgencesVoyage.Add(agence1);
                db.AgencesVoyage.Add(agence2);
                db.AgencesVoyage.Add(agence3);
                db.SaveChanges();
            }
            
        }
    }
}
