using ApiAppDemo.Models;
using System.Collections.Generic;

namespace ApiAppDemo.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        int AddProduct(Product product);
        int EditProduct(Product product);
        int DeleteProduct(int productId);
        Product GetProduct(int productId);
    }
}
