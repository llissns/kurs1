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
using System.Data.SqlClient;

namespace kurrab.Forms
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;

            // Automatically resize the visible rows.
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // Set the DataGridView control's border.
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Put the cells in edit mode when user enters them.
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; // prohibit editing

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dataGridView1.DataSource = DbConnector.getStudentList();
            this.dataGridView1.DataMember = "liststudents";
        }

        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            // loading titles
            jobtitles.DataBindings.Clear();
            jobtitles.DataSource = DbConnector.getTitle().Tables[0];
            jobtitles.DisplayMember = "values";
            jobtitles.ValueMember = "ID";

            // loading speciality
            speciality.DataBindings.Clear();
            speciality.DataSource = DbConnector.getSpeciality().Tables[0];
            speciality.DisplayMember = "speciality";
            speciality.ValueMember = "ID";

            // loading groups
            group.DataBindings.Clear();
            group.DataSource = DbConnector.getGroups().Tables[0];
            group.DisplayMember = "group";
            group.ValueMember = "id";
            
            // loading courses
            course.DataBindings.Clear();
            course.DataSource = DbConnector.getCourse().Tables[0];
            course.DisplayMember = "course";
            course.ValueMember = "ID";
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
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(repeatPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
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
                this.email.Text = "";
            }

            if (!Regex.IsMatch(this.phonenumber.Text, phonePattern))
            {
                MessageBox.Show("Номер телефона введен не верно. Пожалуйста, введите его заново.");
                this.phonenumber.Text = "";
            }
 
            if (!Regex.IsMatch(this.name.Text, namePattern))
            {
                MessageBox.Show("Имя введено не верно. Пожалуйста, введите его заново.");
                this.name.Text = "";
            }

            if (!Regex.IsMatch(this.surname.Text, namePattern))
            {
                MessageBox.Show("Фамилия введена не верно. Пожалуйста, введите его заново.");
                this.surname.Text = "";
            }

            if (!Regex.IsMatch(this.patronymic.Text, namePattern))
            {
                MessageBox.Show("Отчетство введено не верно. Пожалуйста, введите его заново.");
                this.patronymic.Text = "";
            }
            
            // 2. создание объекта класса Student с этими полями и запись его в БД

            DbConnector.PutStudent(new Student(this.name.Text, this.surname.Text, this.patronymic.Text, this.group.SelectedValue.ToString(), this.phonenumber.Text, this.email.Text));            // этот метод не готов. в нем надо подробно описать список SQL запросов - в какие таблицы БД какие данные идут
            // 3. вывод об успешном создании студента?

            // 4. обнулить значения текстовых полей в каждом элементе этой формы 
        }

        private void jobtitles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void currentpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var primaryKeyValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                DbConnector DbConnector = new DbConnector();
                DbConnector.DeleteRecord(primaryKeyValue);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}