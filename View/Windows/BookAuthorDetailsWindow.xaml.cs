using Bookmaster.Model;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorDetailsWindow : Window
    {
        public BookAuthorDetailsWindow(Book selectedAuthors)
        {
            InitializeComponent();
            AuthorsCmb.ItemsSource = selectedAuthors.BookAuthor;
            Title = $"Авторы книги \" {selectedAuthors.Title}\"";
        }

        private void AuthorsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = AuthorsCmb.SelectedItem as BookAuthor;

            Author selectedAuthor = (AuthorsCmb.SelectedItem as BookAuthor).Author;

            OpenWikipediaTbl.Visibility = string.IsNullOrEmpty(selectedAuthor.Wikipedia) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void OpenWikipediaHl_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Close();
        }

        private void CloseBtn_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибки", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
