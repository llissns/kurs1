using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kurrab.Classes
{
    /// <summary>
    /// класс отвечает за общение с базой данных - чтение, запись, поиск
    /// на рабочей станции где нет MS Access для работы нужно установить Microsoft Access 2016 Runtime
    /// https://www.microsoft.com/en-us/download/details.aspx?id=50040
    /// </summary>
    internal class DbConnector
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=..\\..\\..\\Database51.accdb";

        /// <summary>
        /// Метод выбирает все учетные данные из таблицы (нужно например для сверки с введенными в форме аутентификации)
        /// </summary>
        public static List<Credential> getCredentials()
        {
            string queryString = "SELECT * FROM Authentication";
            List<Credential> result = new List<Credential>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Credential(reader.GetString(1), reader.GetString(2)));
                }
                reader.Close();
            }

            return result;
        }

        // получаем список студентов в датасет - это нужно чтобы загрузить датасет в датагрид
        public static DataSet getStudentList()
        {
            string queryString = "SELECT [ListStudents].surname, [ListStudents].name, [ListStudents].patronymic, [Group].[group] FROM ListStudents " +
                "INNER JOIN [Group] ON [ListStudents].[group]=[Group].[ID] " +
                "ORDER BY [ListStudents].surname;";
            DataSet ds = new DataSet();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(queryString, connection);
                connection.Open();
                dataadapter.Fill(ds, "ListStudents");
                connection.Close();
            }

            // returning dataset
            return ds;
        }

        // это понадобится в будущем для заполнения БД через формы
        public static OleDbDataAdapter CreateDataAdapter(string selectCommand)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) 
            { 
                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, connection);

                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                // Create the Insert, Update and Delete commands.
                adapter.InsertCommand = new OleDbCommand(
                    "INSERT INTO Customers (CustomerID, CompanyName) " +
                    "VALUES (?, ?)");

                adapter.UpdateCommand = new OleDbCommand(
                    "UPDATE Customers SET CustomerID = ?, CompanyName = ? " +
                    "WHERE CustomerID = ?");

                adapter.DeleteCommand = new OleDbCommand(
                    "DELETE FROM Customers WHERE CustomerID = ?");

                // Create the parameters.
                adapter.InsertCommand.Parameters.Add("@CustomerID",
                    OleDbType.Char, 5, "CustomerID");
                adapter.InsertCommand.Parameters.Add("@CompanyName",
                    OleDbType.VarChar, 40, "CompanyName");

                adapter.UpdateCommand.Parameters.Add("@CustomerID",
                    OleDbType.Char, 5, "CustomerID");
                adapter.UpdateCommand.Parameters.Add("@CompanyName",
                    OleDbType.VarChar, 40, "CompanyName");
                adapter.UpdateCommand.Parameters.Add("@oldCustomerID",
                    OleDbType.Char, 5, "CustomerID").SourceVersion =
                    DataRowVersion.Original;

                adapter.DeleteCommand.Parameters.Add("@CustomerID",
                    OleDbType.Char, 5, "CustomerID").SourceVersion =
                    DataRowVersion.Original;

                return adapter;
            }
        }
        public static DataSet getListTeachers()
        {
            string queryString = "SELECT * FROM ListTeacher";
            DataSet ds = new DataSet();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(queryString, connection);
                connection.Open();
                dataAdapter.Fill(ds, "ListTeacher");
                connection.Close();
            }
            return ds;
        }
        public static DataSet getAccessRights()
        {
            string queryString = "SELECT * FROM AccessRights";
            DataSet ds = new DataSet();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(queryString, connection);
                connection.Open();
                dataAdapter.Fill(ds, "AccessRights");
                connection.Close();
            }
            return ds;
        }
            
            
    }
}
