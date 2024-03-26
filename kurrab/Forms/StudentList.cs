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
        public StudentList()
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
            
            this.dataGridView1.DataSource = DbConnector.getStudentList();
            this.dataGridView1.DataMember = "ListStudents";
            
        }

        private void StudentList_Load(object sender, EventArgs e)
        {

        }
    }
}
