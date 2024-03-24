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
            List<Student> studentList = DbConnector.getStudentList();
           
        }
    }
}
