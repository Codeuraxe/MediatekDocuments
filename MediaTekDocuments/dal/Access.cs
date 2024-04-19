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
    /// Fournit l'accès aux données stockées dans la base de données par le biais de l'API REST.
    /// </summary>
    public class DataAccess
    {
        private static readonly string apiBaseUrl = "http://localhost/rest_mediatekdocuments/";
        private static DataAccess _instance = null;
        private readonly ApiRest apiClient = null;

        private const string METHOD_GET = "GET";
        private const string METHOD_POST = "POST";
        private const string METHOD_PUT = "PUT";
        private const string METHOD_DELETE = "DELETE";

        private DataAccess()
        {
            string credentials = "admin:adminpwd";
            try
            {
                apiClient = ApiRest.GetInstance(apiBaseUrl, credentials);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing API client: " + ex.Message);
                Environment.Exit(1);
            }
        }

        public static DataAccess Instance()
        {
            if (_instance == null)
            {
                _instance = new DataAccess();
            }
            return _instance;
        }

        public List<Categorie> RetrieveAllGenres()
        {
            var genres = FetchFromDatabase<Genre>(METHOD_GET, "genre");
            return new List<Categorie>(genres);
        }

        public List<Categorie> RetrieveAllRayons()
        {
            var rayons = FetchFromDatabase<Rayon>(METHOD_GET, "rayon");
            return new List<Categorie>(rayons);
        }

        public List<Suivi> RetrieveAllSuivis()
        {
            var suivis = FetchFromDatabase<Suivi>(METHOD_GET, "suivi");
            return new List<Suivi>(suivis);
        }

        public List<Categorie> RetrieveAllPublics()
        {
            var publics = FetchFromDatabase<Public>(METHOD_GET, "public");
            return new List<Categorie>(publics);
        }

        public List<Livre> RetrieveAllLivres()
        {
            return FetchFromDatabase<Livre>(METHOD_GET, "livre");
        }

        public bool CreateEntity(string entityType, string jsonData)
        {
            return ProcessRequest(entityType, jsonData, METHOD_POST);
        }

        public bool UpdateEntity(string entityType, string id, string jsonData)
        {
            return ProcessRequest($"{entityType}/{id}", jsonData, METHOD_PUT);
        }

        public bool DeleteEntity(string entityType, string jsonData)
        {
            return ProcessRequest(entityType, jsonData, METHOD_DELETE);
        }

        public List<Dvd> RetrieveAllDvd()
        {
            return FetchFromDatabase<Dvd>(METHOD_GET, "dvd");
        }

        public List<Revue> RetrieveAllRevues()
        {
            return FetchFromDatabase<Revue>(METHOD_GET, "revue");
        }

        public List<Exemplaire> RetrieveExemplairesByRevue(string revueId)
        {
            return FetchFromDatabase<Exemplaire>(METHOD_GET, $"exemplaire/{ConvertToJson("id", revueId)}");
        }

        private List<T> FetchFromDatabase<T>(string method, string query)
        {
            var response = apiClient.MakeRequest(method, query);
            if (response["code"].ToString() == "200" && method == METHOD_GET)
            {
                var result = JsonConvert.SerializeObject(response["result"]);
                return JsonConvert.DeserializeObject<List<T>>(result, new JsonSerializerSettings { Converters = new List<JsonConverter> { new CustomBooleanJsonConverter() } });
            }
            else
            {
                Console.WriteLine($"Error fetching data: {response["message"]}");
                return new List<T>();
            }
        }

        private bool ProcessRequest(string path, string data, string method)
        {
            var response = apiClient.MakeRequest(method, $"{path}/{data.Replace(' ', '-')}");
            return response != null && response["code"].ToString() == "200";
        }

        private string ConvertToJson(string key, object value)
        {
            var dictionary = new Dictionary<string, object> { { key, value } };
            return JsonConvert.SerializeObject(dictionary);
        }

        private class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        private class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd";
            }
        }
    }
}
