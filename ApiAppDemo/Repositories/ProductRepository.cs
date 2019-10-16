using ApiAppDemo.Models;
using ApiAppDemo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoBanHangContext _context;
        
        public ProductRepository(DemoBanHangContext context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {
            int result = 0;
            if (_context != null)
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                result = product.ProductId;
            }
            return result;
        }

        public int DeleteProduct(int productId)
        {          
            int result = 0;
            if (_context != null)
            {
                Product product = _context.Product.FirstOrDefault(x => x.ProductId == productId);
                if (product != null)
                {
                    _context.Product.Remove(product);
                    _context.SaveChanges();
                    result = product.ProductId;
                }
            }
            return result;
        }

        public int EditProduct(Product product)
        {
            int result = 0;
            if(_context != null)
            {
                _context.Product.Update(product);
                _context.SaveChanges();
                result = product.ProductId;
            }
            return result;
        }

        public List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public Product GetProduct(int productId)
        {
            return _context.Product.Find(productId);
        }
    }
}
