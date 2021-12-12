using DBMngr.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Objects
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Genre(GenreDTO DTO)
        {
            Id = DTO.Id;
            Name = DTO.Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
