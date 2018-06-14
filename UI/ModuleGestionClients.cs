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
                InformationAffichage.Creer<Clients>(x=>x.NumeroUniqueClient, "NumeroUniqueClient", 10),
                InformationAffichage.Creer<Clients>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Clients>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<Clients>(x=>x.Adresse, "Adresse", 20),
                InformationAffichage.Creer<Clients>(x=>x.Civilite, "Civilite", 10),
                InformationAffichage.Creer<Clients>(x=>x.Email, "Email", 10),
                InformationAffichage.Creer<Clients>(x=>x.Telephone, "Telephone", 10),
                InformationAffichage.Creer<Clients>(x=>x.DateNaissance, "DateNaissance", 10),
                InformationAffichage.Creer<Clients>(x=>x.Age, "Age", 10),
            };
        private Menu menu;

        public ModuleGestionClients(Application application)
        {
            this.Application = application;
        }

        private Application Application { get; }

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

        private void AfficherClients()
        {
            ConsoleHelper.AfficherEntete("Afficher Clients");
            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageEntitesMetier);
        }
        
        private void AjouterClient()
        {
            ConsoleHelper.AfficherEntete("Ajoueter Client");
            using (var db = new BaseDonnees())
            {
               var client = new Clients
                {
                    Civilite = ConsoleSaisie.SaisirChaineObligatoire("Civilite : "),
                    Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                    Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prenom : "),
                    Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                    Email = ConsoleSaisie.SaisirChaineObligatoire("Email : "),
                    Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone : "),
                    DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),
                };

                int age = DateTime.Now.Year - client.DateNaissance.Year;
                client.Age = age;
                db.Clients.Add(client);
                db.SaveChanges();
            }


        }
    }
}


