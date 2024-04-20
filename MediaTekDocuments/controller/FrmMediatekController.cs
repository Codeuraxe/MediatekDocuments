using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur pour gérer l'interface de l'application MediaTek.
    /// </summary>
    class MediaTekController
    {
        #region Ressources Partagées
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access dataAccess;

        /// <summary>
        /// Initialise une nouvelle instance du contrôleur et assure une instance unique d'accès aux données.
        /// </summary>
        public MediaTekController()
        {
            dataAccess = Access.GetInstance();
        }

        /// <summary>
        /// Récupère toutes les catégories de genres de la base de données.
        /// </summary>
        public List<Categorie> RetrieveAllGenres()
        {
            return dataAccess.RetrieveAllGenres();
        }

        /// <summary>
        /// Récupère toutes les catégories de rayonnage.
        /// </summary>
        public List<Categorie> RetrieveAllRayons()
        {
            return dataAccess.RetrieveAllRayons();
        }

        /// <summary>
        /// Récupère toutes les catégories de public.
        /// </summary>
        public List<Categorie> RetrieveAllPublics()
        {
            return dataAccess.RetrieveAllPublics();
        }

        /// <summary>
        /// Récupère tous les statuts de suivi.
        /// </summary>
        public List<Suivi> RetrieveAllSuivis()
        {
            return dataAccess.RetrieveAllSuivis();
        }

        /// <summary>
        /// Récupère tous les états de condition.
        /// </summary>
        public List<Etat> RetrieveAllEtats()
        {
            return dataAccess.RetrieveAllEtats();
        }
        #endregion

        #region Section Livres
        /// <summary>
        /// Récupère une liste de tous les livres.
        /// </summary>
        public List<Livre> RetrieveAllBooks()
        {
            return dataAccess.RetrieveAllBooks();
        }

        /// <summary>
        /// Met à jour une instance de livre dans la base de données.
        /// </summary>
        public bool ModifyBookInstance(Exemplaire book)
        {
            return dataAccess.ModifyEntity("exemplaire", book.Id, JsonConvert.SerializeObject(book, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime une instance de livre de la base de données.
        /// </summary>
        public bool RemoveBookInstance(Exemplaire book)
        {
            return dataAccess.RemoveEntity("exemplaire", JsonConvert.SerializeObject(book, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Ajoute un nouveau livre à la base de données.
        /// </summary>
        public bool AddNewBook(Livre book)
        {
            return dataAccess.AddNewEntity("livre", JsonConvert.SerializeObject(book));
        }

        /// <summary>
        /// Met à jour les détails d'un livre dans la base de données.
        /// </summary>
        public bool UpdateBookDetails(Livre book)
        {
            return dataAccess.UpdateEntityDetails("livre", book.Id, JsonConvert.SerializeObject(book));
        }

        /// <summary>
        /// Supprime un livre de la base de données.
        /// </summary>
        public bool DeleteBook(Livre book)
        {
            return dataAccess.DeleteEntity("livre", JsonConvert.SerializeObject(book));
        }
        #endregion

        #region Section DVD
        /// <summary>
        /// Récupère une liste de tous les DVDs.
        /// </summary>
        public List<Dvd> RetrieveAllDvds()
        {
            return dataAccess.RetrieveAllDvds();
        }

        /// <summary>
        /// Crée un DVD dans la base de données.
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool CreerDvd(Dvd dvd)
        {
            return dataAccess.CreerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Modifie un DVD dans la base de données.
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            return dataAccess.UpdateEntite("dvd", dvd.Id, JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Supprime un DVD de la base de données.
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            return dataAccess.SupprimerEntite("dvd", JsonConvert.SerializeObject(dvd)); ;
        }
        #endregion

        #region Section Revues
        /// <summary>
        /// Récupère une liste de toutes les revues.
        /// </summary>
        public List<Revue> RetrieveAllRevues()
        {
            return dataAccess.RetrieveAllRevues();
        }

        /// <summary>
        /// Crée une revue dans la base de données.
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool CreerRevue(Revue revue)
        {
            return dataAccess.CreerEntite("revue", JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Modifie une revue dans la base de données.
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool UpdateRevue(Revue revue)
        {
            return dataAccess.UpdateEntite("revue", revue.Id, JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Supprime une revue de la base de données.
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'opération est valide</returns>
        public bool SupprimerRevue(Revue revue)
        {
            return dataAccess.SupprimerEntite("revue", JsonConvert.SerializeObject(revue));
        }
        #endregion

        #region Section Parutions
        /// <summary>
        /// Récupère les exemplaires d'une revue.
        /// </summary>
        /// <param name="idDocument">ID de la revue concernée</param>
        /// <returns>Liste d'exemplaires</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            return dataAccess.GetExemplairesRevue(idDocument);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la base de données.
        /// </summary>
        /// <param name="exemplaire">Exemplaire concerné</param>
        /// <returns>True si la création est réussie</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return dataAccess.CreerExemplaire(exemplaire);
        }
        #endregion

        #region Commandes de livres et DVD
        /// <summary>
        /// Récupère les commandes d'un livre.
        /// </summary>
        /// <param name="idLivre">ID du livre concerné</param>
        /// <returns>Liste des commandes</returns>
        public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            return dataAccess.GetCommandesLivres(idLivre);
        }

        /// <summary>
        /// Retourne l'ID maximal des commandes.
        /// </summary>
        public string GetMaximumOrderId()
        {
            return access.GetMaxIndex("maxcommande");
        }

        /// <summary>
        /// Retourne l'ID maximal des livres.
        /// </summary>
        public string GetMaximumBookId()
        {
            return access.GetMaxIndex("maxlivre");
        }

        /// <summary>
        /// Retourne l'ID maximal des DVDs.
        /// </summary>
        public string GetMaximumDvdId()
        {
            return access.GetMaxIndex("maxdvd");
        }

        /// <summary>
        /// Retourne l'ID maximal des revues.
        /// </summary>
        public string GetMaximumRevueId()
        {
            return access.GetMaxIndex("maxrevue");
        }

        /// <summary>
        /// Crée une commande de livre/DVD dans la base de données.
        /// </summary>
        public bool CreateBookDvdOrder(CommandeDocument order)
        {
            return access.CreateEntity("commandedocument", JsonConvert.SerializeObject(order, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Modifie une commande de livre/DVD dans la base de données.
        /// </summary>
        public bool ModifyBookDvdOrder(CommandeDocument order)
        {
            return access.ModifyEntity("commandedocument", order.Id, JsonConvert.SerializeObject(order, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime une commande de livre/DVD de la base de données.
        /// </summary>
        public bool DeleteBookDvdOrder(CommandeDocument order)
        {
            return access.DeleteEntity("commandedocument", JsonConvert.SerializeObject(order, new CustomDateTimeConverter()));
        }
        #endregion

        #region Abonnements

        /// <summary>
        /// Récupère tous les abonnements pour une revue donnée.
        /// </summary>
        /// <param name="idRevue">ID de la revue</param>
        /// <returns>Liste des abonnements</returns>
        public List<Abonnement> RetrieveSubscriptions(string idRevue)
        {
            return access.RetrieveSubscriptions(idRevue);
        }

        /// <summary>
        /// Crée un abonnement dans la base de données.
        /// </summary>
        public bool CreateSubscription(Abonnement subscription)
        {
            return access.CreateEntity("abonnement", JsonConvert.SerializeObject(subscription, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Modifie un abonnement dans la base de données.
        /// </summary>
        public bool ModifySubscription(Abonnement subscription)
        {
            return access.ModifyEntity("abonnement", subscription.Id, JsonConvert.SerializeObject(subscription, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Supprime un abonnement de la base de données.
        /// </summary>
        public bool DeleteSubscription(Abonnement subscription)
        {
            return access.DeleteEntity("abonnement", JsonConvert.SerializeObject(subscription, new CustomDateTimeConverter()));
        }

        #endregion
    }
}