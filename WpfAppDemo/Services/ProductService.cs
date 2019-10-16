using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDemo.Models;
using WpfAppDemo.Views;

namespace WpfAppDemo.Services
{
    public class ProductService
    {
        ConmonService conmonService = new ConmonService();

        public List<Product> GetProducts()
        {
            HttpClient client = new HttpClient();
            string apiUrl = conmonService.GetApiUrl("/Product");
            HttpResponseMessage responseMessage = client.GetAsync(apiUrl + "/GetProducts").Result;
            string responseData = responseMessage.Content.ReadAsStringAsync().Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Product>>(responseData);
            }
            return null;
        }

        public List<Product> GetProduct()
        {
            HttpClient client = new HttpClient();
            string apiUrl = conmonService.GetApiUrl("/Product");
            HttpResponseMessage responseMessage = client.GetAsync(apiUrl + "/GetProduct").Result;
            string responseData = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                // Deserialize the response data to assign it to the data grid.
                return JsonConvert.DeserializeObject<List<Product>>(responseData);
               
            }
            return null;

        }

        public void DeleteProduct(int productId)
        {
            // Get API URL from the App.config file.
            string apiUrl = conmonService.GetApiUrl("/Product");
            // HTTP declarations and settings to connect with the API.
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();                                 
            // Completing the URL and call the API to get response data.
            HttpResponseMessage responseMessage = client.DeleteAsync(apiUrl + "/DeleteProduct/"+ productId).Result;
            string  responseData = responseMessage.Content.ReadAsStringAsync().Result;
           // Show the response message from the server.
            MessageBox.Show(responseData, "Response Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Refresh the data grid.
                GetProducts();
            }
        }
        public HttpResponseMessage EditProductView(int productId)
        {
            string apiUrl = conmonService.GetApiUrl("/Product");
            HttpClient client = new HttpClient();
            var response = client.GetAsync(apiUrl + "/GetProduct/" + productId).Result;

            return response;
        }
        public  Task<HttpResponseMessage> AddProductView(Product product)
        {
            string apiUrl = conmonService.GetApiUrl("/Product");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'Name': '" + product.Name + "', " +
                    "'Detail': '" + product.Detail + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Status': '" + product.Status + "', " +
                    "'Unit': '" + product.Unit +
                    "'}";
            // Completing the URL and call the API to get response data.
            var response = client.PostAsync(apiUrl + "/AddProduct", new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            return response;
            
        }
        public Task<HttpResponseMessage> UpdateProductView(Product product)
        {
            string apiUrl = conmonService.GetApiUrl("/Product");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'ProductId': '" + product.ProductId + "', " +
                    "'Name': '" + product.Name + "', " +
                    "'Detail': '" + product.Detail + "', " +
                    "'Price': '" + product.Price + "', " +
                    "'Status': '" + product.Status + "', " +
                    "'Unit': '" + product.Unit +
                    "'}";
            // Completing the URL and call the API to get response data.
            var response = client.PostAsync(apiUrl + "/EditProduct", new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            return response;
        }
        public void EditProduct(int productId)
        {
            // Get API URL from the App.config file.
            string apiUrl = conmonService.GetApiUrl("/Product");
            // HTTP declarations and settings to connect with the API.
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            // Completing the URL and call the API to get response data.
            HttpResponseMessage responseMessage = client.GetAsync(apiUrl + "/EditProduct/" + productId).Result;
            string responseData = responseMessage.Content.ReadAsStringAsync().Result;
            // Show the response message from the server.
            MessageBox.Show(responseData, "Response Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Refresh the data grid.
                GetProducts();
            }
        }
        public HttpResponseMessage GetProductOrder(int productId)
        {
            // Get API URL from the App.config file.
            string apiUrl = conmonService.GetApiUrl("/Product");
            // HTTP declarations and settings to connect with the API.
            HttpClient httpClient = new HttpClient();
            // Set request header, adding bearer token.
            httpClient.BaseAddress = new Uri(apiUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Completing the URL and call the API to get response data.
            var response = httpClient.GetAsync(apiUrl + "/GetProduct/" + productId).Result;

            return response;
        }
        public HttpResponseMessage ListProduct()
        {
            // Get API URL from the App.config file.
            string apiUrl = conmonService.GetApiUrl("/Product");

            // HTTP declarations and settings to connect with the API.
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);

            // Completing the URL and call the API to get response data.
            HttpResponseMessage response = httpClient.GetAsync(apiUrl + "/GetProducts").Result;

            return response;
        }
    }
}
