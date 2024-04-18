using kurrab.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurrab
{
    public partial class ListTeachers : Form
    {
        public ListTeachers()
        {
            InitializeComponent();
            //Fill the dataSet.
            this.dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dataGridView1.DataSource= DbConnector.getListTeachers();
            this.dataGridView1.DataMember = "ListTeacher";
        }

        private void ListTeachers_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
