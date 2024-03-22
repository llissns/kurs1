using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Windows.Forms;

using kurrab.Classes;
using kurrab.Forms;

namespace kurrab
{
    /// <summary>
    /// класс отвечает за алгоритм (последовательность) работы программы
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // системные приготовления для отображения форм
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // получаем список учетных данных из БД
            List<Credential> authdata = DbConnector.getCredentials();

            // передаем список учетных данных в форму аутентификации для проверки введенного логина и пароля
            // при этом логика работы аутентификации заключена внутри формы
            Application.Run(new Authentication(authdata));
        }
    }
}
