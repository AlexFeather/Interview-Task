using System;
using System.Collections.Generic;
using System.Text;

namespace Main.DTO
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
    }
}
