using kurrab.Classes;
using System;
using System.Collections.Generic;
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

            // 2. создание объекта класса Student с этими полями

            // вызов DbConnector.putStuden(Student myNewStudent)
            // этот метод не готов. в нем надо подробно описать список SQL запросов - в какие таблицы БД какие данные идут

            // 3. вывод об успешном создании студента?

            // 4. обнулить значения текстовых полей в каждом элементе этой формы 
        }
    }
}
