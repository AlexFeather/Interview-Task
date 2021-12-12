using DBMngr.DTO;
using DBMngr.Objects;
using DBMngr.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Controllers
{
    public class AlbumsController
    {
        public List<Album> AlbumsList { get; set; }
        private AlbumRepository repo = new AlbumRepository();

        public void InitialSequence()
        {
            AlbumsList = new List<Album>();
            GetAlbumsList();
        }

        public void GetAlbumsList()
        {
            if(AlbumsList.Count > 0)
            {
                AlbumsList.Clear();
            }

            List<AlbumDTO> DTOs = repo.GetAllAlbumsList();
            foreach (AlbumDTO element in DTOs)
            {
                AlbumsList.Add(new Album(element));
            }
        }

        public Album CreateNewAlbum(string name)
        {
            int resultId = repo.CreateNewAlbum(name);
            GetAlbumsList();
            return AlbumsList.Find(x => x.Id == resultId);
        }

        public bool DeleteAlbum(Album album)
        {
            if(AlbumsList.Find(x=>x == album) != null)
            {
                AlbumsList.Remove(album);
                repo.DeleteAlbumById(album.Id);
                GetAlbumsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAlbumSetName(Album album, string newName)
        {
            if (AlbumsList.Find(x => x.Id == album.Id) != null)
            {
                repo.DeleteAlbumById(album.Id);
                GetAlbumsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAlbumSetReleaseYear(Album album, int year)
        {
            if (AlbumsList.Find(x => x.Id == album.Id) != null)
            {
                repo.UpdateAlbumReleaseYearById(album.Id, year);
                GetAlbumsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAlbumSetAuthor(Album album, Author author)
        {
            if (AlbumsList.Find(x => x.Id == album.Id) != null)
            {
                repo.UpdateAlbumAuthorById(album.Id, author);
                GetAlbumsList();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
