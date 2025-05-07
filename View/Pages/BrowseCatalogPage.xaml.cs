using Bookmaster.AppData;
using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();
        List<BookCover> _covers = App.context.BookCover.ToList();

        //Создаем объект пагинации

        PaginationService<Book> _booksPagination;
        PaginationService<BookCover> _coverPagination;

        public BrowseCatalogPage()
        {
            InitializeComponent();
            //BookAuthorLv.ItemsSource = _books;
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchByAuthorNameTb.Text) &&
                string.IsNullOrWhiteSpace(SearchByBookTitleTb.Text))
            {
                _booksPagination = new PaginationService<Book>(_books);

            }

            else
            {
                List<Book> searchResults = _books.Where(book =>
                book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
                book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();

                _booksPagination = new PaginationService<Book>(searchResults);


            }

            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfItems;
            CurrentpageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            SearchResultsGrid.Visibility = Visibility.Visible;

        }

        private void PreviousBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviusPage();
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            CurrentpageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }

        private void CurrentpageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentpageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _booksPagination.TotalPages)
            {
                BookAuthorLv.ItemsSource = _booksPagination.SetCurrentPage(pageNumber);
                _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            }
        }

        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            CurrentpageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;
            BookDeta0ilsGrid.DataContext = selectedBook;
        }

        private void AuthorDetaillHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorDetailsWindow bookAuthorDetailsWindow = new BookAuthorDetailsWindow();
            bookAuthorDetailsWindow.ShowDialog();
        }
    }
}
