using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }


        [HttpPost("addorder")]
        public IActionResult AddOrder(OrderDTO model)
        {
            try
            {
               
                Order order = new()
                {
                    K205UserId = model.K205UserId,
                    IsDelivered = model.IsDelivered,
                    ProductId = model.ProductId,
                    OrderTrackingId = model.OrderTrackingId,
                    TotalPrice = model.TotalPrice,
                    TotalQuantity = model.TotalQuantity,
                };
                _orderManager.Add(order);

                return Ok(new {status = 200, message= "Sifaris tamamlandi."});
            }
            catch (Exception)
            {
                return BadRequest(new { status = 403, message = "Sifaris zamani xeta bas verdi." });
            }


        }


        [HttpGet("userorders/{userId}")]
        public async Task<IActionResult> UserOrder(int userId)
        {
            var order = _orderManager.GetAll(userId);
            return Ok(new { status = 200, message = order });
        }
    }
}
