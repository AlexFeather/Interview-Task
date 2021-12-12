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
    /// Логика взаимодействия для GenreEdit.xaml
    /// </summary>
    public partial class OneLineEdit : Window
    {
        public string Text { get; private set; }
        public OneLineEdit()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            Text = EnteredText.Text.ToString();
            DialogResult = true;
            Close();
        }
    }
}
