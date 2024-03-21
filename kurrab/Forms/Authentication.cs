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
        public Authentication()
        {
            InitializeComponent();
        }

        public Authentication(List<Credential> creds)
        {
            InitializeComponent();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_TextChanged(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            if (ICredential.searchForCredential(login, password,List )) 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте снова.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
        }
    }
}
