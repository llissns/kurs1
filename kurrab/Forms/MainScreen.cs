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
    public partial class MainScreen : Form
    {
        public static bool isUserAuthenticated = false;    // shows if user already authenticated or not
        public static string userName = "";       // saves username for later purposes

        // child forms declaration
        Form settingsForm, authenticationForm;

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

        private void button6_Click(object sender, EventArgs e)
        {
            settingsForm = new SettingsScreen();
            settingsForm.ShowDialog();
        }
    }
}
