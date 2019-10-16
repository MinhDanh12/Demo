using ApiAppDemo.Models;
using ApiAppDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct ([FromBody] Product product)
        {           
            int addProduct = _productService.AddProduct(product);
            if (addProduct > 0)
            {
                return StatusCode(200, " Add product successful.");               
            }
            return StatusCode(500, "Can not add product.");
        }

        [HttpPost]
        [Route("EditProduct")]
        public ActionResult EditProduct([FromBody] Product product)
        {
            int editProduct = _productService.EditProduct(product);
            if (editProduct > 0)
            {
                return StatusCode(200, "Edit product successful.");
            }
            return StatusCode(500, "Can not edit product.");
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            int deleteProduct = _productService.DeleteProduct(productId);
            if (deleteProduct > 0)
            {
                return StatusCode(200, "Delete product successful.");
            }
            return StatusCode(500, "Can not delete product.");            
        }

        [HttpGet("GetProduct/{productId}")]
        public ActionResult GetProduct(int productId)
        {
            Product product = _productService.GetProduct(productId);
            if (product != null)
            {
                return StatusCode(200, product);
            }
            return StatusCode(500, "Can not get product.");
        }
    }
}
