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
using System.Text.RegularExpressions;

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
            // loading titles
            // loading speciality
            foreach (String item in DbConnector.getTitle())
            {
                comboBox1.Items.Add(item);
            }
            // loading groups
            foreach (String item in DbConnector.getGroups())
            {
                comboBox2.Items.Add(item);
            }

            // loading courses
            foreach (String item in DbConnector.getCourse())
            {
                comboBox3.Items.Add(item);
            }
            // loading speciality
            foreach (String item in DbConnector.getSpeciality())
            {
                comboBox4.Items.Add(item);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            // действия по созданию записи БД о студенте

            // 1. верификация полей
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";
            string phonePattern = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
            string namePattern = @"^[а-яА-Я]{2,30}$";

            if (!Regex.IsMatch(this.email.Text, emailPattern))
            {
                MessageBox.Show("Email введен не верно. Пожалуйста, введите его заново.");
            }
            if (!Regex.IsMatch(this.phonenumber.Text, phonePattern))
            {
                MessageBox.Show("Номер телефона введен не верно. Пожалуйста, введите его заново.");
            }
            if (!Regex.IsMatch(this.name.Text, namePattern))
            {
                MessageBox.Show("Имя введено не верно. Пожалуйста, введите его заново.");
            }
            if (!Regex.IsMatch(this.surname.Text, namePattern))
            {
                MessageBox.Show("Фамилия введена не верно. Пожалуйста, введите его заново.");
            }
            if (!Regex.IsMatch(this.patronymic.Text, namePattern))
            {
                MessageBox.Show("Отчетство введено не верно. Пожалуйста, введите его заново.");
            }


            // 2. создание объекта класса Student с этими полями и запись его в БД

            DbConnector.PutStudent(new Student(this.name.Text, this.surname.Text, this.patronymic.Text, this.comboBox2.Text, this.phonenumber.Text, this.email.Text));
            // этот метод не готов. в нем надо подробно описать список SQL запросов - в какие таблицы БД какие данные идут
            this.Close();
            // 3. вывод об успешном создании студента?

            // 4. обнулить значения текстовых полей в каждом элементе этой формы 
        }
    }
}