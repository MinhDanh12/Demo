using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private readonly ProductService productService = new ProductService();

        public ObservableCollection<Order> orderList { get; set; }
        public List<Product> getProduct { get; set; }
        public OrderView()
        {
            InitializeComponent();

            // Create 1 new row of order list.
            orderList = new ObservableCollection<Order>
            {
                new Order()
            };
            var response = productService.ListProduct();
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return it if success.
                getProduct = JsonConvert.DeserializeObject<List<Product>>(responseData);

                // Set data grid's data.
                DataContext = this;
            }
            //else
            //{
            //    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Result - " + responseData);
            //}
        }
        private void DataGridOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            // Create 1 new row of order list.
             orderList.Add(new Order());
            // Get product list data from the database.
            var response =  productService.ListProduct();
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data and then return it if success.
                getProduct = JsonConvert.DeserializeObject<List<Product>>(responseData);

                // Set data grid's data.
                DataContext = this;
            }
            //else
            //{
            //    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Result - " + responseData);
            //}
        }
    }
}
