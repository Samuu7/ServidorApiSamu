﻿using System;
using System.Data.SQLite;
using System.IO;

namespace Projecte.Persistence
{
    class DbContext
    {
        private const string DBName = "database.sqlite";
        private const string SQLScript = @"..\..\..\Util\database.sql";
        private static bool IsDbRecentlyCreated = false;

        public static void Up()
        {
            // Crea la base de datos solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            using (var ctx = GetInstance())
            {
                // Crea la base de datos solo la primera vez
                if (IsDbRecentlyCreated)
                {
                    using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
                    {
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    /*for (var i = 1; i <= 100; i++)
                    {
                        var query = "INSERT INTO Tasca (name, descripcio, data, data1) VALUES (?, ?, ?)";

                        using (var command = new SQLiteCommand(query, ctx))
                        {

                            command.Parameters.Add(new SQLiteParameter("name", "Name " + i));
                            command.Parameters.Add(new SQLiteParameter("descripcio", "Descripcio " + i));

                            var rnd = new Random();
                            command.Parameters.Add(new SQLiteParameter("data", DateTime.Today.AddDays(-rnd.Next(1, 50))));
                            command.Parameters.Add(new SQLiteParameter("data1", DateTime.Today.AddDays(-rnd.Next(1, 50))));

                            command.ExecuteNonQuery();
                        }
                    }*/
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }
    }
}
