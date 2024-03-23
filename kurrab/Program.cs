using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Windows.Forms;
using System.Security.Cryptography;

using kurrab.Classes;
using kurrab.Forms;
using System.Text;

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

            // передаем список учетных данных в форму аутентификации для проверки введенного логина и пароля
            // при этом логика работы аутентификации заключена внутри формы
            Application.Run(new MainScreen());

            // если пользователь закрыл форму нужно проверить флаг аутентификации isUserAuthenticated
            // если аутентификация не пройдена + форма аутентификации закрыта - завершить программу

            // если аутентификация успешно пройдена - продолжить работу со следующей формой уже
        }
     }


}
