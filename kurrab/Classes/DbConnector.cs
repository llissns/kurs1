using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace kurrab.Classes
{
    internal class DbConnector
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Admin\\Desktop\\Database51.accdb";

        public static string getCredentials()
        {
            string queryString = "SELECT * FROM Authentication";
            string result = "";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result += reader.GetString(1) + ":" + reader.GetString(2) + "\n\r";
                }
                reader.Close();
            }

            return result;
        }
        public class Credential
        {
            public string Login { get; set; }
            private string PasswordHash { get; set; }

            public Credential(string login, string password)
            {
                Login = Login;
                PasswordHash = password;
            }
           
        }
       
    }
}
