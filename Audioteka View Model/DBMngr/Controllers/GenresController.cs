using DBMngr.DTO;
using DBMngr.Objects;
using DBMngr.Repository;
using System.Collections.Generic;

namespace DBMngr.Controllers
{
    public class GenresController
    {
        public List<Genre> GenresList { get; set; }
        GenreRepository repo = new GenreRepository();

        public void InititalSequence()
        {
            GenresList = new List<Genre>();
            GetGenresList();
        }

        public void GetGenresList()
        {
            if (GenresList.Count > 0)
            {
                GenresList.Clear();
            }

            List<GenreDTO> DTOs = repo.GetAllGenresList();
            foreach (GenreDTO element in DTOs)
            {
                GenresList.Add(new Genre(element));
            }

        }

        public void CreateNewGenre(string name)
        {
            repo.CreateNewGenre(name);
            GetGenresList();
        }

        public bool DeleteGenre(Genre genre)
        {
            if (GenresList.Find(x => x.Id.Equals(genre.Id)) != null)
            {
                GenresList.Remove(genre);
                repo.DeleteGenreById(genre.Id);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateGenreSetName(Genre genre, string newName)
        {
            Genre found = GenresList.Find(x => x.Id.Equals(genre.Id));
            if (found != null)
            {
                found.SetName(newName);
                repo.UpdateGenreNameById(genre.Id, newName);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
