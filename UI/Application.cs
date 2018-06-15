using System;
using BoVoyage.Framework.UI;
using BoVoyage2.Dal;

namespace BoVoyage2.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionClients moduleGestionClients;
        private ModuleGestionVoyages moduleGestionVoyages;

        private void InitialiserModules()
        {
            this.moduleGestionClients = new ModuleGestionClients(this);
            this.moduleGestionVoyages = new ModuleGestionVoyages(this);


        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion Clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClients.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("2", "Gestion Voyages")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionVoyages.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("3", "Gestion Participants")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionParticipants.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("4", "Gestion Reservations")
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
