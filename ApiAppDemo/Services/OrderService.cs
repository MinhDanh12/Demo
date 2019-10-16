using ApiAppDemo.Models;
using ApiAppDemo.Repositories.Interfaces;
using ApiAppDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReponsitory _orderReponsitory;

        public OrderService(IOrderReponsitory orderReponsitory)
        {
            _orderReponsitory = orderReponsitory;
        }
        public int AddOrder(Order order)
        {
            return _orderReponsitory.AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return _orderReponsitory.GetOrders();
        }
    }
}
