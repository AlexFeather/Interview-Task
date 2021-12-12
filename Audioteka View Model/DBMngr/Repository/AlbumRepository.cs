using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBMngr.Objects;
using DBMngr.DTO;

namespace DBMngr.Repository
{
    class AlbumRepository : IAlbumRepository
    {
        private string conStr = @"Data Source = .\ALFEATSQLSERVER; Initial Catalog = Audioteka; Integrated Security = true";
        public int CreateNewAlbum(string name)
        {
            SqlConnection cn = new SqlConnection(conStr);
            int createdId;
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC AddAlbum @name = '{name}'; SELECT @@IDENTITY";
                SqlDataReader rdr = com.ExecuteReader();
                rdr.Read();
                createdId = (int)rdr.GetDecimal(0);
                cn.Close();
            }
            return createdId;
        }

        public void DeleteAlbumById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC DeleteAlbumById @id = {id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public AlbumDTO GetAlbumById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAlbumById @id = {id}";
                SqlDataReader rdr = com.ExecuteReader();
                rdr.Read();
                AlbumDTO result = new AlbumDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3));
                cn.Close();
                return result;
            }
        }

        public List<AlbumDTO> GetAlbumsListByAuthor(Author author)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<AlbumDTO> result = new List<AlbumDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAlbumsListByAuthor @authorId = {author.Id}";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new AlbumDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3)));
                }
                cn.Close();
            }
            return result;
        }

        public List<AlbumDTO> GetAlbumsListByYear(int year)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<AlbumDTO> result = new List<AlbumDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAlbumsListByAuthor @year = {year}";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new AlbumDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3)));
                }
                cn.Close();
            }
            return result;
        }

        public List<AlbumDTO> GetAllAlbumsList()
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<AlbumDTO> result = new List<AlbumDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAlbumsListFull";
                SqlDataReader rdr = com.ExecuteReader();
                while(rdr.Read())
                {
                    result.Add(new AlbumDTO(rdr));
                }
                cn.Close();
            }
            return result;
        }

        public void UpdateAlbumAuthorById(int id, Author author)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateAlbumSetAuthorById @Id = {id}, @AuthorId = {author.Id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateAlbumNameById(int id, string newName)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateAlbumSetNameById @Id = {id}, @Name = {newName}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateAlbumReleaseYearById(int id, int releaseYear)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateAlbumAddYearByID @Id = {id}, @newReleaseYear = {releaseYear}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
