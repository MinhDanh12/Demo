using ApiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(Order order);
        List<Order> GetOrders();
    }
}
