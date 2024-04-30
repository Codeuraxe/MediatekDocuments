using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Gère les interactions pour l'interface FrmMediatek.
    /// </summary>
    class FrmMediatekController
    {
        #region Commun
        /// <summary>
        /// Accès centralisé aux données.
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Initialise une nouvelle instance avec l'accès aux données.
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère tous les genres disponibles.
        /// </summary>
        /// <returns>Liste des genres.</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// Récupère tous les rayons disponibles.
        /// </summary>
        /// <returns>Liste des rayons.</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// Récupère toutes les catégories de public.
        /// </summary>
        /// <returns>Liste des publics cibles.</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// Récupère tous les types de suivi.
        /// </summary>
        /// <returns>Liste des suivis.</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        /// <summary>
        /// Récupère tous les états disponibles.
        /// </summary>
        /// <returns>Liste des états.</returns>
        public List<Etat> GetAllEtats()
        {
            return access.GetAllEtats();
        }

        /// <summary>
        /// Vérifie si le service de l'utilisateur permet l'accès à l'accueil.
        /// </summary>
        /// <param name="utilisateur">Utilisateur à vérifier.</param>
        /// <returns>Vrai si autorisé.</returns>
        public bool VerifDroitAccueil(Utilisateur utilisateur)
        {
            List<string> services = new List<string> { "compta", "biblio", "accueil" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Vérifie si le service de l'utilisateur permet la modification de données.
        /// </summary>
        /// <param name="utilisateur">Utilisateur à vérifier.</param>
        /// <returns>Vrai si la modification est autorisée.</returns>
        public bool VerifDroitModif(Utilisateur utilisateur)
        {
            List<string> services = new List<string> { "biblio", "accueil" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Vérifie si l'utilisateur peut passer des commandes.
        /// </summary>
        /// <param name="utilisateur">Utilisateur à vérifier.</param>
        /// <returns>Vrai si les commandes sont autorisées.</returns>
        public bool VerifCommande(Utilisateur utilisateur)
        {
            List<string> services = new List<string> { "biblio" };
            return services.Contains(utilisateur.Service);
        }

        /// <summary>
        /// Convertisseur JSON pour le formatage des dates.
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }
        #endregion

        #region Onglet Livres
        /// <summary>
        /// Récupère la liste complète des livres.
        /// </summary>
        /// <returns>Liste des livres.</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// Met à jour un exemplaire de livre dans la base de données.
        /// </summary>
        /// <param name="exemplaire">Exemplaire à mettre à jour.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool UpdateExemplaire(Exemplaire exemplaire)
        {
            return access.UpdateEntite("exemplaire", exemplaire.Id, JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime un exemplaire de livre de la base de données.
        /// </summary>
        /// <param name="exemplaire">Exemplaire à supprimer.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool SupprimerExemplaire(Exemplaire exemplaire)
        {
            return access.SupprimerEntite("exemplaire", JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Crée un nouveau livre dans la base de données.
        /// </summary>
        /// <param name="livre">Livre à créer.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool CreerLivre(Livre livre)
        {
            return access.CreerEntite("livre", JsonConvert.SerializeObject(livre));
        }

        /// <summary>
        /// Met à jour un livre dans la base de données.
        /// </summary>
        /// <param name="livre">Livre à mettre à jour.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool UpdateLivre(Livre livre)
        {
            return access.UpdateEntite("livre", livre.Id, JsonConvert.SerializeObject(livre));
        }

        /// <summary>
        /// Supprime un livre de la base de données.
        /// </summary>
        /// <param name="livre">Livre à supprimer.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool SupprimerLivre(Livre livre)
        {
            return access.SupprimerEntite("livre", JsonConvert.SerializeObject(livre));
        }
        #endregion
    }
}


#region Onglet DvD
/// <summary>
/// Getter sur la liste des Dvd
/// </summary>
/// <returns>Liste d'objets dvd</returns>
public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// Creer un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool CreerDvd(Dvd dvd)
        {
            return access.CreerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Modifie un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            return access.UpdateEntite("dvd", dvd.Id, JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Supprime un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration valide</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            return access.SupprimerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }
        #endregion

        #region Onglet Revues
        /// <summary>
        /// Getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// Creer une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool CreerRevue(Revue revue)
        {
            return access.CreerEntite("revue", JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Modifie une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool UpdateRevue(Revue revue)
        {
            return access.UpdateEntite("revue", revue.Id, JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Supprime une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration valide</returns>
        public bool SupprimerRevue(Revue revue)
        {
            return access.SupprimerEntite("revue", JsonConvert.SerializeObject(revue));
        }
        #endregion

        #region Onglet Parutions
        /// <summary>
        /// Récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
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
        public string GetNbCommandeMax()
        {
            return access.GetMaxIndex("maxcommande");
        }

        /// <summary>
        /// Retourne l'id max des livres
        /// </summary>
        /// <returns></returns>
        public string GetNbLivreMax()
        {
            return access.GetMaxIndex("maxlivre");
        }

        /// <summary>
        /// Retourne l'id max des Dvd
        /// </summary>
        /// <returns></returns>
        public string GetNbDvdMax()
        {
            return access.GetMaxIndex("maxdvd");
        }

        /// <summary>
        /// Retourne l'id max des revues
        /// </summary>
        /// <returns></returns>
        public string GetNbRevueMax()
        {
            return access.GetMaxIndex("maxrevue");
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
        public List<Abonnement> GetAb<onnements(string idRevue)
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
            return access.CreerEntite("abonnement", JsonConvert.SerializeObject(abonnement, new CustomDateTimeConverter()));
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