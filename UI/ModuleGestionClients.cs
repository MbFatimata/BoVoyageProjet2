using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage2.Metier;
using BoVoyage2.Dal;
using System.Linq;


namespace BoVoyage2.UI
{

    public class ModuleGestionClients
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageEntitesMetier =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Clients>(x=>x.NumeroUniqueClient, "Id", 5),
                InformationAffichage.Creer<Clients>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Clients>(x=>x.Prenom, "Prénom", 10),
                InformationAffichage.Creer<Clients>(x=>x.Adresse, "Adresse", 30),
                InformationAffichage.Creer<Clients>(x=>x.Civilite, "Civilité", 10),
                InformationAffichage.Creer<Clients>(x=>x.Email, "Email", 40),
                InformationAffichage.Creer<Clients>(x=>x.Telephone, "Téléphone", 20),
                InformationAffichage.Creer<Clients>(x=>x.DateNaissance, "Date de naissance", 20),
                InformationAffichage.Creer<Clients>(x=>x.Age, "Age", 5),
            };
        private Menu menu;

        public ModuleGestionClients(Application application)
        {
            this.Application = application;
        }

        public Application Application { get; }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion 1");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les clients")
            {
                FonctionAExecuter = this.AfficherClients
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un client")
            {
                FonctionAExecuter = this.AjouterClient
            });
            this.menu.AjouterElement(new ElementMenu("3", "Rechercher des clients")
            {
                FonctionAExecuter = this.RechercherClients
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient
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

        public void AfficherClients()
        {
            ConsoleHelper.AfficherEntete("Afficher clients");
            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }

        private void AjouterClient()
        {
            ConsoleHelper.AfficherEntete("Ajouter client");
            using (var db = new BaseDonnees())
            {
                var client = new Clients
                {
                    Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilité : "),
                    Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                    Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : "),
                    Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                    Email = ConsoleSaisie.SaisirChaineObligatoire("Email : "),
                    Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone : "),
                    DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),
                };

                int age = DateTime.Now.Year - client.DateNaissance.Year;
                client.Age = age;
                db.Clients.Add(client);
                db.SaveChanges();
            }


        }

        private void RechercherClients()
        {
            ConsoleHelper.AfficherEntete("Rechercher des clients");

            // Fonction non réalisée (il était question de pouvoir rechercher par plusieurs crtières)
        }
        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");

            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);

            using (var db = new BaseDonnees())
            {
                var client = new Clients
                {
                    NumeroUniqueClient = ConsoleSaisie.SaisirEntierObligatoire("Entrez l'Id du client à supprimer :")
                };

                db.Clients.Attach(client);
                db.Clients.Remove(client);
                db.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Client supprimé !");
            }
        }
    }
}


