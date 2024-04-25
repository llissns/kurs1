using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using kurrab.Classes;

namespace kurrab.Forms
{
    // форма будет отвечать за процесс аутентификации пользователя в программе
    public partial class Authentication : Form
    {
        // список учетных данных запрашивается во внешнем коде заранее и сохраняется конструктором класса в это поле
        List<Credential> creds;
        public Authentication()
        {
            InitializeComponent();
        }

        // этот конструктор сохраняет список учетных данных программы в поле
        public Authentication(List<Credential> _creds)
        {
            InitializeComponent();
            creds = _creds;
        }

        // когда логин и пароль введены пользователем и нажата кнопка "войти"
        // происходит событие и срабатывает этот метод
        // он сверяет логин и хеш пароля с теми что находятся в БД
        // и выставляет внешний флаг об успешной аутентификации и сохраняет имя пользователя/
        // если аутентификация не удачна то внешний флаг не выставляется.
        private void button1_Click(object sender, EventArgs e)
        {
            // ищем учетные данные в списке, обрабатываем результат
            if (!Credential.searchForCredential(creds, new Credential(login.Text, MD5Helper.GetMd5Hash(password.Text))))
            {
                // в случае неуспешной аутентификации:
                this.textBox1.Text = "Логин и пароль не совпали";
                this.password.Text = ""; // затираем пароль тк он не совпал, его все равно вводить заново
            }
            else
            {
                // в случае успешной аутентификации:
                Program.isUserAuthenticated = true; // ставим флаг - аутентификация пройдена
                Program.userName = login.Text;      // сохраняем имя пользователя
                this.Close();   // закрываем эту форму принудительно
            }
        }

        private void Authentication_Load(object sender, EventArgs e)
        {

        }
    }
}
