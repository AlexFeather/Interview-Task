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
    /// Логика взаимодействия для ThreeLineEdit.xaml
    /// </summary>
    public partial class ThreeLineEdit : Window
    {
        public Author SelectedAuthor { get; private set; }
        public string EnteredName { get; private set; }
        public int EnteredYear { get; private set;}
        public Album EditedAlbum { get; set; }
        public ThreeLineEdit()
        {
            InitializeComponent();
            InitialSequence();
        }

        public ThreeLineEdit(Album album)
        {
            EditedAlbum = album;
            InitializeComponent();
            InitialSequence();
        }

        private void InitialSequence()
        {
            AuthorsBoxContent();
            if(EditedAlbum != null)
            {
                Name.Text  = EditedAlbum.Name;
                if(EditedAlbum.Author != null)
                {
                    AuthorComboBox.SelectedIndex = Program.mng.AuthorsCtrl.AuthorsList.FindIndex(x => x.Id == EditedAlbum.Id);
                }
                if(EditedAlbum.ReleaseYear != 0)
                {
                    ReleaseYear.Text = EditedAlbum.ReleaseYear.ToString();
                }
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

        private void AuthorsBox_Select(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorComboBox.SelectedIndex != -1)
            {
                string selectedItem = AuthorComboBox.SelectedItem.ToString();
                SelectedAuthor = Program.mng.AuthorsCtrl.AuthorsList.Find(x => x.Name == selectedItem);
            }
            else
            {
                SelectedAuthor = null;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            int EnteredYearParseResult;
            if (int.TryParse(ReleaseYear.Text, out EnteredYearParseResult))
            {
                if (Name.Text.Length > 0)
                {
                    EnteredName = Name.Text;
                    EnteredYear = EnteredYearParseResult;
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
