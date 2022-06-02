using System.Data;
using System.Data.SQLite;

namespace TableExportExcle
{
    public class DBhelper
    {
        private const string _connectionString = @"Data Source=C:\Users\kekef\AppData\Roaming\DBeaverData\workspace6\.metadata\sample-database-sqlite-1\Chinook.db;";

        private static SQLiteConnection Con => new SQLiteConnection(_connectionString);

        private static SQLiteCommand Cmd => Con.CreateCommand();

        public static bool Update(string sql, params SQLiteParameter[] parameters)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
      
        public static object SelectForScalar(string sql, params SQLiteParameter[] parameters)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

      
        public static SQLiteDataReader? SelectForDataReader(string sql, params SQLiteParameter[] parameters)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception)
            {
                cmd.Connection.Close();
                return null;
            }
        }


        public static DataTable ExecuteTable(string sql, params SQLiteParameter[] parameters)
        {
            var dt = new DataTable();
            using (var sda = new SQLiteDataAdapter(sql, Con))
            {
                if (parameters != null)
                {
                    sda.SelectCommand.Parameters.AddRange(parameters);
                }
                sda.Fill(dt);
            }
            return dt;
        }

    }
}
