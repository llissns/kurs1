using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kurrab.Forms
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
        }

        private void SettingsScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPassword = currentpassword.Text;
            string newPassword = newpassword.Text;
            string repeatPassword = repeatpassword.Text;

            if(newPassword != repeatPassword)
            {
                MessageBox.Show("Повторите снова новый пароль.");
                return;
            }

            if(!ValidateCurrentPassword(currentPassword))
            {
                MessageBox.Show("Введен неверно текущий пароль.");
                return;
            }

            if (UpdatePasswordInDatabase(newPassword))
            {   
                MessageBox.Show("Пароль успешно изменен.");
            }
            else
            {
                MessageBox.Show("Не удалось изменить пароль. Повторите ещё раз.");
            }
        }
        private bool ValidateCurrentPassword(string currentPassword)
        {
            throw new NotImplementedException();
        }
        private bool UpdatePasswordInDatabase(string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
