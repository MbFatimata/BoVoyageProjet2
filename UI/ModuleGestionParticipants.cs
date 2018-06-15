using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage2.Metier;
using BoVoyage2.Dal;
using System.Linq;
using BoVoyage2.UI;

namespace BoVoyage2.UI
{
    public class ModuleGestionParticipants
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageEntitesMetier =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Participants>(x=>x.NumeroUniqueParticipant, "NumeroUniqueParticipant", 30),
                InformationAffichage.Creer<Participants>(x=>x.NumeroUniqueDossier, "NumeroUniqueDossier", 30),
                InformationAffichage.Creer<Participants>(x=>x.Reduction, "Reduction", 10),
                InformationAffichage.Creer<Participants>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Participants>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<Participants>(x=>x.Adresse, "Adresse", 20),
                InformationAffichage.Creer<Participants>(x=>x.Civilite, "Civilite", 10),
                InformationAffichage.Creer<Participants>(x=>x.Telephone, "Telephone", 10),
                InformationAffichage.Creer<Participants>(x=>x.DateNaissance, "DateNaissance", 15),
                InformationAffichage.Creer<Participants>(x=>x.Age, "Age", 3),
            };
        private Menu menu;

        public ModuleGestionParticipants(Application application)
        {
            this.Application = application;
        }

        private Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion 1");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les participants")
            {
                FonctionAExecuter = this.AfficherParticipants
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un participant")
            {
                FonctionAExecuter = this.AjouterParticipant
            });
            this.menu.AjouterElement(new ElementMenu("3", "Rechercher un participant")
            {
                FonctionAExecuter = this.RechercherParticipant
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer un participant")
            {
                FonctionAExecuter = this.SupprimerParticipant
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

        private void AfficherParticipants()
        {
            ConsoleHelper.AfficherEntete("Afficher Participants");
            var liste = Application.GetBaseDonnees().Participants.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }

        private void AjouterParticipant()
        {
            ConsoleHelper.AfficherEntete("Ajouter Participant");
            using (var db = new BaseDonnees())
            {
                var participant = new Participants
                {

                    Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : "),
                    Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                    Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : "),
                    Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                    Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : "),
                    DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),
                    Reduction = ConsoleSaisie.SaisirDecimalObligatoire("Reduction : "),
                    NumeroUniqueDossier = ConsoleSaisie.SaisirEntierObligatoire("NumeroUniqueDossier associé : "),
                };
                db.Participants.Add(participant);
                db.SaveChanges();
            }


        }

        private void RechercherParticipant()
        {
            ConsoleHelper.AfficherEntete("Rechercher un participant");
        }
        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer un participant");
        }
    }
}
