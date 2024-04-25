using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System.Security.Cryptography;
using System.Text;
using MediaTekDocuments.view;
using System.Windows.Forms;

namespace MediaTekDocuments.controller
{
    class FrmLoginController
    {
        /// <summary>
        /// Objet pour l'accès aux données.
        /// </summary>
        private readonly Access access;

        private Utilisateur utilisateur = null;

        private FrmMediatek mediatek;

        /// <summary>
        /// Initialise une nouvelle instance et configure l'objet d'accès aux données.
        /// </summary>
        public FrmLoginController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Initialise l'interface principale de l'application et l'affiche.
        /// </summary>
        private void init()
        {
            mediatek = new FrmMediatek(utilisateur);
            mediatek.Show();
        }

        /// <summary>
        /// Tente de connecter l'utilisateur avec l'email et le mot de passe fournis.
        /// </summary>
        /// <param name="mail">Email de l'utilisateur.</param>
        /// <param name="password">Mot de passe de l'utilisateur.</param>
        /// <returns>Vrai si la connexion est réussie, sinon faux.</returns>
        public bool GetLogin(string mail, string password)
        {
            password = "Mediatek" + password;
            string hash = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = GetHash(sha256Hash, password);
            }
            utilisateur = access.GetLogin(mail, hash);
            if (utilisateur != null)
            {
                init();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Génère un hash pour la chaîne donnée en utilisant l'algorithme de hash spécifié.
        /// </summary>
        /// <param name="hashAlgorithm">Algorithme de hash à utiliser.</param>
        /// <param name="input">Chaîne à hasher.</param>
        /// <returns>Chaîne hexadécimale du hash.</returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convertit la chaîne en entrée en tableau de bytes et calcule le hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Crée un StringBuilder pour recueillir les bytes et créer une chaîne.
            var sBuilder = new StringBuilder();

            // Parcourt chaque byte des données hashées et les formate en chaîne hexadécimale.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Retourne la chaîne hexadécimale.
            return sBuilder.ToString();
        }
    }
}
