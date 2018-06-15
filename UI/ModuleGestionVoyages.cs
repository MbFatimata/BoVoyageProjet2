using System;
using System.Collections.Generic;
using System.Linq;
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
                FonctionAExecuter = this.AfficherVoyages
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un voyage")
            {
                FonctionAExecuter = this.AjouterVoyage
            });
            this.menu.AjouterElement(new ElementMenu("3", "Rechercher un voyage")
            {
                FonctionAExecuter = this.RechercherVoyage
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer un voyage")
            {
                FonctionAExecuter = this.SupprimerVoyage
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
        public void AfficherVoyages()
        {

            ConsoleHelper.AfficherEntete("Afficher voyages");

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
                    DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date retour : "),
                    PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places disponibles (9 max) : "),// faire fonction avec message erreur si nb>9
                    TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Tarif tout compris : "),

                };

                var dateAller = ConsoleSaisie.SaisirDateObligatoire("Date aller (j+15 max) : ");
                TimeSpan differenceEntreAujEtDateAllaer = dateAller - DateTime.Now;

                if ((int)differenceEntreAujEtDateAllaer.TotalDays > 15)
                {
                    Console.WriteLine("La date saisie est incorrecte");
                }
                else
                {
                    voyage.DateAller = dateAller;
                }

                db.Destinations.Add(destination);
                db.AgencesVoyage.Add(agence);
                db.Voyages.Add(voyage);
                db.SaveChanges();

            }
        }
        private void RechercherVoyage()
        {

        }
        private void SupprimerVoyage()
        {
            ConsoleHelper.AfficherEntete("Supprimer un voyage");

            var liste = Application.GetBaseDonnees().Voyages.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);

            using (var db = new BaseDonnees())
            {
                var voyage = new Voyages
                {
                    NumeroUniqueVoyage = ConsoleSaisie.SaisirEntierObligatoire("Entrez l'Id du voyage à supprimer :")
                };

                db.Voyages.Attach(voyage);
                db.Voyages.Remove(voyage);
                db.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Voyage supprimé !");
            }

        }

    }
}
