using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.DTO
{
    public class GenreDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public GenreDTO (int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
