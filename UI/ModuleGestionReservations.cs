using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage2.Metier;
using BoVoyage2.Dal;
using System.Linq;


namespace BoVoyage2.UI
{
    public class ModuleGestionReservations
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageEntitesMetier =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossiersReservation>(x=>x.NumeroUniqueDossier, "Id Réservation", 20),
                InformationAffichage.Creer<DossiersReservation>(x=>x.NumeroUniqueClient, "Id Client", 20),
                InformationAffichage.Creer<DossiersReservation>(x=>x.NumeroCarteBancaire, "Numéro CB", 30),
                InformationAffichage.Creer<DossiersReservation>(x=>x.NumeroUniqueVoyage, "Id Voyage", 20),
                InformationAffichage.Creer<DossiersReservation>(x=>x.NombreParticipant, "NombreParticipant", 20),
                InformationAffichage.Creer<DossiersReservation>(x=>x.PrixTotal, "PrixTotal", 10),
            };
        private Menu menu;

        public ModuleGestionReservations(Application application)
        {
            this.Application = application;
        }

        public Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion 1");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les réservations")
            {
                FonctionAExecuter = this.AfficherReservations
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter une réservation")
            {
                FonctionAExecuter = this.AjouterReservation
            });
            this.menu.AjouterElement(new ElementMenu("3", "Rechercher une réservation")
            {
                FonctionAExecuter = this.RechercherReservation
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une réservation")
            {
                FonctionAExecuter = this.SupprimerReservation
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

        public void AfficherReservations()
        {

            ConsoleHelper.AfficherEntete("Afficher les réservations");
            var liste = Application.GetBaseDonnees().DossiersReservation.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }

        private void AjouterReservation()
        {
            ConsoleHelper.AfficherEntete("Ajouter une réservation");

            Application.ModuleGestionClients.AfficherClients();
            var numeroUniqueClient = ConsoleSaisie.SaisirEntierObligatoire("Choisissez l'Id du client: ");
            Application.ModuleGestionVoyages.AfficherVoyages();
            var numeroUniqueVoyage = ConsoleSaisie.SaisirEntierObligatoire(" Choisissez l'Id du voyage: ");

            using (var db = new BaseDonnees())
            {

                var reservation = new DossiersReservation
                {
                    NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("NumeroCarteBancaire : "),
                    NombreParticipant = ConsoleSaisie.SaisirEntierObligatoire("NombreParticipant: "),
                    PrixTotal = ConsoleSaisie.SaisirEntierObligatoire("PrixTotal: "),

                };
                reservation.NumeroUniqueClient = numeroUniqueClient;
                reservation.NumeroUniqueVoyage = numeroUniqueVoyage;
                db.DossiersReservation.Add(reservation);
                db.SaveChanges();
            }

        }
        private void RechercherReservation()
        {
            ConsoleHelper.AfficherEntete("Rechercher une réservation");
        }
        private void SupprimerReservation()
        {
            ConsoleHelper.AfficherEntete("Supprimer une réservation");

            var liste = Application.GetBaseDonnees().DossiersReservation.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);

            using (var db = new BaseDonnees())
            {
                var dossierReservation = new DossiersReservation
                {
                    NumeroUniqueDossier = ConsoleSaisie.SaisirEntierObligatoire("Entrez l'Id du dossier de réservation à supprimer :")
                };

                db.DossiersReservation.Attach(dossierReservation);
                db.DossiersReservation.Remove(dossierReservation);
                db.SaveChanges();
            }
        }




    }
}
