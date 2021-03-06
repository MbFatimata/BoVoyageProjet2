﻿using System;
using BoVoyage.Framework.UI;
using BoVoyage2.Dal;

namespace BoVoyage2.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionClients moduleGestionClients;
        private ModuleGestionVoyages moduleGestionVoyages;
        private ModuleGestionParticipants moduleGestionParticipants;
        private ModuleGestionReservations moduleGestionReservations;

        public ModuleGestionReservations ModuleGestionReservations { get => this.moduleGestionReservations; }
        public ModuleGestionClients ModuleGestionClients { get => this.moduleGestionClients; }
        public ModuleGestionVoyages ModuleGestionVoyages { get => this.moduleGestionVoyages; }
        public ModuleGestionParticipants ModuleGestionParticipants { get => this.moduleGestionParticipants; }

        private void InitialiserModules()
        {
            this.moduleGestionClients = new ModuleGestionClients(this);
            this.moduleGestionVoyages = new ModuleGestionVoyages(this);
            this.moduleGestionParticipants = new ModuleGestionParticipants(this);
            this.moduleGestionReservations = new ModuleGestionReservations(this);


        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClients.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("2", "Gestion voyages")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionVoyages.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("3", "Gestion participants")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionParticipants.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("4", "Gestion réservations")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionReservations.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenuQuitterMenu("Q", "Quitter")
            {
                FonctionAExecuter = () => Environment.Exit(1)
            });
        }

        public void Demarrer()
        {
            this.InitialiserModules();
            this.InitialiserMenuPrincipal();

            this.menuPrincipal.Afficher();
        }

        public static BaseDonnees GetBaseDonnees()
        {
            return new BaseDonnees();
        }
    }
}
