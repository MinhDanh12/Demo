using ApiAppDemo.Models;
using ApiAppDemo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Repositories
{
    public class OrderReponsitory : IOrderReponsitory
    {
        private readonly DemoBanHangContext _context;
        public OrderReponsitory(DemoBanHangContext context)
        {
            _context = context;
        }
        public int AddOrder(Order order)
        {
            int result = 0;
            if (_context != null)
            {
                _context.Order.Add(order);
                _context.SaveChanges();
                result = order.OrderId;
            }
            return result;
        }

        public List<Order> GetOrders()
        {
            return _context.Order.ToList();
        }
    }
}
