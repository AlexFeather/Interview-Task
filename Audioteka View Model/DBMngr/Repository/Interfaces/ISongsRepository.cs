using DBMngr.DTO;
using DBMngr.Objects;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Repository
{
    interface ISongsRepository : IRepository<Song>
    {
        public int AddSong(string name);
        public void DeleteSongById(int id);
        public SongDTO GetSongById(int id);
        public List<SongDTO> GetAllSongsList();
        public List<SongDTO> GetSongsListByYear(int year);
        public List<SongDTO> GetSongsListByAuthor(Author author);
        public List<SongDTO> GetSongsListByAlbum(Album album);
        public void UpdateSongReleaseYearById(int id, int newReleaseYear);
        public void UpdateSongAuthorById(int id, Author author);
        public void UpdateSongAlbumById(int id, Album album);
        public void UpdateSongGenreById(int id, Genre genre);
        public void UpdateSongNameById(int id, string newName);
    }
}
