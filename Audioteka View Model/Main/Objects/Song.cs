using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Objects
{
    public class Song
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ReleaseYear { get; private set; }
        public Author Author { get; private set; }
        public Genre Genre { get; private set; }
        public Album Album { get; private set; }

        public Song(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void MakeObjectFromDTO(SongDTO songDTO)
        {

        }

        public void SetReleaseYear(int year)
        {
            ReleaseYear = year;
        }

        public void SetAuthor(Author author)
        {
            Author = author;
        }

        public void SetGenre(Genre genre)
        {
            Genre = genre;
        }

        public void SetAlbum(Album album)
        {
            Album = album;
        }
    }
}
