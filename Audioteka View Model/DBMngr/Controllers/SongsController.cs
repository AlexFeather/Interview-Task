using DBMngr.DTO;
using DBMngr.Objects;
using DBMngr.Repository;
using System.Collections.Generic;
using System.Text;

namespace DBMngr.Controllers
{
    public class SongsController
    {
        public List<Song> SongsList { get; set; }
        public List<Song> FilteredList { get; set; }
        SongsRepository repo = new SongsRepository();

        public void InitialSequence()
        {
            SongsList = new List<Song>();
            GetSongsList();
        }

        public void GetSongsList()
        {
            if (SongsList.Count > 0)
            {
                SongsList.Clear();
            }

            List<SongDTO> DTOs = repo.GetAllSongsList();
            foreach (SongDTO element in DTOs)
            {
                SongsList.Add(new Song(element));
            }
        }

        public Song CreateNewSong(string name)
        {
            int resultId = repo.AddSong(name);
            GetSongsList();
            return SongsList.Find(x => x.Id == resultId);
        }

        public bool DeleteSong(Song song)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.DeleteSongById(song.Id);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSongSetName(Song song, string newName)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.UpdateSongNameById(song.Id, newName);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateSongSetAuthor(Song song, Author author)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.UpdateSongAuthorById(song.Id, author);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSongSetAlbum(Song song, Album album)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.UpdateSongAlbumById(song.Id, album);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSongSetGenre(Song song, Genre genre)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.UpdateSongGenreById(song.Id, genre);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSongsetReleaseYear(Song song, int releaseYear)
        {
            if (SongsList.Find(x => x.Id == song.Id) != null)
            {
                repo.UpdateSongReleaseYearById(song.Id, releaseYear);
                GetSongsList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Filter(Author author, Genre genre, Album album, int year)
        {
            FilteredList = new List<Song>();
            if (FilteredList.Count > 0)
            {
                FilteredList.Clear();
            }

            List<SongDTO> DTOs = repo.GetFilteredList(author, album, genre, year);
            foreach (SongDTO element in DTOs)
            {
                FilteredList.Add(new Song(element));
            }
        }
    }
}
