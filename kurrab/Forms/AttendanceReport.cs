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
    // форма отвечает за отчет о посещаемости студентов. есть поиск
    public partial class AttendanceReport : Form
    {
        // это дочерняя форма позволяет добавить запись в отчет о посещаемости
        Form absencerecordForm;
        public AttendanceReport()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
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

        // эта кнопка открывает дочернюю форму где можно добавить запись в отчет о посещаемости
        private void button1_Click_1(object sender, EventArgs e)
        {
            // создаем новый класс формы
            absencerecordForm = new absencerecord();

            // отображаем на экране
            absencerecordForm.ShowDialog();

            // загружаем в датагрид текущей формы обновленную информацию о посещаемости студентов (тк дочерняя форма могла добавить туда запись)
            this.dataGridView1.DataSource = DbConnector.getAttendanceReport();
            this.dataGridView1.DataMember = "AttendanceReport";
        }
    }
}
