using DBMngr;
using DBMngr.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VM
{
    /// <summary>
    /// Логика взаимодействия для FiveLineEdit.xaml
    /// </summary>
    public partial class FiveLineEdit : Window
    {
        public Author SelectedAuthor { get; private set; }
        public Genre SelectedGenre { get; private set; }
        public Album SelectedAlbum { get; private set; }
        public string EnteredName { get; private set; }
        public int EnteredYear { get; private set; }
        public Song EditedSong { get; set; }
        public FiveLineEdit()
        {
            InitializeComponent();
            InitialSequence();
        }

        public FiveLineEdit(Song editedSong)
        {
            EditedSong = editedSong;
            InitializeComponent();
            InitialSequence();
        }

        private void InitialSequence()
        {
            GenreBoxContent();
            AuthorsBoxContent();
            AlbumBoxContent();
            if(EditedSong != null)
            {
                Name.Text = EditedSong.Name;
                if(EditedSong.ReleaseYear != 0)
                {
                    ReleaseYear.Text = EditedSong.ReleaseYear.ToString();
                }
                if(EditedSong.Author != null)
                {
                    AuthorComboBox.SelectedIndex = Program.mng.AuthorsCtrl.AuthorsList.FindIndex(x => x.Id == EditedSong.Author.Id);
                }
                if (EditedSong.Genre != null)
                {
                    GenreComboBox.SelectedIndex = Program.mng.GenresCtrl.GenresList.FindIndex(x => x.Id == EditedSong.Genre.Id);
                }
            }
        }

        private void GenreBoxContent()
        {
            GenreComboBox.Items.Clear();
            foreach (Genre element in Program.mng.GenresCtrl.GenresList)
            {
                GenreComboBox.Items.Add(element.Name);
            }
        }

        private void AuthorsBoxContent()
        {
            AuthorComboBox.Items.Clear();
            foreach (Author element in Program.mng.AuthorsCtrl.AuthorsList)
            {
                AuthorComboBox.Items.Add(element.Name);
            }
        }

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
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            int ReleaseYearParseResult;
            if (int.TryParse(ReleaseYear.Text, out ReleaseYearParseResult))
            {
                if (Name.Text.Length > 0)
                {
                    EnteredName = Name.Text;
                    EnteredYear = ReleaseYearParseResult;
                    DialogResult = true;
                    Close();
                }
            }
            else 
            {
                ReleaseYear.Text = "Expected numeric value";
            }
        }
    }
}
