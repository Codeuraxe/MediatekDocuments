using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe de gestion de l'accès aux données persistantes via une API REST.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// URL de base de l'API REST utilisée pour la communication.
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";

        /// <summary>
        /// Instance unique de cette classe, implémentant le pattern Singleton.
        /// </summary>
        private static Access instance = null;

        /// <summary>
        /// Gestionnaire de requêtes API pour interagir avec le backend.
        /// </summary>
        private readonly ApiRest api = null;

        /// <summary>
        /// Constante pour les requêtes HTTP de type GET.
        /// </summary>
        private const string GET = "GET";

        /// <summary>
        /// Constante pour les requêtes HTTP de type POST.
        /// </summary>
        private const string POST = "POST";

        /// <summary>
        /// Constante pour les requêtes HTTP de type PUT.
        /// </summary>
        private const string PUT = "PUT";

        /// <summary>
        /// Constante pour les requêtes HTTP de type DELETE.
        /// </summary>
        private const string DELETE = "DELETE";

        /// <summary>
        /// Constructeur privé qui initialise la connexion à l'API REST.
        /// </summary>
        private Access()
        {
            try
            {
                string authenticationString = "admin:adminpwd";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Obtient l'instance unique de la classe Access.
        /// </summary>
        /// <returns>Instance unique de Access.</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Récupère tous les genres disponibles dans la base de données.
        /// </summary>
        /// <returns>Une liste de catégories de genres.</returns>
        public List<Categorie> GetAllGenres()
        {
            var genres = TraitementRecup<Genre>(GET, "genre");
            return new List<Categorie>(genres);
        }

        /// <summary>
        /// Récupère tous les rayons disponibles dans la base de données.
        /// </summary>
        /// <returns>Une liste de catégories de rayons.</returns>
        public List<Categorie> GetAllRayons()
        {
            var rayons = TraitementRecup<Rayon>(GET, "rayon");
            return new List<Categorie>(rayons);
        }

        /// <summary>
        /// Récupère toutes les catégories de publics cibles disponibles dans la base de données.
        /// </summary>
        /// <returns>Une liste de catégories de publics.</returns>
        public List<Categorie> GetAllPublics()
        {
            var publics = TraitementRecup<Public>(GET, "public");
            return new List<Categorie>(publics);
        }

        /// <summary>
        /// Récupère tous les livres disponibles dans la base de données.
        /// </summary>
        /// <returns>Une liste de livres.</returns>
        public List<Livre> GetAllLivres()
        {
            return TraitementRecup<Livre>(GET, "livre");
        }

        /// <summary>
        /// Crée une nouvelle entité dans la base de données en fonction du type spécifié.
        /// </summary>
        /// <param name="type">Type de l'entité à créer.</param>
        /// <param name="jsonEntite">Représentation JSON de l'entité à créer.</param>
        /// <returns>Vrai si l'opération est réussie, faux autrement.</returns>
        public bool CreerEntite(string type, string jsonEntite)
        {
            jsonEntite = jsonEntite.Replace(' ', '-');
            try
            {
                var result = TraitementRecup<Object>(POST, $"{type}/{jsonEntite}");
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifie une entité existante dans la base de données en fonction du type spécifié.
        /// </summary>
        /// <param name="type">Type de l'entité à modifier.</param>
        /// <param name="id">Identifiant de l'entité à modifier.</param>
        /// <param name="jsonEntite">Représentation JSON des nouvelles valeurs de l'entité.</param>
        /// <returns>Vrai si l'opération est réussie, faux autrement.</returns>
        public bool UpdateEntite(string type, string id, string jsonEntite)
        {
            jsonEntite = jsonEntite.Replace(' ', '-');
            try
            {
                var result = TraitementRecup<Object>(PUT, $"{type}/{id}/{jsonEntite}");
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Supprime une entité existante dans la base de données en fonction du type spécifié.
        /// </summary>
        /// <param name="type">Type de l'entité à supprimer.</param>
        /// <param name="jsonEntite">Représentation JSON de l'entité à supprimer.</param>
        /// <returns>Vrai si l'opération est réussie, faux autrement.</returns>
        public bool SupprimerEntite(string type, string jsonEntite)
        {
            jsonEntite = jsonEntite.Replace(' ', '-');
            try
            {
                var result = TraitementRecup<Object>(DELETE, $"{type}/{jsonEntite}");
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Convertit un couple clé/valeur en une chaîne JSON.
        /// </summary>
        /// <param name="nom">Nom de la clé.</param>
        /// <param name="valeur">Valeur associée à la clé.</param>
        /// <returns>Représentation JSON du couple clé/valeur.</returns>
        private string convertToJson(object nom, object valeur)
        {
            var dictionary = new Dictionary<object, object>
            {
                { nom, valeur }
            };
            return JsonConvert.SerializeObject(dictionary);
        }
    }
}
