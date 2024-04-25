using kurrab.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurrab.Forms
{
    // форма представляет из себя меню из кнопок, которые уже в свою очередь отвечают за отдельные функции программы
    // сама по себе эта форма ничего не делает, лишь открывает другие формы
    public partial class MainScreen : Form
    {

        // заранее готовим список форм , чтобы хранить их состояния (не реализовано)
        Form settingsForm, authenticationForm, attendancereportForm, studentlistForm,listteachersForm, Registration;

        // инициализация компонентов 
        public MainScreen()
        {
            InitializeComponent();
        }
        
        // открывается форма со списком учетилей
        private void button7_Click(object sender, EventArgs e)
        {
            listteachersForm = new ListTeachers();
            listteachersForm.ShowDialog();
        }

        // открывается форма со списком студентов
        private void button2_Click(object sender, EventArgs e)
        {
            studentlistForm = new StudentList();
            studentlistForm.ShowDialog();
        }

        // открывается форма отчета посещаемости
        private void button1_Click(object sender, EventArgs e)
        {
            attendancereportForm = new AttendanceReport();
            attendancereportForm.ShowDialog();
        }

        // открывается форма настроек
        private void button6_Click(object sender, EventArgs e)
        {
            settingsForm = new SettingsScreen();
            settingsForm.ShowDialog();
        }
    }
}
