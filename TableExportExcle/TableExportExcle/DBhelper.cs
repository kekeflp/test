using Sap.Data.Hana;
using System.Configuration;
using System.Data;

namespace TableExportExcle
{
    public class DBhelper
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        public static bool Update(string sql, params HanaParameter[] parameters)
        {
            using (HanaConnection connection = new HanaConnection(_connectionString))
            {
                using (HanaCommand cmd = new HanaCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static object SelectForScalar(string sql, params HanaParameter[] parameters)
        {
            using (HanaConnection connection = new HanaConnection(_connectionString))
            {
                using (HanaCommand cmd = new HanaCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static HanaDataReader? SelectForDataReader(string sql, params HanaParameter[] parameters)
        {
            using (HanaConnection connection = new HanaConnection(_connectionString))
            {
                using (HanaCommand cmd = new HanaCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
        }

        public static DataTable ExecuteTable(string sql, params HanaParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (HanaConnection connection = new HanaConnection(_connectionString))
            {
                using (HanaDataAdapter hda = new HanaDataAdapter(sql, connection))
                {
                    if (parameters != null)
                    {
                        hda.SelectCommand.Parameters.AddRange(parameters);
                    }
                    hda.Fill(dt);
                }
                return dt;
            }
        }
    }
}
