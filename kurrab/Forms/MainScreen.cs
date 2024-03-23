using kurrab.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        List<Credential> authdata = DbConnector.getCredentials();
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
