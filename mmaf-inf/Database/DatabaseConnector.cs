using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace mmaf_inf.Database
{
    public static class DatabaseConnector
    {

        public static List<Dictionary<string, object>> GetRows()
        {
            // stel in waar de database gevonden kan worden
            //string connectionString = "Server=172.16.160.21;Port=3306;Database=110633;Uid=110633;Pwd=inf2122sql;";
            //string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110633;Uid=110633;Pwd=inf2122sql;";

            // maak een lege lijst waar we de namen in gaan opslaan
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            using (var connection = new SqliteConnection("Data Source=database.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    SELECT name
                    FROM artist
                    ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }


            // return de lijst met namen
            return rows;
        }

    }
}