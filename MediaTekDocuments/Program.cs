using MediaTekDocuments.view;
using System;
using System.Windows.Forms;

namespace MediaTekDocuments
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();  // Active les styles visuels pour l'application.
            Application.SetCompatibleTextRenderingDefault(false);  // Configure le rendu de texte compatible.
            Application.Run(new FrmLogin());  // Lance le formulaire de connexion comme fenêtre principale.
        }
    }
}

