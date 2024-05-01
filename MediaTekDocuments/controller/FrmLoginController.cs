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
        /// Objet pour l'accès aux données
        /// </summary>
        private readonly Access access;

        private Utilisateur utilisateur = null;

        /// <summary>
        /// Initialisation et récupération de l'instance unique pour l'accès aux données.
        /// </summary>
        public FrmLoginController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Initialise et affiche la fenêtre principale.
        /// </summary>
        private void Init()
        {
            FrmMediatek mediatek = new FrmMediatek(utilisateur);
            mediatek.Show();
        }

        /// <summary>
        /// Authentifie l'utilisateur en utilisant son email et mot de passe.
        /// </summary>
        /// <param name="mail">Email de l'utilisateur.</param>
        /// <param name="password">Mot de passe de l'utilisateur.</param>
        /// <returns>Vrai si l'authentification est réussie.</returns>
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
                Init();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Génère le hash SHA256 d'une chaîne de caractères.
        /// </summary>
        /// <param name="hashAlgorithm">Algorithme de hash utilisé.</param>
        /// <param name="input">Texte à hasher.</param>
        /// <returns>Hash SHA256 sous forme de chaîne hexadécimale.</returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convertit le texte en tableau de bytes et calcule le hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Utilise un StringBuilder pour assembler les bytes du hash en texte.
            var sBuilder = new StringBuilder();

            // Parcourt chaque byte du hash et le convertit en chaîne hexadécimale.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Retourne la chaîne hexadécimale.
            return sBuilder.ToString();
        }
    }
}
