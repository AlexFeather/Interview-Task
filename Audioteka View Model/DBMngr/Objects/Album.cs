using DBMngr.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Objects
{
    public class Album
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Author Author { get; private set; }
        public int ReleaseYear { get; private set; }


        public Album(int id, string name, Author author, int releaseYear)
        {
            Id = id;
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public Album(AlbumDTO DTO)
        {
            Id = DTO.Id;
            Name = DTO.Name;
            if (DTO.AuthorId != 0)
            {
                Author = DefineAuthor(DTO.AuthorId);
            }
            else
            {
                Author = null;
            }
            ReleaseYear = DTO.ReleaseYear;

        }

        public Author DefineAuthor(int authorId)
        {
            return Program.mng.AuthorsCtrl.AuthorsList.Find(x => x.Id == authorId);
        }

    }
}
