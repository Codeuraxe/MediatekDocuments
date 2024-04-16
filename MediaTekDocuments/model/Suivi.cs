namespace MediaTekDocuments.model
{
    public class Suivi
    {
    
        public int Id { get; }

        public string Etat { get; }

        /// <summary>
        /// Constructeur pour créer un suivi avec un ID et un état.
        /// </summary>
        /// <param name="id">Identifiant du suivi.</param>
        /// <param name="etat">État du document.</param>
        public Suivi(int id, string etat)
        {
            this.Id = id;
            this.Etat = etat;
        }

        /// <summary>
        /// Fournit le texte de l'état pour l'affichage.
        /// </summary>
        /// <returns>Texte de l'état.</returns>
        public override string ToString()
        {
            return this.Etat;
        }
    }
}
