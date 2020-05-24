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
        public static DataModel[] Execute(string query)
        {
            var cmd = new MySqlCommand(query, _connection);
            var result = new DataTable();
            result.Load(cmd.ExecuteReader());
            
            if (result.Rows.Count <= 0) return null;
            switch (result.ToString())
            {
                //TO ADD NEW TABLE SUPPORT, USE THE FOLLOWING CODE
                /*case "table_name":
                    var objects = result.AsEnumerable().Select(
                        x => new ExampleClass(
                            x[0] -> arg0,
                            x[1] -> arg1,
                            etc.
                        )
                    ).ToArray();
                    return objects;*/
                default:
                    return null;
            }
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
    }
}