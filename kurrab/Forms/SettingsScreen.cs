using kurrab.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            string hashedCurrentPassword = MD5Helper.GetMd5Hash(currentPassword);

            string hashedPasswordFromDB = DbConnector.GetUserHash("login");

            if (hashedCurrentPassword == hashedPasswordFromDB)
            {
                MessageBox.Show("Пароль верный!");
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
            if (newPassword == repeatPassword)
            {
                MessageBox.Show("Новый пароль совпадает с его повторением!");
            }
            else
            {
                MessageBox.Show("Новый пароль не совпадает с его повторением!");
            }
        }
        private string GetHashedPasswordFromDB()
        { 
            return MD5Helper.GetMd5Hash("hash_value");
        }
    }
}