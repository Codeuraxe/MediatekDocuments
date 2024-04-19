using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Gère les interactions avec l'interface principale de l'application Mediatek.
    /// </summary>
    class FrmMediatekController
    {
        private readonly Access access;

        /// <summary>
        /// Constructeur qui initialise l'accès à la base de données.
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        public bool CreerLivre(Livre livre)
        {
            return access.CreerEntite("livre", JsonConvert.SerializeObject(livre));
        }

        public bool UpdateLivre(Livre livre)
        {
            return access.UpdateEntite("livre", livre.Id, JsonConvert.SerializeObject(livre));
        }

        public bool SupprimerLivre(Livre livre)
        {
            return access.SupprimerEntite("livre", JsonConvert.SerializeObject(livre));
        }

        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        public bool CreerDvd(Dvd dvd)
        {
            return access.CreerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }

        public bool UpdateDvd(Dvd dvd)
        {
            return access.UpdateEntite("dvd", dvd.Id, JsonConvert.SerializeObject(dvd));
        }

        public bool SupprimerDvd(Dvd dvd)
        {
            return access.SupprimerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }

        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        public bool CreerRevue(Revue revue)
        {
            return access.CreerEntite("revue", JsonConvert.SerializeObject(revue));
        }

        public bool UpdateRevue(Revue revue)
        {
            return access.UpdateEntite("revue", revue.Id, JsonConvert.SerializeObject(revue));
        }

        public bool SupprimerRevue(Revue revue)
        {
            return access.SupprimerEntite("revue", JsonConvert.SerializeObject(revue));
        }

        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            return access.GetExemplairesRevue(idDocument);
        }

        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            return access.GetCommandesLivres(idLivre);
        }

        public string getMaxIndex(string type)
        {
            return access.getMaxIndex(type);
        }

        private bool utilCommandeDocument(string id, DateTime dateCommande, double montant, int nbExemplaire,
            string idLivreDvd, int idSuivi, string etat, string verbose)
        {
            var commande = new Dictionary<string, object>
            {
                {"Id", id},
                {"DateCommande", dateCommande.ToString("yyyy-MM-dd")},
                {"Montant", montant},
                {"NbExemplaire", nbExemplaire},
                {"IdLivreDvd", idLivreDvd},
                {"IdSuivi", idSuivi},
                {"Etat", etat}
            };

            string action = $"{type}/{JsonConvert.SerializeObject(commande)}";
            switch (verbose)
            {
                case "post":
                    return access.CreerEntite(type, action);
                case "update":
                    return access.UpdateEntite(type, id, action);
                case "delete":
                    return access.SupprimerEntite(type, action);
                default:
                    return false;
            }
        }
    }
}
