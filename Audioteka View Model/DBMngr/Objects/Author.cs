using DBMngr.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Objects
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Author(AuthorDTO DTO)
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
