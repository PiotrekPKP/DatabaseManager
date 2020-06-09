using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DatabaseManager
{
    public static class DbManager
    {
        private static MySqlConnection _connection;
        
        //FUNCTION FOR INITIALIZING DB CONNECTION
        public static bool Initialize(string host, string name, string user, string password)
        {
            if(_connection != null && _connection.State != ConnectionState.Closed) _connection.Close();
            _connection = new MySqlConnection("SERVER=" + host + ";DATABASE=" + name + ";UID=" + user + ";PASSWORD=" + password);
            return OpenConn();
        }

        //OPENING CONNECTION
        private static bool OpenConn()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //EXECUTING QUERIES AND RETURNING OBJECT ARRAY
        public static IEnumerable<DataModel> Execute(MySqlCommand cmd)
        {
            var result = new DataTable();
            result.Load(cmd.ExecuteReader());
            
            if (result.Rows.Count <= 0) return null;
            return result.ToString() switch
            {
                //TO ADD NEW TABLE SUPPORT, USE THE FOLLOWING CODE
                /*"table_name" => result.AsEnumerable()
                    .Select(x => new ExampleClass(
                        x[0], // ARGUMENT 0
                        //etc.
                    ))
                    .ToArray(),*/
                _ => null
            };
        }

        //EXECUTING QUERIES WITHOUT RETURN VALUE
        public static bool PerformAction(string query)
        {
            var cmd = new MySqlCommand(query, _connection);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static MySqlCommand CreateCommand(string query, params string[] data)
        {
            var command = new MySqlCommand(query, _connection);
            var prm = new List<MySqlParameter>();
            for (var i = 0; i < data.Length; i += 2)
            {
                prm.Add(new MySqlParameter(data[i], MySqlDbType.Text) {Value = data[i + 1]});
            }
            command.Parameters.AddRange(prm.ToArray());
            
            return command;
        }
    }
}