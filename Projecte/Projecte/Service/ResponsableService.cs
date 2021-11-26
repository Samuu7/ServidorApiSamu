using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Projecte.Entity;
using Projecte.Persistence;

namespace Projecte.Service
{
    class ResponsableService
    {

        //Crear taula responsables
        public static IEnumerable<Responsable> GetAll()
        {
            var result = new List<Responsable>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Responsable
                            {
                                ID = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),
                                
                            });
                        }
                    }
                }
            }
            return result;
        }
        public static int Add(Responsable responsable)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO Responsable (name) VALUES (?)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", responsable.Name));
                 

                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }
        public static int Delete(int ID)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM Responsable WHERE Id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", ID));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }

    }


}


