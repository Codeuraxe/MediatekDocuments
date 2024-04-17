using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur associé au formulaire FrmMediatek.
    /// </summary>
    class FrmMediatekController
    {
        #region Accès aux Données Communes
        /// <summary>
        /// Objet pour l'accès aux données.
        /// </summary>
        private readonly Access accesAuxDonnees;

        /// <summary>
        /// Constructeur initialisant l'accès aux données via un singleton.
        /// </summary>
        public FrmMediatekController()
        {
            accesAuxDonnees = Access.GetInstance();
        }

        /// <summary>
        /// Obtient la liste de toutes les catégories de genres.
        /// </summary>
        public List<Categorie> GetAllGenres()
        {
            return accesAuxDonnees.GetAllGenres();
        }

        /// <summary>
        /// Obtient la liste de toutes les catégories de rayons.
        /// </summary>
        public List<Categorie> GetAllRayons()
        {
            return accesAuxDonnees.GetAllRayons();
        }

        /// <summary>
        /// Obtient la liste de toutes les catégories de publics.
        /// </summary>
        public List<Categorie> GetAllPublics()
        {
            return accesAuxDonnees.GetAllPublics();
        }

        /// <summary>
        /// Obtient la liste de tous les suivis.
        /// </summary>
        public List<Suivi> GetAllSuivis()
        {
            return accesAuxDonnees.GetAllSuivis();
        }
        #endregion

        #region Méthodes Utilitaires pour les Opérations CRUD
        /// <summary>
        /// Gère les requêtes de création, de mise à jour et de suppression pour les documents.
        /// </summary>
        public bool GestionDocument(string id, string titre, string image, string idRayon, string idPublic, string idGenre, string operation)
        {
            var infosDocument = new Dictionary<string, string>
            {
                {"id", id},
                {"titre", titre},
                {"image", image},
                {"idRayon", idRayon},
                {"idPublic", idPublic},
                {"idGenre", idGenre}
            };

            switch (operation)
            {
                case "post":
                    return accesAuxDonnees.CreerEntite("document", JsonConvert.SerializeObject(infosDocument));
                case "update":
                    return accesAuxDonnees.ModifierEntite("document", id, JsonConvert.SerializeObject(infosDocument));
                case "delete":
                    return accesAuxDonnees.SupprimerEntite("document", JsonConvert.SerializeObject(infosDocument));
            }
            return false;
        }

        /// <summary>
        /// Gère les requêtes de création et de suppression pour les DVD et les livres.
        /// </summary>
        public bool GestionDvdLivre(string id, string operation)
        {
            var details = new Dictionary<string, string> { { "id", id } };
            switch (operation)
            {
                case "post":
                    return accesAuxDonnees.CreerEntite("dvds_livres", JsonConvert.SerializeObject(details));
                case "delete":
                    return accesAuxDonnees.SupprimerEntite("dvds_livres", JsonConvert.SerializeObject(details));
            }
            return false;
        }

        /// <summary>
        /// Gère les requêtes de création, de mise à jour et de suppression pour les livres.
        /// </summary>
        public bool GestionLivre(string id, string isbn, string auteur, string collection, string operation)
        {
            var detailsLivre = new Dictionary<string, string>
            {
                {"id", id},
                {"ISBN", isbn},
                {"auteur", auteur},
                {"collection", collection}
            };

            switch (operation)
            {
                case "post":
                    return accesAuxDonnees.CreerEntite("livre", JsonConvert.SerializeObject(detailsLivre));
                case "update":
                    return accesAuxDonnees.ModifierEntite("livre", id, JsonConvert.SerializeObject(detailsLivre));
                case "delete":
                    return accesAuxDonnees.SupprimerEntite("livre", JsonConvert.SerializeObject(detailsLivre));
            }
            return false;
        }

        /// <summary>
        /// Gère les requêtes de création, de mise à jour et de suppression pour les DVD.
        /// </summary>
        public bool GestionDvd(string id, string synopsis, string realisateur, int duree, string operation)
        {
            var detailsDvd = new Dictionary<string, object>
            {
                {"id", id},
                {"synopsis", synopsis},
                {"realisateur", realisateur},
                {"duree", duree}
            };

            switch (operation)
            {
                case "post":
                    return accesAuxDonnees.CreerEntite("dvd", JsonConvert.SerializeObject(detailsDvd));
                case "update":
                    return accesAuxDonnees.ModifierEntite("dvd", id, JsonConvert.SerializeObject(detailsDvd));
                case "delete":
                    return accesAuxDonnees.SupprimerEntite("dvd", JsonConvert.SerializeObject(detailsDvd));
            }
            return false;
        }

        /// <summary>
        /// Gère les requêtes de création, de mise à jour et de suppression pour les revues.
        /// </summary>
        public bool GestionRevue(string id, string periodicite, int delaiMiseADispo, string operation)
        {
            var detailsRevue = new Dictionary<string, object>
            {
                {"id", id},
                {"periodicite", periodicite},
                {"delaiMiseADispo", delaiMiseADispo}
            };

            switch (operation)
            {
                case "post":
                    return accesAuxDonnees.CreerEntite("revue", JsonConvert.SerializeObject(detailsRevue));
                case "update":
                    return accesAuxDonnees.ModifierEntite("revue", id, JsonConvert.SerializeObject(detailsRevue));
                case "delete":
                    return accesAuxDonnees.SupprimerEntite("revue", JsonConvert.SerializeObject(detailsRevue));
            }
            return false;
        }
        #endregion

        // Les méthodes additionnelles et les régions peuvent être réécrites de manière similaire pour refléter les nouvelles conventions de nommage et la structure.
    }
}
