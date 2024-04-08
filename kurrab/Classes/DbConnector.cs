using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
        static string connectionString = "server=localhost;port=3306;Database=kurrab;user id=root;password=28082005;SslMode=none;Convert Zero Datetime=True";

        /// <summary>
        /// Метод выбирает все учетные данные из таблицы (нужно например для сверки с введенными в форме аутентификации)
        /// </summary>

        public static List<String> getTitle()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM jobtitle";
                List<String> result = new List<String>();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
                return result;
            }
        }

        public static List<String> getSpeciality()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM speciality";
                List<String> result = new List<String>();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
                return result;
            }
        }
        public static List<String> getCourse()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM course";
                List<String> result = new List<String>();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
                return result;
            }
        }
        public static List<String> getGroups()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM [group]";
                List<String> result = new List<String>();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(1));
                }
                reader.Close();
                return result;
            }
        }

        public static List<Credential> getCredentials()
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM authentication";
                List<Credential> result = new List<Credential>();
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Credential(reader.GetString(1), reader.GetString(2)));
                }
                reader.Close();
                return result;
            }
        }
    

        // получаем список студентов в датасет - это нужно чтобы загрузить датасет в датагрид
        public static DataSet getStudentList()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT [liststudents].[surname] & ' ' & [liststudents].[name] & ' ' & [liststudents].[patronymic] AS [full_name], [group].[group] FROM liststudents " +
                             "INNER JOIN [group] ON [liststudents].[group]=[group].[ID] " +
                             "ORDER BY [liststudents].surname;";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "liststudents");

                return ds;
            }
        }

        // это понадобится в будущем для заполнения БД через формы
        public static MySqlDataAdapter CreateDataAdapter(string selectCommand)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand, conn);

                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                // Create the Insert, Update and Delete commands.
                adapter.InsertCommand = new MySqlCommand(
                    "INSERT INTO Customers (CustomerID, CompanyName) " +
                    "VALUES (?, ?)");

                adapter.UpdateCommand = new MySqlCommand(
                    "UPDATE Customers SET CustomerID = ?, CompanyName = ? " +
                    "WHERE CustomerID = ?");

                adapter.DeleteCommand = new MySqlCommand(
                    "DELETE FROM Customers WHERE CustomerID = ?");

                // Create the parameters.
                adapter.InsertCommand.Parameters.Add("@CustomerID",
                    MySqlDbType.VarChar, 5, "CustomerID");
                adapter.InsertCommand.Parameters.Add("@CompanyName",
                    MySqlDbType.VarChar, 40, "CompanyName");

                adapter.UpdateCommand.Parameters.Add("@CustomerID",
                    MySqlDbType.VarChar, 5, "CustomerID");
                adapter.UpdateCommand.Parameters.Add("@CompanyName",
                    MySqlDbType.VarChar, 40, "CompanyName");
                adapter.UpdateCommand.Parameters.Add("@oldCustomerID",
                    MySqlDbType.VarChar, 5, "CustomerID").SourceVersion =
                    DataRowVersion.Original;

                adapter.DeleteCommand.Parameters.Add("@CustomerID",
                    MySqlDbType.VarChar, 5, "CustomerID").SourceVersion =
                    DataRowVersion.Original;

                return adapter;
            }
        }
        public static DataSet getListTeachers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM listteacher";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "listteacher");
                return ds;
            }
        }
        public static DataSet getAccessRights()
        {
             using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM accessrights";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "accesrights");
                return ds;
            }
        }
        public static void PutStudent(Student student)
        {
            string sql = $"INSERT INTO liststudents([name], [surname], [patronymic], [group], [phonenumber], [email]) VALUES (@name, @surname, @patronymic, @group, @phonenumber,@email)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@surname", student.surname);
                command.Parameters.AddWithValue("@patronymic", student.patronymic);


                // calculating group ID value
                conn.Open();
                MySqlDataReader reader = new MySqlCommand($"SELECT id FROM [group] WHERE [group]='{student.group}'", conn).ExecuteReader();
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM authentication WHERE password = @CurrentPassword";

                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@CurrentPassword", currentPassword);
                    conn.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        private bool UpdatePasswordInDatabase(string newPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "UPDATE authentication SET password = @NewPassword WHERE login = @login";

                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@login", 1);

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public static string GetUserHash(string username)
        { 
            string sql = $"SELECT password FROM [authentication] WHERE [login] = @login ";
            string userHash = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@login", username);
                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();

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
