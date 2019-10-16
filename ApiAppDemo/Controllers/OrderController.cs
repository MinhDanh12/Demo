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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("AddOrder")]
        public ActionResult AddOrder([FromBody] Order order)
        {
            int addOrder = _orderService.AddOrder(order);
            if (addOrder > 0)
            {
                return StatusCode(200, " Add order successful.");
            }
            return StatusCode(500, "Can not add order.");
        }

        [HttpGet]
        [Route("GetOrders")]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _orderService.GetOrders();
        }
        //[HttpGet]
        //[Route("test")]
        //public ActionResult test()
        //{
        //    return Ok();
        //}
    }
}
