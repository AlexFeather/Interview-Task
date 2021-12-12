using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Main.DTO
{
    public class SongDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ReleaseYear { get; private set; }
        public int AuthorId { get; private set; }
        public int GenreId { get; private set; }
        public int AlbumId { get; private set; }

        public SongDTO(int id, string name, int releaseYear, int authorId, int genreId, int albumId)
        {
            Id = id;
            Name = name;
            ReleaseYear = releaseYear;
            AuthorId = authorId;
            GenreId = genreId;
            AlbumId = albumId;
        }

        public SongDTO(Song song)
        {
            Id = song.Id;
            Name = song.Name;
            ReleaseYear = song.ReleaseYear;
            if(song.Author != null)
            {
                AuthorId = song.Author.Id;
            }
            else
            {
                AuthorId = 0;
            }
            if(song.Genre != null)
            {
                GenreId = song.Genre.Id;
            }
            else
            {
                GenreId = 0;
            }
            if(song.Album != null)
            {
                AlbumId = song.Album.Id;
            }
            else
            {
                AlbumId = 0;
            }


        }
    }
}
