using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTrackingController : ControllerBase
    {
        private readonly IOrderTrackingManager _trackingManager;

        public OrderTrackingController(IOrderTrackingManager trackingManager)
        {
            _trackingManager = trackingManager;
        }


        [HttpGet("getallordertracking")]
        public async Task<IActionResult> GetAll()
        {
            var order = _trackingManager.GetAll();
            return Ok(new { status = 200, message = order });
        }

       
    }
}
