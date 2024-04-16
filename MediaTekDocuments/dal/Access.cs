using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using MediaTypeDocuments.model;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Gère l'accès aux données de l'application via l'API REST.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// URL de base de l'API REST.
        /// </summary>
        private static readonly string BaseUrl = "http://localhost/rest_mediatekdocuments/";

        /// <summary>
        /// Instance singleton de la classe Access.
        /// </summary>
        private static Access _instance;

        /// <summary>
        /// Client HTTP pour les requêtes API.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructeur privé pour implémenter le modèle Singleton.
        /// Initialise le client HTTP pour l'authentification.
        /// </summary>
        private Access()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:adminpwd"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
        }

        /// <summary>
        /// Obtient l'instance unique de la classe Access.
        /// </summary>
        /// <returns>L'instance unique de la classe Access.</returns>
        public static Access GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Access();
            }
            return _instance;
        }

        /// <summary>
        /// Envoie une requête HTTP pour récupérer des données du serveur.
        /// </summary>
        /// <typeparam name="T">Type de données à récupérer.</typeparam>
        /// <param name="method">Méthode HTTP utilisée pour la requête.</param>
        /// <param name="endpoint">Point de terminaison spécifique de l'API.</param>
        /// <returns>Liste d'objets du type demandé.</returns>
        private List<T> FetchData<T>(string method, string endpoint)
        {
            HttpResponseMessage response = _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), endpoint)).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            return new List<T>();
        }

        /// <summary>
        /// Récupère tous les genres depuis la base de données.
        /// </summary>
        /// <returns>Une liste de genres.</returns>
        public List<Categorie> GetAllGenres()
        {
            return FetchData<Categorie>("GET", "genres");
        }

        /// <summary>
        /// Récupère tous les rayons depuis la base de données.
        /// </summary>
        /// <returns>Une liste de rayons.</returns>
        public List<Categorie> GetAllRayons()
        {
            return FetchData<Categorie>("GET", "rayons");
        }

        /// <summary>
        /// Récupère toutes les catégories de public depuis la base de données.
        /// </summary>
        /// <returns>Une liste de catégories de public.</returns>
        public List<Categorie> GetAllPublics()
        {
            return FetchData<Categorie>("GET", "publics");
        }

        /// <summary>
        /// Récupère tous les livres depuis la base de données.
        /// </summary>
        /// <returns>Une liste de livres.</returns>
        public List<Livre> GetAllLivres()
        {
            return FetchData<Livre>("GET", "livres");
        }
    }
}
