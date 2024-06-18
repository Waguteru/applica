using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp10
{
    public class DataBase
    {
        NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; port = 5432; DataBase = application_test; User Id = postgres; Password = 123");

        public void ConnectionOpen()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void ConnectionClose()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public NpgsqlConnection GetConnection()
        {
            return connection;
        }
    }
}
