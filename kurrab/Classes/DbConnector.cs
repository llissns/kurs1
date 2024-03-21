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
    }
}
