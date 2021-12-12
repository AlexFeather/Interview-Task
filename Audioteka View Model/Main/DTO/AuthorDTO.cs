using System;
using System.Collections.Generic;
using System.Text;

namespace Main.DTO
{
    public class AuthorDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public AuthorDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
