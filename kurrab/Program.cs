using System;
using System.Collections.Generic;
using System.Windows.Forms;
using kurrab.Classes;
using kurrab.Forms;

// это основная область имен программы. все основные объекты нужные для работы находятся внутри нее
namespace kurrab
{
    /// <summary>
    /// класс отвечает за алгоритм (последовательность) работы программы
    /// </summary>
    internal static class Program
    {
        // флаг аутентификации. он определяет была ли пройдена аутентификация пользователем
        public static bool isUserAuthenticated=false;

        // имя пользователя прошедшего аутентификацию. он нужен в дальнейшем например для смены пароля пользователя в БД
        public static string userName = "";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // системные приготовления для отображения форм
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // получаем пары логинов и паролей из БД заранее - они нужны в форме аутентификации будут далее
            List<Credential> authdata = DbConnector.getCredentials();

            // передаем список учетных данных в форму аутентификации для проверки введенного логина и пароля
            // при этом логика работы аутентификации заключена внутри формы
            Application.Run(new Authentication(authdata));

            // после закрытия формы аутентификации сразу проверяем была ли аутентификация пройдена успешно
            if (!isUserAuthenticated)
            {
                // если неуспешно то просто закрываем нашу программу
                Application.Exit();
            }
            else
            {
                // если успешно то продолжаем работу программы с основной ее формы
                Application.Run(new MainScreen());
            }
        }
     }
}
