using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kurrab.Classes
{
    /// <summary>
    /// класс отвечает за общение с базой данных - чтение, запись, поиск и тд
    /// </summary>
    internal class DbConnector
    {
        // основная строка подключения к серверу СУБД. она используется далее в методах
        // хранить логин и пароль в ней в данном случае безопасно тк для соединения с сервером  СУБД мы используем ВПН, который
        // имеет свою аутентификацию и никто чужой в нашу БД не зайдет.
        static string connectionString = "server=172.20.7.45;port=3306;username=st3996_24;password=pwd3996_24;database=db_3996_24_idz";

        // возвращает все значения должностей, которые предусматривает БД - студент, препоадаватель и тд.
        public static DataSet getTitle()
        {
            // создаем объект соединения к СУБД используя строку подключения
            // using удалит объект из памяти при завершении этого блока кода.
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // открываем соединение
                conn.Open();

                // указываем строку SQL для выполнения на сервере СУБД
                string sql = "SELECT * FROM jobtitle";

                // создаем обоъект датаСет где будем хранить результат
                DataSet ds = new DataSet();

                // создаем объект комманды СУБД
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // создаем объект подключения к СУБД
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                // заполняем датасет ответом от СУБД используя адаптер
                adapter.Fill(ds, "jobtitle");

                // возвращаем ответ
                return ds;
            }
        }

        // возвращает все значения учебных предметов
        public static DataSet getSubject()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM subject";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "subject");
                return ds;
            }
        }

        // возвращает все значения специальностей студентов
        public static DataSet getSpeciality()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM speciality";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "speciality");
                return ds;
            }
        }

        // возвращает все значения курсов студентов
        public static DataSet getCourse()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM course";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "course");
                return ds;
            }
        }

        // возвращает все значения групп
        public static DataSet getGroups()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM `groups`";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "groups");
                return ds;
            }
        }

        // возвращает ответ из представления с инфомрацией о студентах
        public static DataSet getStudentList()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM student_info";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "liststudents");
                return ds;
            }
        }

        // возвращает ответ из представления с инфомрацией о учителях
        public static DataSet getListTeachers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM teacher_info";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "listteacher");
                return ds;
            }
        }
        
        // возвращает значение хеша пароля определенного пользователя
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

        // возвращает отчет о посещаемости из представления
        public static DataSet getAttendanceReport()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM attendancereport_info";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "AttendanceReport");

                return ds;
            }
        }

        // возвращает все значения прав пользователя (не реализовано)
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

        // возвращает все значения учетных данных (пары логин-хеш)
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
        // возвращает отчет о посещаемости (поиск)
        public static DataSet searchAttendanceReport(int groupname, string subject)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM attendancereport_info WHERE groupname = @groupname AND subject = @subject";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@groupname", groupname);
                cmd.Parameters.AddWithValue("@subject", subject);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds, "AttendanceReport");

                return ds;
            }
        }

        // удалет запись об определенном студенте
        public void DeleteRecord(int recordID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM liststudents WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", recordID);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена из базы данных.");
            }
        }

        // добавляет запись о студенте
        public static void PutStudent(Student student)
        {
            string sql = $"INSERT INTO liststudents(`name`, `surname`, `patronymic`, `groupname`, `phonenumber`, `email`) VALUES (@name, @surname, @patronymic, @groupid, @phonenumber, @email)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sql, conn);

                // заполняем переменные в комманде к СУБД значениями
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@surname", student.surname);
                command.Parameters.AddWithValue("@patronymic", student.patronymic);
                command.Parameters.AddWithValue("@groupid", student.group);
                command.Parameters.AddWithValue("@phonenumber", student.phonenumber);
                command.Parameters.AddWithValue("@email", student.email);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        // добавляет запись в отчет о посещаемости
        public static void putAttendanceRecord(object studentid,object subjectid, string abscensedate)
        {
            string sql = "INSERT INTO AttendanceReport(`student_id`,`subject`,`abscense`) VALUES (@studentid,@subjectid, @abscensedate)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@studentid", studentid);
                command.Parameters.AddWithValue("@subjectid", subjectid);
                command.Parameters.AddWithValue("@abscensedate", abscensedate);
                
                // executing current query
                command.ExecuteNonQuery();
            }
        }
    }
}
