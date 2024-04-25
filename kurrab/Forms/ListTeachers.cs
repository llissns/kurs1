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
        // форма показывает список учетилей
        public ListTeachers()
        {
            // системная инициализация компонентов формы
            InitializeComponent();
            
            // задаем датагриду свойство генерировать столбцы автоматически (из датасета)
            this.dataGridView1.AutoGenerateColumns = true;

            // задаем режим отображения столбцов
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // задаем стиль границ датагрида
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // задаем режим редактирования
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            // задаем источник данных для грида (из датасета)
            this.dataGridView1.DataSource = DbConnector.getListTeachers();

            // указываем определенную таблицу датасета для отображения в датагриде
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
