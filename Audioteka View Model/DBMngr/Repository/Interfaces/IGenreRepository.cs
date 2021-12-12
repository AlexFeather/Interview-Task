using DBMngr.Objects;
using DBMngr.DTO;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Repository
{
    interface IGenreRepository : IRepository<GenreDTO>
    {
        public List<GenreDTO> GetAllGenresList();
        public GenreDTO GetGenreById(int id);
        public void CreateNewGenre(string name);
        public void DeleteGenreById(int id);
        public void UpdateGenreNameById(int id, string newName);

    }
}
