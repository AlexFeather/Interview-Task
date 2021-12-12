using DBMngr.DTO;
using DBMngr.Objects;
using DBMngr.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Controllers
{
    public class AuthorsController
    {
        public List<Author> AuthorsList { get; set; }
        AuthorRepository repo = new AuthorRepository();

        public void InitialSequence()
        {
            AuthorsList = new List<Author>();
            GetAuthorsList();
        }

        public void GetAuthorsList()
        {
            if(AuthorsList.Count > 0)
            {
                AuthorsList.Clear();
            }

            List<AuthorDTO> DTOs = repo.GetAllAuthorsList();
            foreach(AuthorDTO element in DTOs)
            {
                AuthorsList.Add(new Author(element));
            }

        }

        public Author GetAuthorById(int Id)
        {
            return new Author(repo.GetAuthorById(Id));
        }

        public void CreateNewAuthor(string name)
        {
            repo.CreateNewAuthor(name);
            GetAuthorsList();
        }

        public bool DeleteAuthor(Author author)
        {
            if (AuthorsList.Find(x => x.Id.Equals(author.Id)) != null)
            {
                AuthorsList.Remove(author);
                repo.DeleteAuthorById(author.Id);
                GetAuthorsList();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool UpdateAuthorSetName(Author author, string newName)
        {
            Author found = AuthorsList.Find(x => x.Id.Equals(author.Id));
            if (found != null)
            {
                found.SetName(newName);
                repo.UpdateAuthorNameById(author.Id, newName);
                GetAuthorsList();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
