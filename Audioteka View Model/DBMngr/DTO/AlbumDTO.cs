using System.Data.SqlClient;

namespace DBMngr.DTO
{
    public class AlbumDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AuthorId { get; private set; }
        public int ReleaseYear { get; private set; }

        public AlbumDTO(int id, string name, int authorId, int releaseYear)
        {
            Id = id;
            Name = name;
            AuthorId = authorId;
            ReleaseYear = releaseYear;
        }

        public AlbumDTO(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            Name = reader.GetString(1);
            if(!reader.IsDBNull(2))
            {
                AuthorId = reader.GetInt32(2);
            }
            if(!reader.IsDBNull(3))
            {
                ReleaseYear = reader.GetInt32(3);
            }

        }
    }
}
