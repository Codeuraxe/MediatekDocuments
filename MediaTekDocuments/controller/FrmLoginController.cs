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
        /// Obtient l'instance unique d'accès aux données.
        /// </summary>
        public FrmLoginController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Active la vue principale.
        /// </summary>
        private void Init()
        {
            FrmMediatek mediatek = new FrmMediatek(utilisateur);
            mediatek.Show();
        }

        /// <summary>
        /// Vérifie l'existence de l'utilisateur dans la base de données.
        /// </summary>
        /// <param name="mail">Adresse mail de l'utilisateur.</param>
        /// <param name="password">Mot de passe de l'utilisateur.</param>
        /// <returns>Vrai si l'utilisateur existe et est authentifié.</returns>
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
        /// Convertit un mot de passe en une chaîne de hash.
        /// </summary>
        /// <param name="hashAlgorithm">Algorithme de hash utilisé.</param>
        /// <param name="input">Mot de passe à hasher.</param>
        /// <returns>Chaîne de caractères représentant le hash.</returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convertit la chaîne en un tableau de bytes et calcule le hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Utilise un StringBuilder pour collecter les bytes et former une chaîne.
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
