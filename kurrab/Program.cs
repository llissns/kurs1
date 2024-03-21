using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Windows.Forms;

using kurrab.Classes;
using kurrab.Forms;

namespace kurrab
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Credential> authdata = DbConnector.getCredentials();

            Application.Run(new Authentication(authdata));
        }
    }
}
