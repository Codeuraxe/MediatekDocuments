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
    /// Gestionnaire de connexion à la base de données.
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// URL de base de l'API.
        /// </summary>
        private static readonly string apiUrl = "http://localhost/rest_mediatekdocuments/";

        /// <summary>
        /// Instance singleton de DataAccess.
        /// </summary>
        private static DataAccess _instance;

        /// <summary>
        /// Gestionnaire de requêtes API.
        /// </summary>
        private readonly ApiRest apiManager;

        /// <summary>
        /// Initialise une nouvelle instance de DataAccess.
        /// </summary>
        private DataAccess()
        {
            string authCredentials = "admin:adminpwd";
            try
            {
                apiManager = ApiRest.GetInstance(apiUrl, authCredentials);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur d'initialisation : " + ex.Message);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Accesseur de l'instance unique DataAccess.
        /// </summary>
        public static DataAccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataAccess();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Récupère toutes les catégories de genres depuis la base de données.
        /// </summary>
        public List<Categorie> RetrieveAllGenres()
        {
            return ExtractData<Genre>("genre");
        }

        /// <summary>
        /// Récupère tous les rayons disponibles.
        /// </summary>
        public List<Categorie> RetrieveAllRayons()
        {
            return ExtractData<Rayon>("rayon");
        }

        /// <summary>
        /// Récupère tous les suivis disponibles.
        /// </summary>
        public List<Suivi> RetrieveAllSuivis()
        {
            return ExtractData<Suivi>("suivi");
        }

        /// <summary>
        /// Récupère toutes les catégories de public cibles.
        /// </summary>
        public List<Categorie> RetrieveAllPublics()
        {
            return ExtractData<Public>("public");
        }

        /// <summary>
        /// Extrait les données en utilisant la méthode spécifiée de l'API.
        /// </summary>
        private List<T> ExtractData<T>(string endpoint)
        {
            try
            {
                var jsonResult = apiManager.Get(apiUrl + endpoint);
                return JsonConvert.DeserializeObject<List<T>>(jsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'extraction des données : " + ex.Message);
                return new List<T>();
            }
        }

        /// <summary>
        /// Convertit un nom et une valeur en chaîne JSON.
        /// </summary>
        private string ToJson(object key, object value)
        {
            var dict = new Dictionary<string, object> { { key.ToString(), value } };
            return JsonConvert.SerializeObject(dict);
        }

        /// <summary>
        /// Enregistre une entité dans la base de données.
        /// </summary>
        public bool SaveEntity(string type, string jsonData)
        {
            try
            {
                var response = apiManager.Post(apiUrl + type, jsonData);
                return response.Contains("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de sauvegarde : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifie une entité dans la base de données.
        /// </summary>
        public bool ModifyEntity(string type, string id, string jsonData)
        {
            try
            {
                var response = apiManager.Put(apiUrl + $"{type}/{id}", jsonData);
                return response.Contains("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de modification : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Supprime une entité de la base de données.
        /// </summary>
        public bool DeleteEntity(string type, string jsonData)
        {
            try
            {
                var response = apiManager.Delete(apiUrl + type, jsonData);
                return response.Contains("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de suppression : " + ex.Message);
                return false;
            }
        }
    }
}
