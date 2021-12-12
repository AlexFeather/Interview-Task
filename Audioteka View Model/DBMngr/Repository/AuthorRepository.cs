using DBMngr.DTO;
using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBMngr.Repository
{
    class AuthorRepository : IAuthorRepository
    {
        private string conStr = @"Data Source = .\ALFEATSQLSERVER; Initial Catalog = Audioteka; Integrated Security = true";
        public void CreateNewAuthor(string name)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.AddAuthor @name = '{name}'";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void DeleteAuthorById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC dbo.DeleteAuthorById @id = {id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<AuthorDTO> GetAllAuthorsList()
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<AuthorDTO> result = new List<AuthorDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"SELECT * FROM Authors";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new AuthorDTO(rdr.GetInt32(0), rdr.GetString(1)));
                }
                cn.Close();
                return result;
            }
        }

        public AuthorDTO GetAuthorById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAuthorById @id = {id}";
                SqlDataReader rdr = com.ExecuteReader();
                rdr.Read();
                AuthorDTO result = new AuthorDTO(rdr.GetInt32(0), rdr.GetString(1));
                cn.Close();
                return result;
            }
        }

        public void UpdateAuthorNameById(int id, string newName)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateAuthorById @id = {id}, @new_name = '{newName}'";
                cn.Close();
            }
        }
    }
}
