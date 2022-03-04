using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using PruebaTecnica.WebApi.Models;
using PruebaTecnica.Services.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {

        }
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            try
            {
                return Ok(AppCache.OrderInstance.ToList());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<string> CreateOrder(List<OrderDetailRequest> products)
        {
            try
            {
                List<OrderDetail> order = new();
                foreach (var detail in products)
                {
                    order.Add
                        (
                            new OrderDetail()
                            {
                              Product = new Product(  detail.Sku, string.Empty),
                              Quantity = detail.Quantity
                            }
                        );
                }
                string result = OrderService.CreateOrder(order);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("Error de STOCK");
            }
        }
        [HttpGet("{orderId}/{status}")]
        public ActionResult<int> ChangeStatusOrder(int orderId, int status)
        {
            try
            {
                int result = OrderService.ChangeStatusOrder(orderId, (StatusOrder)status);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
