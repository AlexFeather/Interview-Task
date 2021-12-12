using DBMngr.DTO;
using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBMngr.Repository
{
    class SongsRepository : ISongsRepository
    {
        private string conStr = @"Data Source = .\ALFEATSQLSERVER; Initial Catalog = Audioteka; Integrated Security = true";

        public int AddSong(string name)
        {
            SqlConnection cn = new SqlConnection(conStr);
            int createdId;
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC AddSong @name = '{name}'; SELECT @@IDENTITY";
                SqlDataReader rdr = com.ExecuteReader();
                rdr.Read();
                createdId = (int)rdr.GetDecimal(0);
                cn.Close();
            }
            return createdId;
        }

        public void DeleteSongById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC DeleteSongById @id = {id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<SongDTO> GetAllSongsList()
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<SongDTO> result = new List<SongDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetAllSongsList";
                SqlDataReader rdr = com.ExecuteReader();
                while(rdr.Read())
                {
                    result.Add(new SongDTO(rdr));
                }
                cn.Close();
            }
            return result;
        }

        public SongDTO GetSongById(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetSongById @Id = {id}";
                SqlDataReader rdr = com.ExecuteReader();
                SongDTO result = new SongDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                cn.Close();
                return result;
            }
        }

        public List<SongDTO> GetSongsListByAlbum(Album album)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<SongDTO> result = new List<SongDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetSongsListByAlbum @AlbumId = {album.Id}";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new SongDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5)));
                }
                cn.Close();
            }
            return result;
        }

        public List<SongDTO> GetSongsListByAuthor(Author author)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<SongDTO> result = new List<SongDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetSongsListByAlbum @AuthorId = {author.Id}";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new SongDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5)));
                }
                cn.Close();
            }
            return result;
        }

        public List<SongDTO> GetSongsListByYear(int year)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<SongDTO> result = new List<SongDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC GetSongsListByYear @ReleaseYear = {year}";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new SongDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5)));
                }
                cn.Close();
            }
            return result;
        }

        public void UpdateSongAlbumById(int id, Album album)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateSongSetAlbumById @Id = {id}, @AlbumId = {album.Id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateSongAuthorById(int id, Author author)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateSongSetAuthorById @Id = {id}, @AuthorId = {author.Id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateSongGenreById(int id, Genre genre)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateSongSetGenreById @Id = {id}, @GenreId = {genre.Id}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateSongNameById(int id, string newName)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateSongSetNameById @Id = {id}, @Name = '{newName}'";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateSongReleaseYearById(int id, int newReleaseYear)
        {
            SqlConnection cn = new SqlConnection(conStr);
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();
                com.CommandText = $"EXEC UpdateSongSetReleaseYearById @Id = {id}, @ReleaseYear= {newReleaseYear}";
                com.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<SongDTO> GetFilteredList(Author author, Album album, Genre genre, int year)
        {
            SqlConnection cn = new SqlConnection(conStr);
            List<SongDTO> result = new List<SongDTO>();
            using (SqlCommand com = cn.CreateCommand())
            {
                cn.Open();

                int condCount = 0;
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM Songs");
                if (author != null || album != null || genre != null || year != 0)
                {
                    sb.Append(" WHERE");
                }
                if (author != null)
                {
                    sb.Append($" author_id = {author.Id}");
                    condCount++;
                }
                if (album != null)
                {
                    if (condCount > 0)
                    {
                        sb.Append(" AND");
                    }
                    sb.Append($" album_id = {album.Id}");
                }
                if (genre != null)
                {
                    if (condCount > 0)
                    {
                        sb.Append(" AND");
                    }
                    sb.Append($" genre_id = {genre.Id}");
                }
                if (year != 0)
                {
                    if (condCount > 0)
                    {
                        sb.Append(" AND");
                    }
                    sb.Append($" release_year = {year}");
                }


                com.CommandText = sb.ToString();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(new SongDTO(rdr));
                }
                cn.Close();
            }
            return result;
        }
    }
}
