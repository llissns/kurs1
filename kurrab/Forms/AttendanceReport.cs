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
    public partial class AttendanceReport : Form
    {
        public AttendanceReport()
        {
            InitializeComponent();
            // Fill the DataSet.
            this.dataGridView1.AutoGenerateColumns = true;

            // Automatically resize the visible rows.
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // Set the DataGridView control's border.
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Put the cells in edit mode when user enters them.
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; // prohibit editing

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dataGridView1.DataSource = DbConnector.getAttendanceReport();
            this.dataGridView1.DataMember = "AttendanceReport";
        }

        private void AttendanceReport_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
