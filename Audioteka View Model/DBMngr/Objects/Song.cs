using DBMngr.DTO;
using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Objects
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

        public Song(SongDTO DTO)
        {
            Id = DTO.Id;
            Name = DTO.Name;
            ReleaseYear = DTO.ReleaseYear;
            if (DTO.GenreId != 0)
            {
                DefineGenre(DTO.GenreId);
            }
            else
            {
                Genre = null;
            }
            if(DTO.AuthorId != 0)
            {
                DefineAuthor(DTO.AuthorId);
            }
            else
            {
                Author = null;
            }
            if(DTO.AlbumId != 0)
            {
                DefineAlbum(DTO.AlbumId);
            }
            else
            {
                Album = null;
            }
            
        }

        private Genre DefineGenre(int genreId)
        {
            return Program.mng.GenresCtrl.GenresList.Find(x => x.Id == genreId);
        }

        public Author DefineAuthor(int authorId)
        {
            return Program.mng.AuthorsCtrl.AuthorsList.Find(x => x.Id == authorId);
        }

        public Album DefineAlbum(int albumId)
        {
            return Program.mng.AlbumsCtrl.AlbumsList.Find(x => x.Id == albumId);
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
