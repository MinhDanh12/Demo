using ApiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Repositories.Interfaces
{
    public interface IOrderReponsitory
    {
        int AddOrder(Order order);
        List<Order> GetOrders();
    }
}
