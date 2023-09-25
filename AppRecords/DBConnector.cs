using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AppRecords
{
    internal class DBConnector
    {
        public static string host = "localhost";
        public static string port = "5432";
        public static string dbname = "app_records";
        public static string username = "ivan";
        public static string pswd = "";

        private NpgsqlConnection _connection = null;

        public NpgsqlConnection open()
        {
            var strConnection = string.Format(
                "Host={0};Port={1};Database={2};Username={3};Password={4}",
                host,
                port,
                dbname,
                username,
                pswd
            );
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(strConnection);
                _connection.Open();
            }
            return _connection;
        }

        public void close()
        {
            if (_connection == null)
            {
                throw new Exception("Connection not exist");
            }
            _connection.Close();
            _connection = null;
        }

        public NpgsqlConnection connection()
        {
            if (_connection == null)
            {
                throw new Exception("Connection not exist");
            }
            return _connection;
        }
    }
}

