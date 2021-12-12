using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Objects
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
    }
}
