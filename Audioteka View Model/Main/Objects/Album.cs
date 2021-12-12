using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Objects
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
    }
}
