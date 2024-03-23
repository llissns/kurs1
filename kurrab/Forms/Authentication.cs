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
    public partial class Authentication : Form
    {
        List<Credential> creds;
        public Authentication()
        {
            InitializeComponent();
        }

        public Authentication(List<Credential> _creds)
        {
            InitializeComponent();
            creds = _creds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputlogin = login.Text;
            string inputpassword = password.Text;
            string hashedPassword = MD5Helper.GetMd5Hash(inputpassword);
            // ищем учетные данные в списке, обрабатываем результат
            if (!Credential.searchForCredential(creds, new Credential(login.Text, hashedPassword)))
            {
                this.textBox1.Text = "Логин и пароль не совпали";
                this.password.Text = ""; // затираем пароль тк он не совпал, его все равно вводить заново
            }
            else
            {
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
