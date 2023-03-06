using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace EFGetStarted
{
    public class SqliteAdo
    {
        public void Ado()
        {
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                @"
                    SELECT name
                    FROM user
                    WHERE id = $id
                ";

                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
        }
    }
}