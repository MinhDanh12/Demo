using Newtonsoft.Json;
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
    /// Interaction logic for EditProductView.xaml
    /// </summary>
    public partial class EditProductView : UserControl
    {
        ConmonService conmonService = new ConmonService();
        ProductService productService = new ProductService();
        public EditProductView()
        {
            InitializeComponent();
            EditProduct();
        }
       
        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("You want to edit products? ", "Question",
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
                var response = await productService.UpdateProductView(product);                 
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
                MainHomeWindow mainHome = new MainHomeWindow();
                mainHome.Content = new ProductView();
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
        private void EditProduct()
        {
            string apiUrl = conmonService.GetApiUrl("/Product");
            // Get data from the App.Current.Properties. These work like global variables.
            var productId = Application.Current.Properties["productId"].ToString();
            // Function call the API to get Product and get response data.
            var response = productService.EditProductView(int.Parse(productId));
            var responseData = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data.
                Product product = JsonConvert.DeserializeObject<Product>(responseData);
                // Assign it to the view.
                txtName.Text = product.Name;
                txtDetail.Text = product.Detail;
                txtPrice.Text = product.Price.ToString();
                txtStatus.Text = product.Status;
                txtUnit.Text = product.Unit;
            }
            //else
            //{
            //    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Result - " + responseData);
            //}
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
