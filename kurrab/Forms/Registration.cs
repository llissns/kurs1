using kurrab.Classes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurrab.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // действия по созданию записи БД о студенте

            // 1. верификация полей
            string emailPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            string phonePattern = "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";
            string namePattern = "^[а-яА-Я ]{2,30}$";

            string email = "dontknow@mail.com";
            string phoneNumber = "+79435623829";
            string fullName = "Сергей Сергеевич";

            if(!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Email не соответствует. Пожалуйста, введите его заново.");
            }
            else
            {
                MessageBox.Show("Email не соответствует паттерну.");
            }

            if (!Regex.IsMatch(phoneNumber,phonePattern))
            {
                MessageBox.Show("Номер телефона не соответствует. Пожалуйста, введите его заново.");
            }
            else
            {
                MessageBox.Show("Номер телефона не соответствует паттерну.");
            }

            if (!Regex.IsMatch(fullName, namePattern))
            {
                MessageBox.Show("Имя и фамилия не соответствуют. Пожалуйста, введите его заново.");
            }
            else
            {
                MessageBox.Show("Имя и фамилия не соответствует паттерну.");
            }


            // 2. создание объекта класса Student с этими полями

            // вызов DbConnector.putStuden(Student myNewStudent)
            // этот метод не готов. в нем надо подробно описать список SQL запросов - в какие таблицы БД какие данные идут

            // 3. вывод об успешном создании студента?

            // 4. обнулить значения текстовых полей в каждом элементе этой формы 
        }
    }
}
