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
                InformationAffichage.Creer<Participants>(x=>x.NumeroUniqueParticipant, "Id Participant", 30),
                InformationAffichage.Creer<Participants>(x=>x.NumeroUniqueDossier, "Id Dossier réservation", 30),
                InformationAffichage.Creer<Participants>(x=>x.Reduction, "Réduction", 20),
                InformationAffichage.Creer<Participants>(x=>x.Nom, "Nom", 15),
                InformationAffichage.Creer<Participants>(x=>x.Prenom, "Prénom", 15),
                InformationAffichage.Creer<Participants>(x=>x.Adresse, "Adresse", 30),
                InformationAffichage.Creer<Participants>(x=>x.Civilite, "Civilité", 10),
                InformationAffichage.Creer<Participants>(x=>x.Telephone, "Téléphone", 15),
                InformationAffichage.Creer<Participants>(x=>x.DateNaissance, "Date de naissance", 20),
                InformationAffichage.Creer<Participants>(x=>x.Age, "Age", 5),
            };
        private Menu menu;

        public ModuleGestionParticipants(Application application)
        {
            this.Application = application;
        }

        private Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des participants");
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

            // Fonction non réalisée (il était question de pouvoir rechercher par nom, mail (pour le phoning, ), etc
        }
        private void SupprimerParticipant()
        {
            ConsoleHelper.AfficherEntete("Supprimer un participant");

            var liste = Application.GetBaseDonnees().Participants.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);

            using (var db = new BaseDonnees())
            {
                var participant = new Participants
                {
                    NumeroUniqueParticipant = ConsoleSaisie.SaisirEntierObligatoire("Entrez l'Id du participant à supprimer :")
                };

                db.Participants.Attach(participant);
                db.Participants.Remove(participant);
                db.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Participant supprimé !");
            }

        }
    }
}

