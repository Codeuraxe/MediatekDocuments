using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Gestionnaire d'accès aux données.
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// URL de base de l'API REST.
        /// </summary>
        private static readonly string baseUri = "http://localhost/rest_mediatekdocuments/";

        /// <summary>
        /// Instance unique de DataAccess pour le pattern Singleton.
        /// </summary>
        private static DataAccess uniqueInstance = null;

        /// <summary>
        /// Client REST pour les interactions API.
        /// </summary>
        private readonly RestClient restClient = null;

        /// <summary>
        /// Verbe HTTP utilisé pour les requêtes de lecture.
        /// </summary>
        private const string HTTP_GET = "GET";

        /// <summary>
        /// Verbe HTTP utilisé pour les requêtes de création.
        /// </summary>
        private const string HTTP_POST = "POST";

        /// <summary>
        /// Verbe HTTP utilisé pour les requêtes de mise à jour.
        /// </summary>
        private const string HTTP_PUT = "PUT";

        /// <summary>
        /// Verbe HTTP utilisé pour les requêtes de suppression.
        /// </summary>
        private const string HTTP_DELETE = "DELETE";

        /// <summary>
        /// Constructeur privé qui initialise le client REST.
        /// </summary>
        private DataAccess()
        {
            string authString;
            try
            {
                authString = "admin:adminpwd";
                restClient = RestClient.GetInstance(baseUri, authString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Fournit l'instance singleton de DataAccess.
        /// </summary>
        public static DataAccess GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new DataAccess();
            }
            return uniqueInstance;
        }

        /// <summary>
        /// Extrait et retourne tous les genres de la base de données.
        /// </summary>
        public List<Categorie> GetAllGenres()
        {
            var genres = FetchResources<Genre>(HTTP_GET, "genre");
            return new List<Categorie>(genres);
        }

        /// <summary>
        /// Extrait et retourne tous les rayons de la base de données.
        /// </summary>
        public List<Categorie> GetAllRayons()
        {
            var rayons = FetchResources<Rayon>(HTTP_GET, "rayon");
            return new List<Categorie>(rayons);
        }

        /// <summary>
        /// Extrait et retourne tous les publics de la base de données.
        /// </summary>
        public List<Categorie> GetAllPublics()
        {
            var publics = FetchResources<Public>(HTTP_GET, "public");
            return new List<Categorie>(publics);
        }

        /// <summary>
        /// Extrait et retourne tous les livres de la base de données.
        /// </summary>
        public List<Livre> GetAllLivres()
        {
            return FetchResources<Livre>(HTTP_GET, "livre");
        }

        /// <summary>
        /// Extrait et retourne tous les DVD de la base de données.
        /// </summary>
        public List<Dvd> GetAllDvd()
        {
            return FetchResources<Dvd>(HTTP_GET, "dvd");
        }

        /// <summary>
        /// Extrait

        string param = ConvertToJson("idLivreDvd", idLivre);
            return FetchResources<CommandeDocument>(HTTP_GET, "commandedocument/" + param);
        }

    /// <summary>
    /// Crée une entité dans la base de données et retourne true si l'opération réussit.
    /// </summary>
    public bool CreateEntity(string type, string jsonEntity)
    {
        try
        {
            var result = FetchResources<object>(HTTP_POST, $"{type}/{jsonEntity}");
            return result != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("CreateEntity Error: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Met à jour une entité dans la base de données et retourne true si l'opération réussit.
    /// </summary>
    public bool UpdateEntity(string type, string id, string jsonEntity)
    {
        try
        {
            var result = FetchResources<object>(HTTP_PUT, $"{type}/{id}/{jsonEntity}");
            return result != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("UpdateEntity Error: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Supprime une entité dans la base de données et retourne true si l'opération réussit.
    /// </summary>
    public bool DeleteEntity(string type, string jsonEntity)
    {
        try
        {
            var result = FetchResources<object>(HTTP_DELETE, $"{type}/{jsonEntity.Replace(' ', '-')}");
            return result != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("DeleteEntity Error: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Convertit un nom et une valeur en un string JSON.
    /// </summary>
    private string ConvertToJson(string name, object value)
    {
        return JsonConvert.SerializeObject(new Dictionary<string, object> { { name, value } });
    }

    /// <summary>
    /// Générique pour effectuer des requêtes HTTP et récupérer des ressources de type spécifié.
    /// </summary>
    private List<T> FetchResources<T>(string method, string endpoint)
    {
        try
        {
            JObject response = restClient.RetrieveData(method, endpoint);
            string code = response["code"].ToString();
            if (code == "200" && method == HTTP_GET)
            {
                string resultString = JsonConvert.SerializeObject(response["result"]);
                return JsonConvert.DeserializeObject<List<T>>(resultString);
            }
            else
            {
                Console.WriteLine("Error: " + response["message"]);
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("API Access Error: " + ex.Message);
            Environment.Exit(1);
            return null;
        }
    }
}
}
