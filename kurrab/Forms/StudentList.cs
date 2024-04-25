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

using kurrab.Classes;

namespace kurrab.Forms
{
    public partial class StudentList : Form
    {
        // форма отображает данные о студентах
        public StudentList()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; // prohibit editing
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.DataSource = DbConnector.getStudentList();
            this.dataGridView1.DataMember = "ListStudents";
        }

        private void StudentList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
