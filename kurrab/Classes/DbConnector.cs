﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using MySql.Data.MySqlClient;
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
        DbProviderFactory factory = new MySqlClientFactory();
        DbConnection cxn;
        private static object rowsAffected;

        static string connectionString = "dummy";

        DbConnector()
        {
            cxn = factory.CreateConnection();
            cxn.ConnectionString = "server=localhost;port=3306;Database=kurrab;user id=root;password=28082005;SslMode=none;Convert Zero Datetime=True";
        }

        /// <summary>
        /// Метод выбирает все учетные данные из таблицы (нужно например для сверки с введенными в форме аутентификации)
        /// </summary>

        public static List<String> getTitle()
        {
            string queryString = "SELECT * FROM JobTitle";
            List<String> result = new List<String>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
            }

            return result;
        }

        public static List<String> getSpeciality()
        {
            string queryString = "SELECT * FROM Speciality";
            List<String> result = new List<String>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
            }

            return result;
        }
        public static List<String> getCourse()
        {
            string queryString = "SELECT * FROM Course";
            List<String> result = new List<String>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
            }

            return result;
        }
        public static List<String> getGroups()
        {
            string queryString = "SELECT * FROM [Group]";
            List<String> result = new List<String>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
            }

            return result;
        }

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
            string queryString = "SELECT [ListStudents].[surname] & ' ' & [ListStudents].[name] & ' ' & [ListStudents].[patronymic] AS [full_name], [Group].[group] FROM ListStudents " +
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
        public static void PutStudent(Student student)
        {
            string query = $"INSERT INTO ListStudents([name], [surname], [patronymic], [group], [phonenumber], [email]) VALUES (@name, @surname, @patronymic, @group, @phonenumber,@email)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@surname", student.surname);
                command.Parameters.AddWithValue("@patronymic", student.patronymic);


                // calculating group ID value
                connection.Open();
                OleDbDataReader reader = new OleDbCommand($"SELECT id FROM [Group] WHERE [group]='{student.group}'", connection).ExecuteReader();
                while (reader.Read())
                {
                    //reading the groupID value from query, setting it as @group parameter value to current SQL command
                    command.Parameters.AddWithValue("@group", reader.GetInt32(0));

                }

                reader.Close();

                command.Parameters.AddWithValue("@phonenumber", student.phonenumber);
                command.Parameters.AddWithValue("@email", student.email);

                // executing current query
                command.ExecuteNonQuery();
            }
        }
        private bool ValidateCurrentPassword(string currentPassword)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Authentication WHERE password = @CurrentPassword";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrentPassword", currentPassword);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        private bool UpdatePasswordInDatabase(string newPassword)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "UPDATE Authentication SET password = @NewPassword WHERE login = @login";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@login", 1);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public static string GetUserHash(string username)
        { 
            string query = $"SELECT password FROM [Authentication] WHERE [login] = @login ";
            string userHash = "";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@login", username);
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userHash = reader["password"].ToString();
                }
                reader.Close();
            }
            return userHash;
        }
    }
}
