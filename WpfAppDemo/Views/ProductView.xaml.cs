using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDemo.Models;
using WpfAppDemo.Services;
using WpfAppDemo.ViewModels;

namespace WpfAppDemo.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        ProductService productService = new ProductService();

        public ProductView()
        {
            InitializeComponent();
            dataGridProduct.ItemsSource = productService.GetProducts();            
            //dataGridProduct.ItemsSource = productService.GetProduct();
            // dataGridProduct.ItemsSource = productService.DeleteProduct();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            // Get Product data from the selected row in the data grid.
            Product product = (Product)((Button)e.Source).DataContext;
            int productId = product.ProductId;
            // Set productId into App.Current.Properties. This treats productId like a global variable.
            Application.Current.Properties["productId"] = productId;
            // Navigate from this view to another view.
            MainHomeWindow mainWindow = (MainHomeWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new EditProductViewModel();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Get Product data from the selected row in the data grid.
            Product product = (Product)((Button)e.Source).DataContext;
            int productId = (dataGridProduct.SelectedItem as Product).ProductId;            

            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to Delete this Product?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Delete the selected Product.
                productService.DeleteProduct(productId);
                dataGridProduct.ItemsSource = productService.GetProducts();

            }
        }

        private void DataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Navigate from this view to another view.
            MainHomeWindow mainWindow = (MainHomeWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new AddProductViewModel();
        }
    }
}

