using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using BoVoyage2.Metier;


namespace BoVoyage2.UI
{

    public class ModuleGestionClients
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageEntitesMetier =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Clients>(x=>x.NumeroUniqueClient, "NumeroUniqueClient", 3),
                InformationAffichage.Creer<Clients>(x=>x.Nom, "Nom", 20),
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
                FonctionAExecuter = this.Afficher
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un client")
            {
                FonctionAExecuter = this.Nouveau
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

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            Console.WriteLine("TO DO");
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            Console.WriteLine("TO DO");
        }
    }
}

