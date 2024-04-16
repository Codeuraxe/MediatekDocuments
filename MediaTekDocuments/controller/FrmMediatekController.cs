using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Controller attached to the FrmMediatek form handling data access interactions.
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Data access object providing access to the database.
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Initializes a new instance of the controller, ensuring a single data access instance is used.
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Retrieves all genre categories from the database.
        /// </summary>
        /// <returns>A list of genre categories.</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// Retrieves all shelf sections from the database.
        /// </summary>
        /// <returns>A list of shelf sections.</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// Retrieves all target audience categories from the database.
        /// </summary>
        /// <returns>A list of audience categories.</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// Executes a specified document management operation (create, update, delete) using provided details.
        /// </summary>
        /// <param name="id">Document ID.</param>
        /// <param name="titre">Title of the document.</param>
        /// <param name="image">Document image URL or path.</param>
        /// <param name="IdRayon">Shelf section ID.</param>
        /// <param name="IdPublic">Target audience ID.</param>
        /// <param name="IdGenre">Genre ID.</param>
        /// <param name="operation">The operation to perform: 'create', 'update', or 'delete'.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        public bool DocumentAction(string id, string titre, string image, string IdRayon, string IdPublic, string IdGenre, string operation)
        {
            var details = new Dictionary<string, string>
            {
                {"id", id},
                {"titre", titre},
                {"image", image},
                {"idRayon", IdRayon},
                {"idPublic", IdPublic},
                {"idGenre", IdGenre}
            };
            switch (operation.ToLower())
            {
                case "create":
                    return access.CreateEntity("document", JsonConvert.SerializeObject(details));
                case "update":
                    return access.UpdateEntity("document", id, JsonConvert.SerializeObject(details));
                case "delete":
                    return access.DeleteEntity("document", JsonConvert.SerializeObject(details));
            }
            return false;
        }

        /// <summary>
        /// Retrieves the exemplars for a specific magazine issue.
        /// </summary>
        /// <param name="idDocument">Magazine issue ID.</param>
        /// <returns>A list of exemplars for the specified issue.</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            return access.GetExemplairesRevue(idDocument);
        }

        /// <summary>
        /// Creates a new exemplar of a magazine in the database.
        /// </summary>
        /// <param name="exemplaire">Exemplar to be added.</param>
        /// <returns>True if the creation was successful, otherwise false.</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }
    }
}
