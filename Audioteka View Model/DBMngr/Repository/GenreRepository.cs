using DBMngr.DTO;
using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBMngr.Repository
{
    class GenreRepository : IGenreRepository
    {
        private string conStr = @"Data Source = .\ALFEATSQLSERVER; Initial Catalog = Audioteka; Integrated Security = true";
        public void CreateNewGenre(string name)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.AddGenre @Name = '{name}'"; //INSERT INTO Genres VALUES {Name}
                com.ExecuteNonQuery();
                Console.WriteLine("Creation successful.");
                cn.Close();
            }
        }

        public void DeleteGenreById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.DeleteGenreById @Id = {id}";
                com.ExecuteNonQuery();
                Console.WriteLine("Delete operation successful.");
                cn.Close();
            }
        }

        public List<GenreDTO> GetAllGenresList()
        {
            List<GenreDTO> result = new List<GenreDTO>();
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.GetGenreList";
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new GenreDTO(rdr.GetInt32(0), rdr.GetString(1)));
                }
                rdr.Close();
            }
            cn.Close();
            return result;
        }

        public GenreDTO GetGenreById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.GetGenreById @Id = {id}";
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                rdr.Read();
                GenreDTO result = new GenreDTO(rdr.GetInt32(0), rdr.GetString(1));
                return result;
            }
        }

        public void UpdateGenreNameById(int id, string newName)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.UpdateGenreNameById @Id = {id}, @new_name = '{newName}'"; 
                com.ExecuteNonQuery();;
            }
        }
    }
}
