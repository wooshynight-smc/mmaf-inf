using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using mmaf_inf.Models;


namespace mmaf_inf.Database
{
    public static class DatabaseConnector
    {

        public static List<Dictionary<string, object>> GetRows(string query)
        {
            // stel in waar de database gevonden kan worden
            string connectionString = "Data Source=mmafdb.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            // maak een lege lijst waar we de namen in gaan opslaan
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();


            // verbinding maken met de database
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                // SQL query die we willen uitvoeren
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    var tableData = reader.GetSchemaTable();

                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();

                        // haal voor elke kolom de waarde op en voeg deze toe
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }

                        rows.Add(row);
                    }
                }
            }

            // return de lijst met namen
            return rows;

        }
    }
}