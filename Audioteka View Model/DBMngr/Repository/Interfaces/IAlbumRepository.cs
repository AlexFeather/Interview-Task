using DBMngr.DTO;
using DBMngr.Objects;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Repository
{
    interface IAlbumRepository : IRepository<Album>
    {
        public List<AlbumDTO> GetAllAlbumsList();
        public List<AlbumDTO> GetAlbumsListByYear(int year);
        public List<AlbumDTO> GetAlbumsListByAuthor(Author author);
        public AlbumDTO GetAlbumById(int id);
        public int CreateNewAlbum(string name);
        public void DeleteAlbumById(int id);
        public void UpdateAlbumNameById(int id, string newName);
        public void UpdateAlbumReleaseYearById(int id, int releaseYear);
        public void UpdateAlbumAuthorById(int id, Author author);
    }
}
