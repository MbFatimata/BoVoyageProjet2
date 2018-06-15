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
                InformationAffichage.Creer<Voyages>(x=>x.NumeroUniqueVoyage, "NumeroUniqueVoyage", 20),
                InformationAffichage.Creer<Voyages>(x=>x.DateAller, "DateAller", 10),
                InformationAffichage.Creer<Voyages>(x=>x.DateRetour, "DateRetour", 10),
                InformationAffichage.Creer<Voyages>(x=>x.PlacesDisponibles, "PlacesDisponibles", 20),
                InformationAffichage.Creer<Voyages>(x=>x.TarifToutCompris, "TarfiToutCompris", 10),
                InformationAffichage.Creer<Voyages>(x=>x.Destinations, "Destinations", 30),
                InformationAffichage.Creer<Voyages>(x=>x.NumeroUniqueAgence, "NumeroUniqueAgence", 20),
            };
        private Menu menu;

        public ModuleGestionVoyages(Application application)
        {
            this.Application = application;
        }

        private Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des voyages");
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

            ConsoleHelper.AfficherEntete("Afficher voyages");

            //Initialisation de donnees
            using (var db = new BaseDonnees())
            {
                var destination1 = new Destinations
                {
                    Continent = "Europe",
                    Pays = "France",
                    Region = "Normandie",
                    Description = "Venez visiter notre magnifique région",
                };
                var destination2 = new Destinations
                {
                    Continent = "Afrique",
                    Pays = "Maroc",
                    Region = "Marrakech et ses alentours",
                    Description = "Venez visiter notre magnifique région",
                };
                var destination3 = new Destinations
                {
                    Continent = "Europe",
                    Pays = "Allemagne",
                    Region = "Bavière et ses alentours",
                    Description = "Venez visiter notre magnifique région",
                };
                var destination4 = new Destinations
                {
                    Continent = "Amérique",
                    Pays = "Etats-Unis",
                    Region = "Texas",
                    Description = "Venez visiter notre magnifique région",
                };
                var agence1 = new AgencesVoyage
                {
                    Nom = "Nouvelles frontières",
                };
                var agence2 = new AgencesVoyage
                {
                    Nom = "Thomas Cook",
                };
                var agence3 = new AgencesVoyage
                {
                    Nom = "Club med",
                };
                var voyage1 = new Voyages
                {
                    AgencesVoyage = agence1,
                    Destinations = destination1,
                    DateAller = DateTime.Today,
                    DateRetour = new DateTime(2019, 03, 01),
                    PlacesDisponibles = 9,
                    TarifToutCompris = 800,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };
                var voyage2 = new Voyages
                {
                    AgencesVoyage = agence2,
                    Destinations = destination1,
                    DateAller = DateTime.Today,
                    DateRetour = new DateTime(2019, 02, 01),
                    PlacesDisponibles = 9,
                    TarifToutCompris = 700,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };
                var voyage3 = new Voyages
                {
                    AgencesVoyage = agence1,
                    Destinations = destination2,
                    DateAller = DateTime.Today,
                    DateRetour = new DateTime(2018, 10, 01),
                    PlacesDisponibles = 5,
                    TarifToutCompris = 300,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };
                var voyage4 = new Voyages
                {
                    AgencesVoyage = agence3,
                    Destinations = destination3,
                    DateAller = new DateTime(2018, 07, 01),
                    DateRetour = new DateTime(2018, 08, 01),
                    PlacesDisponibles = 9,
                    TarifToutCompris = 200,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };
                var voyage5 = new Voyages
                {
                    AgencesVoyage = agence3,
                    Destinations = destination2,
                    DateAller = DateTime.Today,
                    DateRetour = new DateTime(2018, 12, 14),
                    PlacesDisponibles = 6,
                    TarifToutCompris = 500,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };
                var voyage6 = new Voyages
                {
                    AgencesVoyage = agence1,
                    Destinations = destination4,
                    DateAller = new DateTime(2019, 08, 01),
                    DateRetour = new DateTime(2019, 10, 01),
                    PlacesDisponibles = 7,
                    TarifToutCompris = 800,
                    //placesdispo a modifier en faisant methode reserver dans Voyage

                };

                db.Destinations.Add(destination1);
                db.Destinations.Add(destination2);
                db.Destinations.Add(destination3);
                db.Destinations.Add(destination4);
                db.AgencesVoyage.Add(agence1);
                db.AgencesVoyage.Add(agence2);
                db.AgencesVoyage.Add(agence3);
                db.Voyages.Add(voyage1);
                db.Voyages.Add(voyage2);
                db.Voyages.Add(voyage3);
                db.Voyages.Add(voyage4);
                db.Voyages.Add(voyage5);
                db.Voyages.Add(voyage6);
                db.SaveChanges();
            }


            var liste = Application.GetBaseDonnees().Voyages.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }

        public void AjouterVoyage()
        {
            ConsoleHelper.AfficherEntete("Ajouter un voyage");
            using (var db = new BaseDonnees())
            {
                var destination = new Destinations()
                {
                    Continent = ConsoleSaisie.SaisirChaineObligatoire("Continent : "),
                    Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays : "),
                    Region = ConsoleSaisie.SaisirChaineObligatoire("Region : "),
                    Description = ConsoleSaisie.SaisirChaineObligatoire("Description: "),
                };
                var agence = new AgencesVoyage
                {
                    Nom = ConsoleSaisie.SaisirChaineObligatoire("Agence : "),
                };
                var voyage = new Voyages
                {
                    DateAller = ConsoleSaisie.SaisirDateObligatoire("Date aller (j+15 max) : "), //faire une fonction avec message d'erreur si date >j+15
                    DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date retour : "),
                    PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places disponibles (9 max) : "),// faire fonction avec message erreur si nb>9
                    TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Tarif tout compris : "),

                };
                db.Destinations.Add(destination);
                db.AgencesVoyage.Add(agence);
                db.Voyages.Add(voyage);
                db.SaveChanges();

            }
        }
    }
}
