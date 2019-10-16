using ApiAppDemo.Models;
using ApiAppDemo.Repositories.Interfaces;
using ApiAppDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public int EditProduct(Product product)
        {
            return _productRepository.EditProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }
    }
}
