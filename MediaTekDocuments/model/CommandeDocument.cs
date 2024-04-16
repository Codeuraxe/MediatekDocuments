using System;


namespace MediaTekDocuments.model
{
    public class CommandeDocument : Commande
    {
        public int NbExemmplaire { get; }
        public string IdLivreDvd { get; }
        public int IdSuivi { get; }
        public string Etat { get; }

        public CommandeDocument(string id, DateTime dateCommande, float montant, int nbExemplaire,
            string idLivreDvd, int idSuivi, string etat)
            : base(id, dateCommande, montant)
        {
            this.NbExemmplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdSuivi = idSuivi;
            this.Etat = etat;
        }
    }
}