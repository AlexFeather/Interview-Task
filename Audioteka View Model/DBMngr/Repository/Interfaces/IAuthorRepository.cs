using DBMngr.DTO;
using DBMngr.Objects;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Repository
{
    interface IAuthorRepository : IRepository<AuthorDTO>
    {
        public List<AuthorDTO> GetAllAuthorsList();
        public AuthorDTO GetAuthorById(int id);
        public void CreateNewAuthor(string name);
        public void DeleteAuthorById(int id);
        public void UpdateAuthorNameById(int id, string newName);
    }
}
