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

namespace kurrab
{
    public partial class absencerecord : Form
    {
        public absencerecord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataBindings.Clear();
            comboBox1.DataSource = DbConnector.getAttendanceReport().Tables[0];
            comboBox1.DisplayMember = "student_id";
            comboBox1.ValueMember = "id";

            comboBox2.DataBindings.Clear();
            comboBox2.DataSource = DbConnector.getSubject().Tables[0];
            comboBox2.DisplayMember = "subject";
            comboBox2.ValueMember = "ID";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
