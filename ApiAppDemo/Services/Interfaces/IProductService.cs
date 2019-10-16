using ApiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        int AddProduct(Product product);
        int EditProduct(Product product);
        int DeleteProduct(int productId);
        Product GetProduct(int productId);  
    }
}
