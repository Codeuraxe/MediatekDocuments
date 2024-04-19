namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe représentant la condition physique d'un article dans l'inventaire.
    /// </summary>
    public class Condition
    {
        public string Code { get; }
        public string Description { get; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Condition avec un code et une description spécifiés.
        /// </summary>
        /// <param name="code">Identifiant unique de la condition.</param>
        /// <param name="description">Description textuelle de la condition.</param>
        public Condition(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        /// <summary>
        /// Fournit la description de la condition pour l'affichage, par exemple dans des listes déroulantes.
        /// </summary>
        /// <returns>Retourne la description de la condition.</returns>
        public override string ToString()
        {
            return this.Description;
        }
    }
}
