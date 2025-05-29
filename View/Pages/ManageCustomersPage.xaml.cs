using Bookmaster.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        List<Customer> _customer = App.context.Customer.ToList();
        public ManageCustomersPage()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDTb.Text) && string.IsNullOrWhiteSpace(NomeTb.Text))
            {
                CustomersLv.ItemsSource = _customer;
            }
            else
            {
                List<Customer> searchResults = _customer.Where(customer =>
                customer.Id.ToLower().Contains(IDTb.Text.ToLower()) &&
                customer.Name.ToLower().Contains(NomeTb.Text.ToLower())).ToList();

                CustomersLv.ItemsSource = searchResults;


            }


        }
    }
}
