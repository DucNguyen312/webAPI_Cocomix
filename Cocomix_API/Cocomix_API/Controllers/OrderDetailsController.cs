using Cocomix_API.DTO;
using Cocomix_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocomix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsService _orderDetailService;

        public OrderDetailsController(OrderDetailsService orderDetailService) 
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDeatail(int id) 
        {
            try
            {
                var orderDetail = await _orderDetailService.GetOrderDetailById(id);
                return orderDetail != null ? Ok(orderDetail) : NotFound(); 
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("list/order/{id}")]
        public async Task<IActionResult> getListOrderDetail(int id)
        {
            try
            {
                return Ok(await _orderDetailService.GetListOrderDetailsByOrderID(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateOrderDetailById(int id, OrderDetailsDTO orderDTO)
        {
            try
            {
                var orderDetails = await _orderDetailService.UpdateOderDetail(id , orderDTO);
                return orderDetails != null ? Ok(orderDetails) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrderDetail(int id)
        {
            try
            {
                var result = await _orderDetailService.deleteOrderDetails(id);
                return result != null ? Ok(result) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
