using System;


namespace MediaTekDocuments.model
{
    public class Commande
    {
        public string Id { get; }
        public DateTime DateCommande { get; }
        public float Montant { get; }

        public Commande(string id, DateTime dateCommande, float montant)
        {
            Id = id;
            DateCommande = dateCommande;
            Montant = montant;
        }
    }
}