using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfAppDemo.Models;

namespace WpfAppDemo.Services
{
    public class OrderService
    {
        ConmonService conmonService = new ConmonService();

        public HttpResponseMessage GetOrders()
        {
            string apiUrl = conmonService.GetApiUrl("/Order");
            HttpClient client = new HttpClient();
            var response = client.GetAsync(apiUrl + "/GetOrders" ).Result;

            return response;
        }

        public Task<HttpResponseMessage> AddOrder(Order order)
        {
            string apiUrl = conmonService.GetApiUrl("/Order");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            // Create a JSON body to send with the request to the API.
            string jsonBody = "{" +
                    "'UserId': " + order.UserId + "," +
                    "'ProductId': " + order.ProductId + "," +
                    "'Quantity': " + order.Quantity +
                    "}";         
            // Completing the URL and call the API to get response data.
            var response = client.PostAsync(apiUrl + "/AddOrder", new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            return response;
        }
    }
}
