using DBMngr;
using DBMngr.Objects;
using System.Windows;
using System.Windows.Controls;

namespace VM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Genre SelectedGenre { get; private set; }
        public Author SelectedAuthor { get; private set; }
        public Album SelectedAlbum { get; private set; }
        public Song SelectedSong { get; private set; }
        public int EnteredYear { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Program.mng.ControllersStart();
            GenreBoxContent();
            AuthorsBoxContent();
            AlbumBoxContent();
            SongsBoxContent();

        }

        //songs
        private void SongsBoxContent()
        {
            if(SongsListBox.Items.Count > 0)
            {
                SongsListBox.Items.Clear();
            }


            if(SelectedAlbum != null || SelectedAuthor != null || SelectedGenre != null || EnteredYear != 0)
            {
                Program.mng.SongsCtrl.Filter(SelectedAuthor, SelectedGenre, SelectedAlbum, EnteredYear);
                foreach (Song element in Program.mng.SongsCtrl.FilteredList)
                {
                    SongsListBox.Items.Add(element.Name);
                }
            }
            else
            {

                foreach (Song element in Program.mng.SongsCtrl.SongsList)
                {
                    SongsListBox.Items.Add(element.Name);
                }
            }


        }

        private void SongsListBox_Select(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = SongsListBox.SelectedItem.ToString();
            SelectedSong = Program.mng.SongsCtrl.SongsList.Find(x => x.Name == Name);
        }

        private void SongAddButton_Click(object sender, RoutedEventArgs e)
        {
            FiveLineEdit window = new FiveLineEdit();
            Song created;
            window.ShowDialog();
            if(window.DialogResult == true)
            {
                created = Program.mng.SongsCtrl.CreateNewSong(window.EnteredName);
                if(window.EnteredYear != 0)
                {
                    Program.mng.SongsCtrl.UpdateSongsetReleaseYear(created, window.EnteredYear);
                }
                if(window.SelectedGenre != null)
                {
                    Program.mng.SongsCtrl.UpdateSongSetGenre(created, Program.mng.GenresCtrl.GenresList.Find(x => x == window.SelectedGenre));
                }
                if(window.SelectedAuthor != null)
                {
                    Program.mng.SongsCtrl.UpdateSongSetAuthor(created, Program.mng.AuthorsCtrl.AuthorsList.Find(x => x == window.SelectedAuthor));
                }
                if(window.SelectedAlbum != null)
                {
                    Program.mng.SongsCtrl.UpdateSongSetAlbum(created, Program.mng.AlbumsCtrl.AlbumsList.Find(x => x == window.SelectedAlbum));
                }

            }
        }

        private void SongUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FiveLineEdit window = new FiveLineEdit(SelectedSong);
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                if(window.EnteredName != null && window.EnteredName != SelectedSong.Name)
                {
                    Program.mng.SongsCtrl.UpdateSongSetName(SelectedSong, window.EnteredName);
                }
                if (window.EnteredYear != 0 && window.EnteredYear != SelectedSong.ReleaseYear)
                {
                    Program.mng.SongsCtrl.UpdateSongsetReleaseYear(SelectedSong, window.EnteredYear);
                }
                if (window.SelectedGenre != null && window.SelectedGenre != SelectedSong.Genre)
                {
                    Program.mng.SongsCtrl.UpdateSongSetGenre(SelectedSong, window.SelectedGenre);
                }
                if (window.SelectedAuthor != null && window.SelectedAuthor != SelectedSong.Author)
                {
                    Program.mng.SongsCtrl.UpdateSongSetAuthor(SelectedSong, window.SelectedAuthor);
                }
                if (window.SelectedAlbum != null && window.SelectedAlbum != SelectedSong.Album)
                {
                    Program.mng.SongsCtrl.UpdateSongSetAlbum(SelectedSong, window.SelectedAlbum);
                }
            }
        }

        public void SongDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSong != null)
            {
                DeleteConfirm window = new DeleteConfirm();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Program.mng.SongsCtrl.DeleteSong(SelectedSong);
                }
                GenreComboBox.SelectedIndex = -1;
                GenreBoxContent();
            }
        }



        //genres

        private void GenreBoxContent()
        {
            GenreComboBox.Items.Clear();
            foreach (Genre element in Program.mng.GenresCtrl.GenresList)
            {
                GenreComboBox.Items.Add(element.Name);
            }
        }

        private void GenreComboBox_Select(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedIndex != -1)
            {
                string selectedItem = GenreComboBox.SelectedItem.ToString();
                SelectedGenre = Program.mng.GenresCtrl.GenresList.Find(x => x.Name == selectedItem);
            }
            else
            {
                SelectedGenre = null;
            }
            SongsBoxContent();
        }

        private void GenreAddButton_Click(object sender, RoutedEventArgs e)
        {
            OneLineEdit window = new OneLineEdit();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                Program.mng.GenresCtrl.CreateNewGenre(window.Text);
            }
            GenreBoxContent();

        }

        private void GenreUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGenre != null)
            {
                OneLineEdit editWindow = new OneLineEdit();
                editWindow.ShowDialog();
                if (editWindow.DialogResult == true)
                {
                    Program.mng.GenresCtrl.UpdateGenreSetName(SelectedGenre, editWindow.Text);
                }
                GenreComboBox.SelectedIndex = -1;
                GenreBoxContent();
            }

        }

        private void GenreDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGenre != null)
            {
                DeleteConfirm window = new DeleteConfirm();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Program.mng.GenresCtrl.DeleteGenre(SelectedGenre);
                }
                GenreComboBox.SelectedIndex = -1;
                GenreBoxContent();
            }
        }

        //authors

        private void AuthorsBoxContent()
        {
            AuthorComboBox.Items.Clear();
            foreach (Author element in Program.mng.AuthorsCtrl.AuthorsList)
            {
                AuthorComboBox.Items.Add(element.Name);
            }
        }


        private void AuthorComboBox_Select(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorComboBox.SelectedIndex != -1)
            {
                string selectedItem = AuthorComboBox.SelectedItem.ToString();
                SelectedAuthor = Program.mng.AuthorsCtrl.AuthorsList.Find(x => x.Name == selectedItem);
                AlbumBoxContent();
            }
            else
            {
                SelectedAuthor = null;
                AlbumBoxContent();
            }
            SongsBoxContent();
        }

        private void AuthorAddButton_Click(object sender, RoutedEventArgs e)
        {
            OneLineEdit window = new OneLineEdit();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                Program.mng.AuthorsCtrl.CreateNewAuthor(window.Text);
            }
            AuthorsBoxContent();
        }

        private void AuthorUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAuthor != null)
            {
                OneLineEdit window = new OneLineEdit();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Program.mng.AuthorsCtrl.UpdateAuthorSetName(SelectedAuthor, window.Text);
                }
                AuthorComboBox.SelectedIndex = -1;
                AuthorsBoxContent();
            }
        }

        private void AuthorDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAuthor != null)
            {
                DeleteConfirm window = new DeleteConfirm();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Program.mng.AuthorsCtrl.DeleteAuthor(SelectedAuthor);
                }
                AuthorComboBox.SelectedIndex = -1;
                AuthorsBoxContent();
            }
        }

        //albums

        private void AlbumBoxContent()
        {
            AlbumComboBox.Items.Clear();
            if (Program.mng.AlbumsCtrl.AlbumsList.Count > 0)
            {
                if (SelectedAuthor == null)
                {
                    foreach (Album element in Program.mng.AlbumsCtrl.AlbumsList)
                    {
                        AlbumComboBox.Items.Add(element.Name);
                    }
                }
                else
                {
                    foreach (Album element in Program.mng.AlbumsCtrl.AlbumsList)
                    {

                        if (element.Author != null && element.Author == SelectedAuthor)
                        {
                            AlbumComboBox.Items.Add(element.Name);
                        }
                    }
                }
            }
        }

        private void AlbumComboBox_Select(object sender, SelectionChangedEventArgs e)
        {
            if (AlbumComboBox.SelectedIndex != -1)
            {
                string selectedItem = AlbumComboBox.SelectedItem.ToString();
                SelectedAlbum = Program.mng.AlbumsCtrl.AlbumsList.Find(x => x.Name == selectedItem);
            }
            else
            {
                SelectedAlbum = null;
            }
            SongsBoxContent();
        }

        private void AlbumAddButton_Click(object sender, RoutedEventArgs e)
        {
            Album created;
            ThreeLineEdit window = new ThreeLineEdit();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                created = Program.mng.AlbumsCtrl.CreateNewAlbum(window.EnteredName);
                if (window.EnteredYear != 0)
                {
                    Program.mng.AlbumsCtrl.UpdateAlbumSetReleaseYear(created, window.EnteredYear);
                }
                if (window.SelectedAuthor != null)
                {
                    Program.mng.AlbumsCtrl.UpdateAlbumSetAuthor(created, Program.mng.AuthorsCtrl.AuthorsList.Find(x => x == window.SelectedAuthor));
                }
            }
            AlbumBoxContent();
        }

        private void AlbumUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ThreeLineEdit window = new ThreeLineEdit(SelectedAlbum);
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                if (window.EnteredName != null && window.Name.Text != SelectedAlbum.Name)
                {
                    Program.mng.AlbumsCtrl.UpdateAlbumSetName(SelectedAlbum, window.EnteredName);
                }
                if (window.EnteredYear != 0 && window.EnteredYear != SelectedAlbum.ReleaseYear)
                {
                    Program.mng.AlbumsCtrl.UpdateAlbumSetReleaseYear(SelectedAlbum, window.EnteredYear);
                }
                if (window.SelectedAuthor != null)
                {
                    Program.mng.AlbumsCtrl.UpdateAlbumSetAuthor(SelectedAlbum, window.SelectedAuthor);
                }
            }
        }

        private void AlbumDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAlbum != null)
            {
                DeleteConfirm window = new DeleteConfirm();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Program.mng.AlbumsCtrl.DeleteAlbum(SelectedAlbum);
                }
                AlbumComboBox.SelectedIndex = -1;
                AlbumBoxContent();
            }
        }

        //other
        private void FindByYearButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if(int.TryParse(ReleaseYearTextBox.Text.ToString(), out result))
            {
                EnteredYear = result;
                SongsBoxContent();
            }
            else
            {
                ReleaseYearTextBox.Text = "Expecting numeric value";
            }
        }
    }
}
