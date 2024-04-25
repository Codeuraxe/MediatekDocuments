using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur pour FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        #region Commun
        /// <summary>
        /// Accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Initialise l'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère la liste des genres
        /// </summary>
        /// <returns>Liste de genres</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// Récupère la liste des rayons
        /// </summary>
        /// <returns>Liste de rayons</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// Récupère la liste des publics
        /// </summary>
        /// <returns>Liste de publics</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// Récupère la liste des suivis
        /// </summary>
        /// <returns>Liste de suivis</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        /// <summary>
        /// Récupère la liste des états
        /// </summary>
        /// <returns>Liste d'états</returns>
        public List<Etat> GetAllEtats()
        {
            return access.GetAllEtats();
        }

        /// <summary>
        /// Vérifie les droits d'accès à l'accueil pour l'utilisateur
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns>Vrai si autorisé</returns>
        public bool verifDroitAccueil(Utilisateur utilisateur)
        {
            Console.WriteLine(utilisateur.Nom);
            List<string> services = new List<string> { "compta", "biblio", "accueil" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Vérifie les droits de modification pour l'utilisateur
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns>Vrai si autorisé</returns>
        public bool verifDroitModif(Utilisateur utilisateur)
        {
            Console.WriteLine(utilisateur.Nom);
            List<string> services = new List<string> { "biblio", "accueil" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Vérifie si l'utilisateur peut passer des commandes
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns>Vrai si autorisé</returns>
        public bool verifCommande(Utilisateur utilisateur)
        {
            List<string> services = new List<string> { "biblio" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Ajuste le format de date du convertisseur JSON
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }
        #endregion
    }



    #region Onglet Livres
    /// <summary>
    /// Récupère la liste des livres disponibles.
    /// </summary>
    /// <returns>Liste des livres.</returns>
    public List<Livre> GetAllLivres()
    {
        return access.GetAllLivres();
    }

    /// <summary>
    /// Met à jour un exemplaire dans la base de données.
    /// </summary>
    /// <param name="exemplaire">Exemplaire à mettre à jour.</param>
    /// <returns>Vrai si la mise à jour est réussie.</returns>
    public bool UpdateExemplaire(Exemplaire exemplaire)
    {
        return access.UpdateEntite("exemplaire", exemplaire.Id, JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
    }

    /// <summary>
    /// Supprime un exemplaire dans la base de données.
    /// </summary>
    /// <param name="exemplaire">Exemplaire à supprimer.</param>
    /// <returns>Vrai si la suppression est réussie.</returns>
    public bool SupprimerExemplaire(Exemplaire exemplaire)
    {
        return access.SupprimerEntite("exemplaire", JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
    }

    /// <summary>
    /// Crée un nouveau livre dans la base de données.
    /// </summary>
    /// <param name="livre">Livre à créer.</param>
    /// <returns>Vrai si la création est réussie.</returns>
    public bool CreerLivre(Livre livre)
    {
        return access.CreerEntite("livre", JsonConvert.SerializeObject(livre));
    }

    /// <summary>
    /// Modifie un livre existant dans la base de données.
    /// </summary>
    /// <param name="livre">Livre à modifier.</param>
    /// <returns>Vrai si la modification est réussie.</returns>
    public bool UpdateLivre(Livre livre)
    {
        return access.UpdateEntite("livre", livre.Id, JsonConvert.SerializeObject(livre));
    }

    /// <summary>
    /// Supprime un livre de la base de données.
    /// </summary>
    /// <param name="livre">Livre à supprimer.</param>
    /// <returns>Vrai si la suppression est réussie.</returns>
    public bool SupprimerLivre(Livre livre)
    {
        return access.SupprimerEntite("livre", JsonConvert.SerializeObject(livre));
    }
    #endregion


    #region Onglet DvD
    /// <summary>
    /// Récupère la liste des DVDs.
    /// </summary>
    /// <returns>Liste de DVDs.</returns>
    public List<Dvd> GetAllDvd()
    {
        return access.GetAllDvd();
    }

    /// <summary>
    /// Crée un DVD dans la base de données.
    /// </summary>
    /// <param name="dvd">DVD à créer.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool CreerDvd(Dvd dvd)
    {
        return access.CreerEntite("dvd", JsonConvert.SerializeObject(dvd));
    }

    /// <summary>
    /// Met à jour un DVD dans la base de données.
    /// </summary>
    /// <param name="dvd">DVD à mettre à jour.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool UpdateDvd(Dvd dvd)
    {
        return access.UpdateEntite("dvd", dvd.Id, JsonConvert.SerializeObject(dvd));
    }

    /// <summary>
    /// Supprime un DVD de la base de données.
    /// </summary>
    /// <param name="dvd">DVD à supprimer.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool SupprimerDvd(Dvd dvd)
    {
        return access.SupprimerEntite("dvd", JsonConvert.SerializeObject(dvd));
    }
    #endregion


    #region Onglet Revues
    /// <summary>
    /// Récupère la liste des revues.
    /// </summary>
    /// <returns>Liste de revues.</returns>
    public List<Revue> GetAllRevues()
    {
        return access.GetAllRevues();
    }

    /// <summary>
    /// Crée une revue dans la base de données.
    /// </summary>
    /// <param name="revue">Revue à créer.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool CreerRevue(Revue revue)
    {
        return access.CreerEntite("revue", JsonConvert.SerializeObject(revue));
    }

    /// <summary>
    /// Met à jour une revue dans la base de données.
    /// </summary>
    /// <param name="revue">Revue à mettre à jour.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool UpdateRevue(Revue revue)
    {
        return access.UpdateEntite("revue", revue.Id, JsonConvert.SerializeObject(revue));
    }

    /// <summary>
    /// Supprime une revue de la base de données.
    /// </summary>
    /// <param name="revue">Revue à supprimer.</param>
    /// <returns>True si l'opération est valide.</returns>
    public bool SupprimerRevue(Revue revue)
    {
        return access.SupprimerEntite("revue", JsonConvert.SerializeObject(revue));
    }
    #endregion


    #region Onglet Parutions
    /// <summary>
    /// Récupère les exemplaires d'une revue spécifique.
    /// </summary>
    /// <param name="idDocuement">Identifiant de la revue.</param>
    /// <returns>Liste des exemplaires correspondants.</returns>
    public List<Exemplaire> GetExemplairesRevue(string idDocuement)
    {
        return access.GetExemplairesRevue(idDocuement);
    }

    /// <summary>
    /// Enregistre un nouvel exemplaire de revue dans la base de données.
    /// </summary>
    /// <param name="exemplaire">Détails de l'exemplaire à créer.</param>
    /// <returns>Vrai si l'opération est réussie.</returns>
    public bool CreerExemplaire(Exemplaire exemplaire)
    {
        return access.CreerExemplaire(exemplaire);
    }
    #endregion


    #region Commandes de livres et Dvd
    /// <summary>
    /// Récupère les commandes d'une livre
    /// </summary>
    /// <param name="idLivre">id du livre concernée</param>
    /// <returns></returns>
    public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            return access.GetCommandesLivres(idLivre);
        }

        /// <summary>
        /// Retourne l'id max des commandes
        /// </summary>
        /// <returns></returns>
        public string getNbCommandeMax()
        {
            return access.getMaxIndex("maxcommande");
        }

        /// <summary>
        /// Retourne l'id max des livres
        /// </summary>
        /// <returns></returns>
        public string getNbLivreMax()
        {
            return access.getMaxIndex("maxlivre");
        }

        /// <summary>
        /// Retourne l'id max des Dvd
        /// </summary>
        /// <returns></returns>
        public string getNbDvdMax()
        {
            return access.getMaxIndex("maxdvd");
        }

        /// <summary>
        /// Retourne l'id max des revues
        /// </summary>
        /// <returns></returns>
        public string getNbRevueMax()
        {
            return access.getMaxIndex("maxrevue");
        }

        /// <summary>
        /// Creer une commande livre/Dvd dans la bdd
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool CreerLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return access.CreerEntite("commandedocument", JsonConvert.SerializeObject(commandeLivreDvd, new CustomDateTimeConverter()));
        }
        
        /// <summary>
        /// Modifie une commande livre/Dvd dans la bdd
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool UpdateLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return access.UpdateEntite("commandedocument", commandeLivreDvd.Id, JsonConvert.SerializeObject(commandeLivreDvd, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime une commande livre/Dvd dans la bdd
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool SupprimerLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return access.SupprimerEntite("commandedocument", JsonConvert.SerializeObject(commandeLivreDvd, new CustomDateTimeConverter()));
        }
        #endregion

        #region abonnements

        /// <summary>
        /// Retourne tous les abonnements d'une revue
        /// </summary>
        /// <param name="idRevue"></param>
        /// <returns></returns>
        public List<Abonnement> GetAbonnements(string idRevue)
        {
            return access.GetAbonnements(idRevue);
        }

        /// <summary>
        /// Creer un abonnement dans la bdd
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            return access.CreerEntite("abonnement", JsonConvert.SerializeObject(abonnement,  new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Modifie un abonnement dans la bdd
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool UpdateAbonnement(Abonnement abonnement)
        {
            return access.UpdateEntite("abonnement", abonnement.Id, JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime un abonnement dans la bdd
        /// </summary>
        /// <param name="abonnement"></param>
        /// <returns></returns>
        public bool SupprimerAbonnement(Abonnement abonnement)
        {
            return access.SupprimerEntite("abonnement", JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter()));
        }

        #endregion
    }
}
