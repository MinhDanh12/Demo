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

namespace WpfAppDemo.Views
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        ProductService productService = new ProductService();
        public AddProductView()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("You want to add products? ", "Question",
                MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Get input data from current view.
                string name = txtName.Text;
                string detail = txtDetail.Text;
                float price = float.Parse(txtPrice.Text);
                string status = txtStatus.Text;
                string unit = txtUnit.Text;

                // Create new Product model to push it to the AddProduct function.
                Product product = new Product()
                {
                    Name = name,
                    Detail = detail,
                    Price = price,
                    Status = status,
                    Unit = unit
                };

                // Function call the API to add Product and get response data.
                var response = await productService.AddProductView(product);
                var responseData = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    // Show the response message from the server.
                    MessageBox.Show(responseData, "Response Message");

                    // Clear all input fields.
                    Reset();

                    // Change response message text to Green.
                    textBlockResponseMessage.Foreground = Brushes.Green;
                }
                else
                {
                    // Change response message text to Red.
                    textBlockResponseMessage.Foreground = Brushes.Red;
                }
                // Show the response message from the server.
                textBlockResponseMessage.Text = responseData;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("You Want To Reset?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Reset();
            }
        }

        private void Reset()
        {
            // Clear all input fields.
            txtName.Text = "";
            txtDetail.Text = "";
            txtPrice.Text = "";
            txtStatus.Text = "";
            txtUnit.Text = "";
            textBlockResponseMessage.Text = "";
        }
    }
}
