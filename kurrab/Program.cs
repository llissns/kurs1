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
        public static bool      isUserAuthenticated = false;    // shows if user already authenticated or not
        public static string    userName            = "";       // saves username for later purposes

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

            // если пользователь закрыл форму нужно проверить флаг аутентификации isUserAuthenticated
            // если аутентификация не пройдена + форма аутентификации закрыта - завершить программу
            if (!isUserAuthenticated)
                Application.Exit();
            
            // если аутентификация успешно пройдена - продолжить работу со следующей формой уже
            // TODO: напиши что делать дальше программе тут. Открыть мейн форму?
        }
    }
}
