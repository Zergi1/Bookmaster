using Bookmaster.View.Pages;
using System.Windows;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LogoutMi.Visibility = Visibility.Collapsed;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ManageCustomersPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new CirculationPage());
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ReportsPage());
        }
    }
}

#region 1) Окнонная навигация
// ==== Способы навигации в WPF
// 1) Оконная навигация
// Осуществляет открытие нового экземпляра окна из другого окна или страницы.
// Алгоритм для реализации (окно называется TestWindow.xaml):

// - создать экземпляр окна TestWindow
// - у экземпляра окна вызываем метод Show(), данный метод открывает модальное окно (будет возможность взаимодействовать с предыдущем окном). Иначе - вызывает метод ShowDialog() Данный метод открывает диалоговае окно (нельзя взаимодействовать с предыдущим окном).

// => TestWindow testWindow = new TestWindow();
// => testWindow.Show();
#endregion
#region  2) Страничная навигация
// 2) Страничная навигация

#endregion