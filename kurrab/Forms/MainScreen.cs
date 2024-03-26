﻿using kurrab.Classes;
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
    public partial class MainScreen : Form
    {
        public static bool isUserAuthenticated = false;    // shows if user already authenticated or not
        public static string userName = "";       // saves username for later purposes

        // child forms declaration
        Form settingsForm, authenticationForm, attendancereportForm, studentlistForm, addingandremovingstudentsForm, listteachersForm, Registration;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // other form initialization


        }

        private void button5_Click(object sender, EventArgs e)
        {
            // getting DB credentials first
            List<Credential> authdata = DbConnector.getCredentials();
            authenticationForm = new Authentication(authdata);
            authenticationForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listteachersForm = new ListTeachers();
            listteachersForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registration = new Registration();
            Registration.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addingandremovingstudentsForm = new AddingAndRemovingStudents();
            addingandremovingstudentsForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentlistForm = new StudentList();
            studentlistForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            attendancereportForm = new AttendanceReport();
            attendancereportForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            settingsForm = new SettingsScreen();
            settingsForm.ShowDialog();
        }
    }
}
